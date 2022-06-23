using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculasApi.DTOs;
using peliculasApi.Entity;

namespace peliculasApi.Controllers
{
    [ApiController]
    [Route("ApiPelis/actor")]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public ActorController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ActorDTO>> Get()
        {
            var actor = await context.Actors.ToListAsync();
            return mapper.Map<List<ActorDTO>>(actor);
        }

        [HttpGet]
        [Route("{id}", Name = "ObtenerActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var actor = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (actor == null)
            {
                return NotFound();

            }

            var actorId = mapper.Map<ActorDTO>(actor);

            return actorId;
        }



        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreationDTO actorCreationDTO )
        {
            var actor = await context.Actors.AnyAsync(x=> x.Name == actorCreationDTO.Name);

            if (actor)
            {
                return BadRequest($"El actor {actorCreationDTO.Name} ya existe");
            }

            var actorM = mapper.Map<Actor>(actorCreationDTO);
            context.Add(actorM);
            //await context.SaveChangesAsync();
            var actorDTO = mapper.Map<ActorDTO>(actorM);

            return new CreatedAtRouteResult("ObtenerActor", 
                new { id = actorM.Id}, actorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] ActorCreationDTO actorCreationDTO)
        {
            var actor = mapper.Map<Actor>(actorCreationDTO);
            actor.Id = id;
            context.Add(actor);
            context.Entry(actor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Actors.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            context.Remove(new Actor { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
