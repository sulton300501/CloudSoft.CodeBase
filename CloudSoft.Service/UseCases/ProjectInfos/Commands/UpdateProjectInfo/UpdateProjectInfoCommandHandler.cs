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

namespace CloudSoft.Service.UseCases.ProjectInfos.Commands.UpdateProjectInfo
{
    public class UpdateProjectInfoCommandHandler : IRequestHandler<UpdateProjectInfoCommand, ProjectInfo>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateProjectInfoCommandHandler(IApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ProjectInfo> Handle(UpdateProjectInfoCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.Include(p => p.Extensions)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (project == null)
            {
                throw new Exception("Project not found.");
            }

            string fileName = project.Picture;

            if (request.Picture != null)
            {
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");

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
            var extensionsList = await _context.Extensions
                .Where(x => request.Extensions.Contains(x.Id))
                .ToListAsync(cancellationToken);

            project.Title = request.Title;
            project.Picture = fileName;
            project.Description = request.Description;
            project.Extensions = extensionsList;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync(cancellationToken);

            return project;
        }
    }
}
