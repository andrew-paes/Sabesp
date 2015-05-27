
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
    public interface IProdutoTipoIdiomaDAL
    {	
        void Inserir(ProdutoTipoIdioma entidade);
        void Atualizar(ProdutoTipoIdioma entidade);
        void Excluir(ProdutoTipoIdioma entidade);
        ProdutoTipoIdioma Carregar(ProdutoTipoIdioma entidade);
        List<ProdutoTipoIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<ProdutoTipoIdioma> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
