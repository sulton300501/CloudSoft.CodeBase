using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.TeamMembers.Commands.DeleteTeam
{
    public class DeleteTeamMemberCommandHandler : IRequestHandler<DeleteTeamMemberCommand, bool>
    {
        private  readonly IApplicationDbContext _context;

        public DeleteTeamMemberCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.TeamMemebers.FirstOrDefaultAsync(x => x.Id == request.TeamMemberId);

            if (result == null)
            {
                return false;
            }

            var natija = _context.TeamMemebers.Remove(result);
            return true;
        }
    }
}
