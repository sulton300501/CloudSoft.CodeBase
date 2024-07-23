using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.MemberRoles.Commands.UpdateMemberRole
{
    public class UpdateMemberRoleCommandHandler : IRequestHandler<UpdateMemberRoleCommand, MemberRole>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMemberRoleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MemberRole> Handle(UpdateMemberRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.MemberRoles.FirstOrDefaultAsync(x => x.Id == request.Id ,cancellationToken);

            if (result == null) 
            {
                throw new Exception("Not found");
            }


            result.Name = request.Name;


             _context.MemberRoles.Update(result);
           await  _context.SaveChangesAsync(cancellationToken);

            return result;


        }
    }
}
