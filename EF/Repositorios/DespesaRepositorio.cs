using EF.Contexts;
using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF.Repositorios
{
    class DespesaRepositorio
    {
        private GranaContext _context;

        public DespesaRepositorio(GranaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Adiciona(Despesa despesa) => _context.Despesas.Add(despesa);

        public void Remove(Despesa despesa) => _context.Despesas.Remove(despesa);

        public double? SomaDespesasAte(DateTime data) => (from d in _context.Despesas
                                                          where d.Data <= data
                                                          select d.Valor).Sum();

        public double? SomaDespesas(DateTime dataInicial, DateTime dataFinal) => (from d in _context.Despesas
                                                                                  where d.Data >= dataInicial && d.Data <= dataFinal
                                                                                  select d.Valor).Sum();

        public List<Despesa> BuscaPorPeriodo(DateTime dataInicial, DateTime dataFinal) => (from d in _context.Despesas
                                                                                           where d.Data >= dataInicial && d.Data <= dataFinal
                                                                                           select d).ToList();

        public List<Despesa> BuscaPorTipo(string tipoDespesa) => (from d in _context.Despesas
                                                                  where tipoDespesa != null && tipoDespesa.Equals(d.Tipo)
                                                                  select d).ToList();

        public List<Despesa> BuscaRecentes() => (from d in _context.Despesas
                                                 orderby d.Data descending
                                                 select d).Take(10).ToList();
    }
}
