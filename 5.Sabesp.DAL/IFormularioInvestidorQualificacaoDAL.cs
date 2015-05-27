
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
    public interface IFormularioInvestidorQualificacaoDAL
    {	
        void Inserir(FormularioInvestidorQualificacao entidade);
        void Atualizar(FormularioInvestidorQualificacao entidade);
        void Excluir(FormularioInvestidorQualificacao entidade);
        FormularioInvestidorQualificacao Carregar(FormularioInvestidorQualificacao entidade);
        List<FormularioInvestidorQualificacao> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FormularioInvestidorQualificacao> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
