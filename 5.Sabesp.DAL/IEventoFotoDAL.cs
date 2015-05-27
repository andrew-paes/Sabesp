
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
    public interface IEventoFotoDAL
    {	
        void Inserir(EventoFoto entidade);
        void Atualizar(EventoFoto entidade);
        void Excluir(EventoFoto entidade);
        EventoFoto Carregar(EventoFoto entidade);
        List<EventoFoto> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<EventoFoto> CarregarTodos();
		List<EventoFoto> CarregarFotos(int entidadeId);
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
