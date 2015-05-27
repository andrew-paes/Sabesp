
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
    public interface IVideoDAL
    {	
        void Inserir(Video entidade);
        void Atualizar(Video entidade);
        void Excluir(Video entidade);
        Video Carregar(Video entidade);
		Video CarregarToSite(int videoId);
        List<Video> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Video> CarregarTodos();
		List<Video> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Video> CarregarMaisVistos(int qtdVideos);
        List<Video> CarregarTagged(int tagId);
        List<Video> CarregarTagged(int qtdRegistros, string palavra);
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
		List<Video> CarregarPorRegiao(int qtdVideos, int regiaoId);
	}
}
