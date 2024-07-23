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

namespace CloudSoft.Service.UseCases.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Company>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateCompanyCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {

            var project = await _context.Companies.FirstOrDefaultAsync(z => z.Id == request.Id);


            if (project == null)
            {
                throw new Exception("Project not found.");
            }

            string fileName = project.Picture;

            if (request.Picture != null)
            {
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "company");

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




            var company = new Company
            {
                Title = request.Title,
                Picture = fileName
            };
           

             _context.Companies.Update(company);
            await _context.SaveChangesAsync(cancellationToken);

            return company;


        }
    }
}
