using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculasApi.DTOs;
using peliculasApi.Entity;

namespace peliculasApi.Controllers
{
    [ApiController]
    [Route("ApiPelis/genre")]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public GenreController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GenreDTO>> Get()
        {
            var genre = await context.Genres.ToListAsync();
            return mapper.Map<List<GenreDTO>>(genre);
        }

        [HttpGet]
        [Route("{id:int}", Name = "ObtenerGenre")]
        public async Task<ActionResult<GenreDTO>> Get(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genre == null)
            {
                return NotFound();

            }

            var genderId = mapper.Map<GenreDTO>(genre);

            return genderId;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var exist = await context.Genres.AnyAsync(context => context.Name == genreCreationDTO.Name);

            if (exist)
            {
                return BadRequest($"El genero de {genreCreationDTO.Name} ya fue agregado");
            }


            var genreName = mapper.Map<Genre>(genreCreationDTO);
            context.Add(genreName);
            await context.SaveChangesAsync();
            var genreDTO = mapper.Map<GenreDTO>(genreName);

            return new CreatedAtRouteResult("ObtenerGenre", new { id = genreDTO.Id, Name = genreDTO.Name });

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            context.Add(genre);
            context.Entry(genre).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Genres.AnyAsync(x=> x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            context.Remove(new Genre { Id = id});
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
