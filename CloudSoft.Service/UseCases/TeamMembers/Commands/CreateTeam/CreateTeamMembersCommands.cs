using CloudSoft.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.TeamMembers.Commands.CreateTeam
{
    public class CreateTeamMembersCommands : IRequest<TeamMemeber>
    {
        public short Age { get; set; }
        public long MemberRoleId { get; set; }
        public string Description { get; set; }

        public IFormFile Picture { get; set; }
       /* public string PicturePath { get; set; }*/

    }
}
