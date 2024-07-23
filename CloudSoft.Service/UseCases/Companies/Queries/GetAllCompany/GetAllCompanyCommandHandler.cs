using CloudSoft.Data.Entities;
using CloudSoft.Service.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service.UseCases.Companies.Queries.GetAllCompany
{
    public class GetAllCompanyCommandHandler : IRequestHandler<GetAllCompanyCommand, IEnumerable<Company>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> Handle(GetAllCompanyCommand request, CancellationToken cancellationToken)
        {
          return await _context.Companies.ToListAsync(cancellationToken);
          
        }
    }
}

