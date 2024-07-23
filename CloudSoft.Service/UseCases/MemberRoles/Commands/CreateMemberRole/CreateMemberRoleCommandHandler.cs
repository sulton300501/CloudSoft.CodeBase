using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.MemberRoles.Commands.CreateMemberRole
{
    public class CreateMemberRoleCommandHandler : IRequestHandler<CreateMemberRoleCommands, MemberRole>
    {
        private readonly IApplicationDbContext _context;

        public CreateMemberRoleCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<MemberRole> Handle(CreateMemberRoleCommands request, CancellationToken cancellationToken)
        {

            var member = new MemberRole
            {
                Name = request.Name,
            };

            var result = _context.MemberRoles.Add(member);
            await _context.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }
    }
}
