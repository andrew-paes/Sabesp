
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
    public interface INoticiaImagemDAL
    {	
        void Inserir(NoticiaImagem entidade);
        void Atualizar(NoticiaImagem entidade);
        void Excluir(NoticiaImagem entidade);
        NoticiaImagem Carregar(NoticiaImagem entidade);
        List<NoticiaImagem> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<NoticiaImagem> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
		List<NoticiaImagem> CarregarToSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
	}
}
