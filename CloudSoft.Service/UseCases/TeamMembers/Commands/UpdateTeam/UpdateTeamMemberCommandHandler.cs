using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using CloudSoft.Service.UseCases.TeamMembers.Commands.DeleteTeam;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.TeamMembers.Commands.UpdateTeam
{
    public class UpdateTeamMemberCommandHandler : IRequestHandler<UpdateTeamMemberCommand, TeamMemeber>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateTeamMemberCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<TeamMemeber> Handle(UpdateTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var project = _context.TeamMemebers.FirstOrDefault(z => z.Id == request.Id);

            if (project == null)
            {
                throw new Exception("Team member not found");
            }

            var file = request.Picture;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "teamImage");
            var fileName = "";

            if (file != null)
            {
                try
                {
                    var pathUrl = Path.Combine(_webHostEnvironment.WebRootPath, "teamImage");
                    if (!Directory.Exists(pathUrl))
                    {
                        Directory.CreateDirectory(pathUrl);
                        Debug.WriteLine("Create Url");
                    }

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Picture.FileName);
                    var dataPath = Path.Combine(pathUrl, fileName);

                    if (!string.IsNullOrEmpty(project.PicturePath))
                    {
                        var oldFilePath = Path.Combine(pathUrl, project.PicturePath);
                        if (File.Exists(oldFilePath))
                        {
                            File.Delete(oldFilePath);
                            Debug.WriteLine("Delete old file");
                        }
                    }

                    using (var stream = new FileStream(dataPath, FileMode.Create))
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

            project.Age = request.Age;
            project.Description = request.Description;
            project.PicturePath = fileName;
            project.MemberRoleId = request.MemberRoleId;

            var result = _context.TeamMemebers.Update(project);
            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }
    }
}
