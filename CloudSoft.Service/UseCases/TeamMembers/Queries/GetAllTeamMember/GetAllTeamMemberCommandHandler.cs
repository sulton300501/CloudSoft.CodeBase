using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.TeamMembers.Queries.GetAllTeamMember
{
    public class GetAllTeamMemberCommandHandler : IRequestHandler<GetAllTeamMemberCommand, IEnumerable<TeamMemeber>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTeamMemberCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<IEnumerable<TeamMemeber>> Handle(GetAllTeamMemberCommand request, CancellationToken cancellationToken)
        {
            return await _context.TeamMemebers.ToListAsync(cancellationToken);
        }
    }
}
