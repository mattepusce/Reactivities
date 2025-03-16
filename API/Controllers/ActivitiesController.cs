using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController(AppDbContext context, IMediator mediator) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            //var res = await context.Activities.ToListAsync();
            //return res;

            // utilizzo di MediatR per ottenere la lista delle attività
            var res = await mediator.Send(new GetActivityList.Query());
            return res;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(Guid id)
        {
            var activity = await context.Activities.FindAsync(id);

            if (activity == null) return NotFound();

            return activity;
        }

    }
}
