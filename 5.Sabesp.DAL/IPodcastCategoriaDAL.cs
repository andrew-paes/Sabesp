
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
	public interface IPodcastCategoriaDAL
	{
		void Inserir(PodcastCategoria entidade);
		void Atualizar(PodcastCategoria entidade);
		void Excluir(PodcastCategoria entidade);
		PodcastCategoria Carregar(PodcastCategoria entidade);
		List<PodcastCategoria> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
		List<PodcastCategoria> CarregarTodos();
		int TotalRegistros();
		int TotalRegistros(IFilterHelper filtro);
	}
}
