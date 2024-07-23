using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.ProjectInfos.Queries.GetAllQueries
{
    public class GetAllQueryCommandHandler : IRequestHandler<GetAllQueryCommand, IEnumerable<ProjectInfo>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllQueryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectInfo>> Handle(GetAllQueryCommand request, CancellationToken cancellationToken)
        {
           
            return await _context.Projects.Include(x=>x.Extensions).ToListAsync(cancellationToken);


        }
    }
}
