using System;

namespace EF
{
    class ListaEditorasComEF
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                foreach (var editora in context.Editoras)
                {
                    Console.WriteLine("Editora {0} - {1} ", editora.Nome, editora.Email);
                }
            }
        }
    }
}
