
/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.93
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
	public interface IPodcastIdiomaDAL
	{
		void Inserir(PodcastIdioma entidade);
		void Atualizar(PodcastIdioma entidade);
		void Excluir(PodcastIdioma entidade);
		PodcastIdioma Carregar(PodcastIdioma entidade);
		List<PodcastIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
		List<PodcastIdioma> CarregarTodos();
		int TotalRegistros();
		int TotalRegistros(IFilterHelper filtro);
	}
}