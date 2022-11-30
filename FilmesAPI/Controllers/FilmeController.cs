
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController: ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public void AdicionarFilme([FromBody] Filme filme)
        {
            filme.id = id++;
            filmes.Add(filme);
            
        }

        [HttpGet]
        public List<Filme> RecuperaFilmes()
        {
            return filmes;
        }
        [HttpGet("{id}")]
        public Filme RecuperarFilmesPorId(int id)
        {
            var filme  = filmes.Where(f=>f.id == id).FirstOrDefault();
            return filme;
        }
    }
}
