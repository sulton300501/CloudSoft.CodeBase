using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.MemberRoles.Commands.DeleteMemberRole
{
    public class DeleteMemberRoleCommandHandler : IRequestHandler<DeleteMemberRoleCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMemberRoleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteMemberRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.MemberRoles.FirstOrDefaultAsync(x => x.Id == request.MemberRoleId);

            if (result == null)
            {
                throw new Exception("Id not found");
            }

              _context.MemberRoles.Remove(result);
             await _context.SaveChangesAsync(cancellationToken);
            return true;


        }
    }
}
