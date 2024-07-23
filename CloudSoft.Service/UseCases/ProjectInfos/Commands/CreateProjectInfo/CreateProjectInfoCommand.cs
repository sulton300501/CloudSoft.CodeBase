using CloudSoft.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.ProjectInfos.Commands.CreateProjectInfo
{
    public class CreateProjectInfoCommand : IRequest<ProjectInfo>
    {
        public string Title { get; set; }
        public IFormFile Picture { get; set; }
        public string Description { get; set; }
        public List<long> Extensions { get; set; }
    }
}
