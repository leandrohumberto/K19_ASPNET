using EF.Contexts;
using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF.Repositorios
{
    class ReceitaRepositorio
    {
        private GranaContext _context;

        public ReceitaRepositorio(GranaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Adiciona(Receita despesa) => _context.Receitas.Add(despesa);

        public void Remove(Receita despesa) => _context.Receitas.Remove(despesa);

        public double? SomaReceitasAte(DateTime data) => (from r in _context.Receitas
                                                          where r.Data <= data
                                                          select r.Valor).ToList().Sum();

        public double? SomaReceitas(DateTime dataInicial, DateTime dataFinal) => (from r in _context.Receitas
                                                                                  where r.Data >= dataInicial && r.Data <= dataFinal
                                                                                  select r.Valor).Sum();

        public List<Receita> BuscaPorPeriodo(DateTime dataInicial, DateTime dataFinal) => (from r in _context.Receitas
                                                                                           where r.Data >= dataInicial && r.Data <= dataFinal
                                                                                           select r).ToList();

        public List<Receita> BuscaPorTipo(string tipoReceita) => (from r in _context.Receitas
                                                                  where tipoReceita != null && tipoReceita.Equals(r.Tipo)
                                                                  select r).ToList();

        public List<Receita> BuscaRecentes() => (from r in _context.Receitas
                                                 orderby r.Data descending
                                                 select r).Take(10).ToList();
    }
}
