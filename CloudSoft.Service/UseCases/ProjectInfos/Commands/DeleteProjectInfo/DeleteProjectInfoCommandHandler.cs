using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.ProjectInfos.Commands.DeleteProjectInfo
{
    public class DeleteProjectInfoCommandHandler : IRequestHandler<DeleteProjectInfoCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProjectInfoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProjectInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId);
          
            if (result == null)
            {
                return  false;
            }

             var natija = _context.Projects.Remove(result);
            return true;
            
            
            
        }
    }
}
