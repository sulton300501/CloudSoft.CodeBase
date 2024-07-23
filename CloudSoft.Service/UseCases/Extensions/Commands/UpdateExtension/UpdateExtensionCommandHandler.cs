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

namespace CloudSoft.Service.UseCases.Extensions.Commands.UpdateExtension
{
    public class UpdateExtensionCommandHandler : IRequestHandler<UpdateExtensionCommand, ExtensionsName>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateExtensionCommandHandler(IApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ExtensionsName> Handle(UpdateExtensionCommand request, CancellationToken cancellationToken)
        {

            var project = await _context.Extensions.FirstOrDefaultAsync(z => z.Id == request.Id);


            if (project == null)
            {
                throw new Exception("Project not found.");
            }

            string fileName = project.Picture;

            if (request.Picture != null)
            {
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "extension");

                try
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                        Debug.WriteLine("Directory created successfully.");
                    }

                    // Delete old file
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        var oldFilePath = Path.Combine(uploadPath, fileName);
                        if (File.Exists(oldFilePath))
                        {
                            File.Delete(oldFilePath);
                            Debug.WriteLine("Old file deleted successfully.");
                        }
                    }

                    // Save new file
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Picture.FileName);
                    string filePath = Path.Combine(uploadPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Picture.CopyToAsync(stream);
                    }

                    Debug.WriteLine("File uploaded successfully.");
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while uploading the file.", ex);
                }
            }

            // Get the list of ExtensionsName entities from the database based on the provided IDs





            project.Name = request.Name;
            project.Picture = fileName;
            project.Description = request.Description;
            


            _context.Extensions.Update(project);
            await _context.SaveChangesAsync(cancellationToken);

            return project;




        }
    }
}
