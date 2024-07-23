using CloudSoft.Data.Entities;
using CloudSoft.Service.UseCases.ProjectInfos.Commands.CreateProjectInfo;
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
    public class ProjectInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateInfo(CreateProjectInfoCommand command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command,cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(DeleteProjectInfoCommand command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectInfoCommand command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command ,cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject(CancellationToken cancellationToken)
        {
          var result = await _mediator.Send(new GetAllQueryCommand(),cancellationToken);
            return Ok(result);
        }




    }
}
