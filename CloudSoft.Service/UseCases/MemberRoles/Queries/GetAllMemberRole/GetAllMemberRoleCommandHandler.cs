using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.MemberRoles.Queries.GetAllMemberRole
{
    public class GetAllMemberRoleCommandHandler : IRequestHandler<GetAllMemberRolesCommand, IEnumerable<MemberRole>>
    {
        private readonly  IApplicationDbContext _context;

        public GetAllMemberRoleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MemberRole>> Handle(GetAllMemberRolesCommand request, CancellationToken cancellationToken)
        {
            
            var result = await _context.MemberRoles.ToListAsync(cancellationToken);
            return result;

        }
    }
}
