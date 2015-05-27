
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
    public interface IEventoDAL
    {	
        void Inserir(Evento entidade);
        void InserirRelacionado(EventoCategoria entidade, int eventoId, int idiomaId);
        void Atualizar(Evento entidade);
        void Excluir(Evento entidade);
        void ExcluirRelacionado(int eventoId, int idiomaId);
        Evento Carregar(Evento entidade);
        Evento CarregarToSite(int entidadeId);
        List<Evento> CarregarMaisVistos(int qtdEventos);
        List<Evento> CarregarProxEventos(int qtdRegistros);        
        List<Evento> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<Evento> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);     
        List<Evento> CarregarTodos();
        List<Evento> CarregarTagged(int tagId);            
        int TotalRegistros();
        int TotalRegistrosRelacionado(int eventoID, int eventoCategoriaId);
		int TotalRegistros(IFilterHelper filtro);
		List<Evento> CarregarPorRegiao(int qtdEventos, int regiaoId);
	}
}
