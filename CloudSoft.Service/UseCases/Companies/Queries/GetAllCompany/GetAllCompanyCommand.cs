using CloudSoft.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Companies.Queries.GetAllCompany
{
    public class GetAllCompanyCommand : IRequest<IEnumerable<Company>>
    {
    }
}
