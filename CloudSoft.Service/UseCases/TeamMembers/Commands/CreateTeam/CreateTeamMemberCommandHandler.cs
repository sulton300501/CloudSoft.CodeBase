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

namespace CloudSoft.Service.UseCases.TeamMembers.Commands.CreateTeam
{
    public class CreateTeamMemberCommandHandler : IRequestHandler<CreateTeamMembersCommands, TeamMemeber>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateTeamMemberCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<TeamMemeber> Handle(CreateTeamMembersCommands request, CancellationToken cancellationToken)
        {

            var file = request.Picture;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "teamImage");
            var fileName = "";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.WriteLine("Create Success");
            }


            fileName = Guid.NewGuid() + ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(path, fileName);
            

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            var result = new TeamMemeber
            {
                Age = request.Age,
                MemberRoleId = request.MemberRoleId,
                Description = request.Description,
                PicturePath = fileName,

            };

            var natija = await _context.TeamMemebers.AddAsync(result);
            await _context.SaveChangesAsync(cancellationToken);
            return result;




        }
    }
}
