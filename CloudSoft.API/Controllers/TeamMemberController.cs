using CloudSoft.Service.UseCases.ProjectInfos.Commands.CreateProjectInfo;
using CloudSoft.Service.UseCases.ProjectInfos.Commands.DeleteProjectInfo;
using CloudSoft.Service.UseCases.ProjectInfos.Commands.UpdateProjectInfo;
using CloudSoft.Service.UseCases.ProjectInfos.Queries.GetAllQueries;
using CloudSoft.Service.UseCases.TeamMembers.Commands.CreateTeam;
using CloudSoft.Service.UseCases.TeamMembers.Commands.DeleteTeam;
using CloudSoft.Service.UseCases.TeamMembers.Queries.GetAllTeamMember;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudSoft.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TeamMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateInfo(CreateTeamMembersCommands command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(DeleteTeamMemberCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateTeamMemberCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllTeamMemberCommand(), cancellationToken);
            return Ok(result);
        }

    }
}
