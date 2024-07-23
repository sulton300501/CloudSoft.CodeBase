using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Extensions.Commands.DeleteExtension
{
    public class DeleteExtensionCommand : IRequest<bool>
    {
        public int ExtensionId { get; set; }
    }
}
