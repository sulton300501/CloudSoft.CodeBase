using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.ProjectInfos.Commands.DeleteProjectInfo
{
    public class DeleteProjectInfoCommand : IRequest<bool>
    {
        public int ProjectId { get; set; }
    }
}
