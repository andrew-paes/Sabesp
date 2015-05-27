
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
    public interface IFaqItemIdiomaDAL
    {	
        void Inserir(FaqItemIdioma entidade);
        void Atualizar(FaqItemIdioma entidade);
        void Excluir(FaqItemIdioma entidade);
        FaqItemIdioma Carregar(FaqItemIdioma entidade);
        List<FaqItemIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<FaqItemIdioma> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
