
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
    public interface IConteudoHitsDAL
    {	
        void Inserir(ConteudoHits entidade);
        void Atualizar(ConteudoHits entidade);
        void Excluir(ConteudoHits entidade);
        ConteudoHits Carregar(ConteudoHits entidade);
        List<ConteudoHits> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<ConteudoHits> CarregarTodos();
        ConteudoHits CarregarToSite(int conteudoId);
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
