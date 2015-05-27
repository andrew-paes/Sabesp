
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
    public interface INoticiaImagemComentarioDAL
    {	
        void Inserir(NoticiaImagemComentario entidade);
        void Atualizar(NoticiaImagemComentario entidade);
        void Excluir(NoticiaImagemComentario entidade);
        NoticiaImagemComentario Carregar(NoticiaImagemComentario entidade);
        List<NoticiaImagemComentario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<NoticiaImagemComentario> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
