using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.ProjectInfos.Commands.CreateProjectInfo
{
    public class CreateProjectInfoCommandHandler : IRequestHandler<CreateProjectInfoCommand, ProjectInfo>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateProjectInfoCommandHandler(IApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ProjectInfo> Handle(CreateProjectInfoCommand request, CancellationToken cancellationToken)
        {


            var file = request.Picture;
            var uploadFile = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var fileName = "";

            try
            {
                if (!Directory.Exists(uploadFile))
                {
                    Directory.CreateDirectory(uploadFile);
                    Debug.WriteLine("Create success");
                }

                fileName = Guid.NewGuid() + ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadFile, fileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }


            }catch (Exception ex)
            {
                throw new Exception("An error occurred while uploading the file.", ex);
            }

            var result = await _context.Extensions.Where(x=>request.Extensions.Contains(x.Id)).ToListAsync();

            var project = new ProjectInfo()
            {
                Title = request.Title,
                Picture = fileName,
                Description = request.Description,
                Extensions = result
            };

            var natija  = _context.Projects.Add(project);
            await _context.SaveChangesAsync(cancellationToken);

            return natija.Entity;



          
 
            
        }
    }
}
