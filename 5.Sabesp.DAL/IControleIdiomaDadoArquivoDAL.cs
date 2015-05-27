
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
    public interface IControleIdiomaDadoArquivoDAL
    {	
        void Inserir(ControleIdiomaDadoArquivo entidade);
        void Atualizar(ControleIdiomaDadoArquivo entidade);
        void Excluir(ControleIdiomaDadoArquivo entidade);
        ControleIdiomaDadoArquivo Carregar(ControleIdiomaDadoArquivo entidade);
        List<ControleIdiomaDadoArquivo> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<ControleIdiomaDadoArquivo> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
