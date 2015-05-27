
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
    public interface IConteudoAvaliacaoDAL
    {	
        void Inserir(ConteudoAvaliacao entidade);
        void Atualizar(ConteudoAvaliacao entidade);
        void Excluir(ConteudoAvaliacao entidade);
        ConteudoAvaliacao Carregar(ConteudoAvaliacao entidade);
        List<ConteudoAvaliacao> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<ConteudoAvaliacao> CarregarTodos();
        ConteudoAvaliacao CarregarToSite(int conteudoId);
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
