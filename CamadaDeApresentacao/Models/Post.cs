using System;

namespace CamadaDeApresentacao.Models
{
    public class Post
    {
        public string Autor { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Texto { get; set; }
    }
}