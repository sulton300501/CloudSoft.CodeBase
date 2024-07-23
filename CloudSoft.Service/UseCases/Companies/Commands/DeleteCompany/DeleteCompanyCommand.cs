using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<bool>
    {
        public int CompanyId { get; set; }
    }
}
