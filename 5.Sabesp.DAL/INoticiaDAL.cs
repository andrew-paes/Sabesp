
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
    public interface INoticiaDAL
    {	
        void Inserir(Noticia entidade);
        void Atualizar(Noticia entidade);
        void Excluir(Noticia entidade);
        Noticia Carregar(Noticia entidade);
        Noticia CarregarToSite(int noticiaId);
        List<Noticia> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Noticia> CarregarTodos();
        List<Noticia> CarregarUltimasNoticias(int qtdNoticias, IFilterHelper filtro);
        List<Noticia> CarregarUltimasNoticias(int qtdNoticias, List<Noticia> noticiasJaExibidas);
        List<Noticia> CarregarMaisVistos(int qtdNoticias);
        List<Noticia> CarregarTagged(int tagId);        
        List<Noticia> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
		List<Noticia> CarregarPorRegiao(int qtdNoticias, int regiaoId);
	}
}
