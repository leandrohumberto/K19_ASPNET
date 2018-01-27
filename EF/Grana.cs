using EF.Contexts;
using EF.Telas;
using System;

namespace EF
{
    class Grana
    {
        static void Main(string[] args)
        {
            using (GranaContext context = new GranaContext())
            {
                // Menu principal
                TelaMenu principal = new TelaMenu("Menu Pincipal");

                TelaMenu relatorios = new TelaMenu("Relatórios");
                TelaMenu receitas = new TelaMenu("Receitas");
                TelaMenu despesas = new TelaMenu("Despesas");
                TelaGeraDados geraDados = new TelaGeraDados(principal, context);
                TelaLimpaDados limpaDados = new TelaLimpaDados(principal, context);
                TelaSair sair = new TelaSair();

                principal.AdicionaFilha(relatorios);
                principal.AdicionaFilha(receitas);
                principal.AdicionaFilha(despesas);
                principal.AdicionaFilha(geraDados);
                principal.AdicionaFilha(limpaDados);
                principal.AdicionaFilha(sair);

                // Relatórios
                TelaRelatorioConsolidado relatorioConsolidado = new TelaRelatorioConsolidado(relatorios, context);
                TelaRelatorioMensal relatorioMensal = new TelaRelatorioMensal(relatorios, context);
                TelaRelatorioPesonalizado relatorioPesonalizado = new TelaRelatorioPesonalizado(relatorios, context);

                relatorios.AdicionaFilha(relatorioConsolidado);
                relatorios.AdicionaFilha(relatorioMensal);
                relatorios.AdicionaFilha(relatorioPesonalizado);
                relatorios.AdicionaFilha(principal);

                // Receitas
                TelaReceitaAdicionar receitaAdicionar = new TelaReceitaAdicionar(receitas, context);
                TelaMenu receitaConsultar = new TelaMenu("Consultar");

                receitas.AdicionaFilha(receitaAdicionar);
                receitas.AdicionaFilha(receitaConsultar);
                receitas.AdicionaFilha(principal);

                // Receitas - Consultar
                TelaReceitaConsultaPeriodo receitaConsultaPeriodo = new TelaReceitaConsultaPeriodo(receitaConsultar, context);
                TelaReceitaConsultaRecentes receitaConsultaRecentes = new TelaReceitaConsultaRecentes(receitaConsultar, context);
                TelaReceitaConsultaTipo receitaConsultaTipo = new TelaReceitaConsultaTipo(receitaConsultar, context);

                receitaConsultar.AdicionaFilha(receitaConsultaPeriodo);
                receitaConsultar.AdicionaFilha(receitaConsultaRecentes);
                receitaConsultar.AdicionaFilha(receitaConsultaTipo);
                receitaConsultar.AdicionaFilha(receitas);

                // Despesas
                TelaDespesaAdicionar despesaAdicionar = new TelaDespesaAdicionar(despesas, context);
                TelaMenu despesaConsultar = new TelaMenu("Consultar");

                despesas.AdicionaFilha(despesaAdicionar);
                despesas.AdicionaFilha(despesaConsultar);
                despesas.AdicionaFilha(principal);

                // Despesas - Consultar
                TelaDespesaConsultaPeriodo despesaConsultaPeriodo = new TelaDespesaConsultaPeriodo(despesaConsultar, context);
                TelaDespesaConsultaRecentes despesaConsultaRecentes = new TelaDespesaConsultaRecentes(despesaConsultar, context);
                TelaDespesaConsultaTipo despesaConsultaTipo = new TelaDespesaConsultaTipo(despesaConsultar, context);

                despesaConsultar.AdicionaFilha(despesaConsultaPeriodo);
                despesaConsultar.AdicionaFilha(despesaConsultaRecentes);
                despesaConsultar.AdicionaFilha(despesaConsultaTipo);
                despesaConsultar.AdicionaFilha(despesas);

                ITela atual = principal;

                while (atual != null)
                {
                    atual = atual.Mostra();

                    if (context.ChangeTracker.HasChanges())
                        context.SaveChanges();

                    Console.Clear();
                }
            }
        }
    }
}
