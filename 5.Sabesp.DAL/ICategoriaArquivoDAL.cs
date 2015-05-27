
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
    public interface ICategoriaArquivoDAL
    {	
        void Inserir(CategoriaArquivo entidade);
        void Atualizar(CategoriaArquivo entidade);
        void Excluir(CategoriaArquivo entidade);
        CategoriaArquivo Carregar(CategoriaArquivo entidade);
        List<CategoriaArquivo> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<CategoriaArquivo> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
