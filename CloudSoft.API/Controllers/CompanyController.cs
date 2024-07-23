using CloudSoft.Service.UseCases.Companies.Commands.CreateCompany;
using CloudSoft.Service.UseCases.Companies.Commands.DeleteCompany;
using CloudSoft.Service.UseCases.Companies.Commands.UpdateCompany;
using CloudSoft.Service.UseCases.Companies.Queries.GetAllCompany;
using CloudSoft.Service.UseCases.MemberRoles.Queries.GetAllMemberRole;
using CloudSoft.Service.UseCases.TeamMembers.Commands.DeleteTeam;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudSoft.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult>CreateCompany(CreateCompanyCommand command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command,cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMemberRole(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllCompanyCommand(), cancellationToken);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProject(DeleteCompanyCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateCompanyCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }




    }
}
