
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
	public interface IPodcastCategoriaIdiomaDAL
	{
		void Inserir(PodcastCategoriaIdioma entidade);
		void Atualizar(PodcastCategoriaIdioma entidade);
		void Excluir(PodcastCategoriaIdioma entidade);
		PodcastCategoriaIdioma Carregar(PodcastCategoriaIdioma entidade);
		List<PodcastCategoriaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
		List<PodcastCategoriaIdioma> CarregarTodos();
		int TotalRegistros();
		int TotalRegistros(IFilterHelper filtro);
	}
}
