using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.TeamMembers.Commands.DeleteTeam
{
    public class DeleteTeamMemberCommand : IRequest<bool>
    {
        public int TeamMemberId { get; set; }
    }
}
