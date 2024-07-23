using CloudSoft.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.TeamMembers.Commands.DeleteTeam
{
    public class UpdateTeamMemberCommand : IRequest<TeamMemeber>
    {
        public long Id { get; set; }
        public short Age { get; set; }
        public long MemberRoleId { get; set; }
        public string Description { get; set; }

        public IFormFile Picture { get; set; }

    }
}
