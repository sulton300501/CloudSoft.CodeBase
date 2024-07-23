using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.MemberRoles.Commands.DeleteMemberRole
{
    public class DeleteMemberRoleCommand : IRequest<bool>
    {
        public int MemberRoleId { get; set; }
    }
}
