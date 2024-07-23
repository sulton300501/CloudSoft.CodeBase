using CloudSoft.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Company>
    {
        public string Title { get; set; }
        public IFormFile Picture { get; set; }
    }
}
