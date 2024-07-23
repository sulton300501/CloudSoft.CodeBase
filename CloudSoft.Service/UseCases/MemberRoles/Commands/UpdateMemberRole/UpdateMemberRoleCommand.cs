using CloudSoft.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.MemberRoles.Commands.UpdateMemberRole
{
    public class UpdateMemberRoleCommand : IRequest<MemberRole>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
