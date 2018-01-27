namespace K19.Models
{
    public class Livro
    {
        public int LivroID { get; set; }
        public string Titulo { get; set; }
        public double Preco { get; set; }
        public int EditoraID { get; set; }
        public virtual Editora Editora { get; set; }
    }
}