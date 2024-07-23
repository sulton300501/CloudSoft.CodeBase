using CloudSoft.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Extensions.Commands.CreateExtension
{
    public class CreateExtensionCommand : IRequest<ExtensionsName>
    {

        public string Name { get; set; }
        public IFormFile Picture { get; set; }
        public string Description { get; set; }

    }
}
