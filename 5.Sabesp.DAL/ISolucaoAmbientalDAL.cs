
/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.94
'  Script criado por: Leonardo Alves Lindermann (lindermannla@ag2.com.br)
'  Gerado pelo MyGeneration versão # (???)
'
'===============================================================================
*/
using System;
using System.Text;
using System.Collections.Generic;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL
{
    public interface ISolucaoAmbientalIdiomaDAL
    {	
        void Inserir(SolucaoAmbientalIdioma entidade);
        void Atualizar(SolucaoAmbientalIdioma entidade);
        void Excluir(SolucaoAmbientalIdioma entidade);
        SolucaoAmbientalIdioma Carregar(SolucaoAmbientalIdioma entidade);
        List<SolucaoAmbientalIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<SolucaoAmbientalIdioma> RetornaTodosSite(int qtdRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<SolucaoAmbientalIdioma> CarregarTodos();
        SolucaoAmbientalIdioma CarregarToSite(int infograficoId);
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
