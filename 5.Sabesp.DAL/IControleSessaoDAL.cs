
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
    public interface IControleSessaoDAL
    {	
        void Inserir(ControleSessao entidade);
        void Atualizar(ControleSessao entidade);
        void Excluir(ControleSessao entidade);
        void Excluir(Secao entidade);
        ControleSessao Carregar(ControleSessao entidade);
		ControleSessao CarregarToSite(int dontroleSessaoId);
        List<ControleSessao> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<ControleSessao> CarregarTodos();
		List<ControleSessao> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
