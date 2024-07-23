using CloudSoft.Service.UseCases.Companies.Commands.CreateCompany;
using CloudSoft.Service.UseCases.Companies.Commands.DeleteCompany;
using CloudSoft.Service.UseCases.Companies.Commands.UpdateCompany;
using CloudSoft.Service.UseCases.Companies.Queries.GetAllCompany;
using CloudSoft.Service.UseCases.Extensions.Commands.CreateExtension;
using CloudSoft.Service.UseCases.Extensions.Commands.DeleteExtension;
using CloudSoft.Service.UseCases.Extensions.Commands.UpdateExtension;
using CloudSoft.Service.UseCases.Extensions.Queries.GetAllExtension;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudSoft.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExtensionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExtensionController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateExtensionCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMemberRole(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllExtensionCommand(), cancellationToken);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProject(DeleteExtensionCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateExtensionCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }



    }
}
