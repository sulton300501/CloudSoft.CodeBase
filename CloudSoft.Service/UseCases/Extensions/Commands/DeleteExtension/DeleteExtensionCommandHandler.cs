using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Extensions.Commands.DeleteExtension
{
    public class DeleteExtensionCommandHandler : IRequestHandler<DeleteExtensionCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteExtensionCommandHandler(IApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> Handle(DeleteExtensionCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Extensions.FirstOrDefaultAsync(z => z.Id == request.ExtensionId, cancellationToken);

            if (project == null)
            {
                return false;
            }

            var file = project.Picture;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "extension");

            if (!string.IsNullOrEmpty(file))
            {
                try
                {
                    var filePath = Path.Combine(path, file);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        Debug.WriteLine("Deleted old file");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while deleting the file.", ex);
                }
            }

            _context.Extensions.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
