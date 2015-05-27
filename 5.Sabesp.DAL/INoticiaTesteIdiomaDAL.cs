
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
    public interface INoticiaTesteIdiomaDAL
    {	
        void Inserir(NoticiaTesteIdioma entidade);
        void Atualizar(NoticiaTesteIdioma entidade);
        void Excluir(NoticiaTesteIdioma entidade);
        NoticiaTesteIdioma Carregar(NoticiaTesteIdioma entidade);
        List<NoticiaTesteIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<NoticiaTesteIdioma> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
