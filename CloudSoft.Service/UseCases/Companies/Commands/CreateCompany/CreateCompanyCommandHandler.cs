using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Company>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateCompanyCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {

            var file = request.Picture;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "company");
            var fileName = "";

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.WriteLine("Create ");

            }

            fileName = Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
            var filePath = Path.Combine(path, fileName);

            using(var stream = new FileStream(filePath ,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            var result = new Company()
            {
                Title = request.Title,
                Picture = fileName
            };

            var data =  _context.Companies.AddAsync(result);
            await  _context.SaveChangesAsync(cancellationToken);
            return result;







        }
    }
}
