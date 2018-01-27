using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace K19.Models
{
    public class K19Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public K19Context() : base("K19")
        {
        }

        public System.Data.Entity.DbSet<K19.Models.Editora> Editoras { get; set; }
        public System.Data.Entity.DbSet<K19.Models.Livro> Livros { get; set; }
    }
}
