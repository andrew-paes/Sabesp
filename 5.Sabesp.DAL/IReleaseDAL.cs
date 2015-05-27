
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
    public interface IReleaseDAL
    {	
        void Inserir(Release entidade);
        void Atualizar(Release entidade);
        void Excluir(Release entidade);
        Release Carregar(Release entidade);
        List<Release> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Release> CarregarTodosSite(int qtdRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Release> CarregarTodos();
        List<Release> CarregarTagged(int tagId);
        List<Release> CarregarOutros(int qtdRegistros, int releaseId);
        Release CarregarToSite(int releaseId);    
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
