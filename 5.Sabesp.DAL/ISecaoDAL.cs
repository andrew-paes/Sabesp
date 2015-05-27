
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
    public interface ISecaoDAL
    {	
        void Inserir(Secao entidade);
        void Atualizar(Secao entidade);
        void Excluir(Secao entidade);
        Secao Carregar(Secao entidade);
        List<Secao> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Secao> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
        List<Secao> CarregarFilhos(int secaoIdPai);
		List<Secao> CarregarFilhos(int secaoIdPai, bool exibeNoMenu);
	}
}
