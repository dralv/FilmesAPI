using FilmesAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace FilmesAPI.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public object Cinemas { get; set; }
    }
}
