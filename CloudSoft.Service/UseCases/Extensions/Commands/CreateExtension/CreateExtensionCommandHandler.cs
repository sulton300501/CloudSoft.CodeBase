using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Extensions.Commands.CreateExtension
{
    public class CreateExtensionCommandHandler : IRequestHandler<CreateExtensionCommand, ExtensionsName>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateExtensionCommandHandler(IApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ExtensionsName> Handle(CreateExtensionCommand request, CancellationToken cancellationToken)
        {

            var file = request.Picture;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "extension");
            var fileName = "";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.WriteLine("Create ");

            }

            fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(path, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
               await file.CopyToAsync(stream);
            }


            var result = new ExtensionsName()
            {
               Name = request.Name,
               Picture=fileName,
               Description = request.Description,
            };

            var data = _context.Extensions.AddAsync(result);
            await _context.SaveChangesAsync(cancellationToken);
            return result;



        }
    }
}
