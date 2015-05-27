
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
	public interface IControleIdiomaDAL
	{
		void Inserir(ControleIdioma entidade);
		void Atualizar(ControleIdioma entidade);
		void Excluir(ControleIdioma entidade);
		ControleIdioma Carregar(ControleIdioma entidade);
		List<ControleIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
		List<ControleIdioma> CarregarTodos();
		int TotalRegistros();
		int TotalRegistros(IFilterHelper filtro);
		ControleIdioma CarregarToSite(int controleIdiomaId, int idiomaId);
	}
}
