
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
    public interface IFormularioInvestidorDAL
    {	
        void Inserir(FormularioInvestidor entidade);
        void Atualizar(FormularioInvestidor entidade);
        void Excluir(FormularioInvestidor entidade);
        FormularioInvestidor Carregar(FormularioInvestidor entidade);
        List<FormularioInvestidor> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FormularioInvestidor> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
