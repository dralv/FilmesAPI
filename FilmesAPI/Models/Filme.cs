using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public  class Filme
    {
        public  int id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public  string Titulo { get; set; }
        [Required(ErrorMessage ="O campo diretor é obrigatória")]
        public  string Diretor { get; set; }
        [StringLength(30, ErrorMessage ="O gênero não deve ultrapassar 30 caracteres")]
        public  string Genero { get; set; }
        [Range(1,600,ErrorMessage ="A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public  int Duracao { get; set; }
    }
}
