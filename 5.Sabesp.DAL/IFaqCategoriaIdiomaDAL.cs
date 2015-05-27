
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
    public interface IFaqCategoriaIdiomaDAL
    {	
        void Inserir(FaqCategoriaIdioma entidade);
        void Atualizar(FaqCategoriaIdioma entidade);
        void Excluir(FaqCategoriaIdioma entidade);
        FaqCategoriaIdioma Carregar(FaqCategoriaIdioma entidade);
        List<FaqCategoriaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FaqCategoriaIdioma> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
