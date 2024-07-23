using CloudSoft.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.MemberRoles.Commands.CreateMemberRole
{
    public class CreateMemberRoleCommands : IRequest<MemberRole>
    {
        public string Name { get; set; }
    }
}
