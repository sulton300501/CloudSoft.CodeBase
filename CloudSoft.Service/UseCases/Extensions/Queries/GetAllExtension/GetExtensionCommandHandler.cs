using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Extensions.Queries.GetAllExtension
{
    public class GetExtensionCommandHandler : IRequestHandler<GetAllExtensionCommand, IEnumerable<ExtensionsName>>
    {
        private readonly IApplicationDbContext _context;

        public GetExtensionCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<IEnumerable<ExtensionsName>> Handle(GetAllExtensionCommand request, CancellationToken cancellationToken)
        {
            
            return await _context.Extensions.ToListAsync(cancellationToken);
        }
    }
}
