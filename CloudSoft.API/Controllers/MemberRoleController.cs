using CloudSoft.Service.UseCases.MemberRoles.Commands.CreateMemberRole;
using CloudSoft.Service.UseCases.MemberRoles.Commands.DeleteMemberRole;
using CloudSoft.Service.UseCases.MemberRoles.Commands.UpdateMemberRole;
using CloudSoft.Service.UseCases.MemberRoles.Queries.GetAllMemberRole;
using CloudSoft.Service.UseCases.ProjectInfos.Commands.DeleteProjectInfo;
using CloudSoft.Service.UseCases.ProjectInfos.Commands.UpdateProjectInfo;
using CloudSoft.Service.UseCases.ProjectInfos.Queries.GetAllQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudSoft.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberRoleController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MemberRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateMemberRole(CreateMemberRoleCommands command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMemberRole( CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllMemberRolesCommand(),cancellationToken);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMemberRole(DeleteMemberRoleCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMemberRole(UpdateMemberRoleCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

    








    }
}
