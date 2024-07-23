using CloudSoft.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Company>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public IFormFile Picture { get; set; }
    }
}
