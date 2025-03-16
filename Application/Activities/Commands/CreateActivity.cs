using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class CreateActivity
    {
        public class Command : IRequest<Guid>
        {
            public required Activity Activity { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command, Guid>
        {
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                // non si usa AddAsync perché async deve essere usato per le operazioni che coinvolgono il db
                // la Add non modifica il db, quindi non c'è bisogno di async
                context.Activities.Add(request.Activity);
                await context.SaveChangesAsync(cancellationToken);

                return request.Activity.Id;
            }
        }
    }
}
