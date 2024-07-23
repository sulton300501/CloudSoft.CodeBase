using CloudSoft.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.ProjectInfos.Queries.GetAllQueries
{
    public class GetAllQueryCommand : IRequest<IEnumerable<ProjectInfo>>
    {

    }
}
