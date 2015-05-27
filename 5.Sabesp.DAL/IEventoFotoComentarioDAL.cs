
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
    public interface IEventoFotoComentarioDAL
    {	
        void Inserir(EventoFotoComentario entidade);
        void Atualizar(EventoFotoComentario entidade);
        void Excluir(EventoFotoComentario entidade);
        EventoFotoComentario Carregar(EventoFotoComentario entidade);
        List<EventoFotoComentario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<EventoFotoComentario> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
