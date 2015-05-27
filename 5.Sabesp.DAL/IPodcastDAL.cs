
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
	public interface IPodcastDAL
	{
		void Inserir(Podcast entidade);
		void Atualizar(Podcast entidade);
		void Excluir(Podcast entidade);
		Podcast Carregar(Podcast entidade);
		Podcast CarregarToSite(int entidadeId);
		Podcast CarregarToSite(int entidadeId, bool bancoAudio);
		List<Podcast> CarregarMaisVistos(int qtdPodcasts);
		List<Podcast> CarregarMaisVistos(int qtdPodcasts, bool bancoAudio);
		List<Podcast> CarregarMaisRecentes(int qtdPodcasts);
		List<Podcast> CarregarMaisRecentes(int qtdPodcasts, bool bancoAudio);
		List<Podcast> CarregarMaisRecentes(int qtdPodcasts, Podcast entidade);
		List<Podcast> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
		List<Podcast> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
		List<Podcast> CarregarTodos();
		List<Podcast> CarregarTodos(bool bancoAudio);
		List<Podcast> CarregarTagged(int tagId);
		List<Podcast> CarregarTagged(int tagId, bool bancoAudio);
		int TotalRegistros();
		int TotalRegistros(IFilterHelper filtro);
		List<Podcast> CarregarPorRegiao(int qtdPodcasts, int regiaoId);
		List<Podcast> CarregarPorRegiao(int qtdPodcasts, int regiaoId, bool bancoAudio);
	}
}