
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
    public interface IProdutoTipoDAL
    {	
        void Inserir(ProdutoTipo entidade);
        void Atualizar(ProdutoTipo entidade);
        void Excluir(ProdutoTipo entidade);
        ProdutoTipo Carregar(ProdutoTipo entidade);
        List<ProdutoTipo> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<ProdutoTipo> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
