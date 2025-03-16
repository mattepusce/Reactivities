using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries
{
    // Creare a livello Application una cartella per ogni entità del dominio
    // all'interno di ciascuna cartella creare cartelle per i comandi e le query
    // all'interno di ciascuna cartella creare una classe per ciascun comando o query
    public class GetActivityList
    {
        public class Query : IRequest<List<Activity>> {}
        public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
        {
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
