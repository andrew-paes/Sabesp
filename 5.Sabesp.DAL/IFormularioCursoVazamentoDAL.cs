
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
    public interface IFormularioCursoVazamentoDAL
    {	
        void Inserir(FormularioCursoVazamento entidade);
        void Atualizar(FormularioCursoVazamento entidade);
        void Excluir(FormularioCursoVazamento entidade);
        FormularioCursoVazamento Carregar(FormularioCursoVazamento entidade);
        List<FormularioCursoVazamento> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FormularioCursoVazamento> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
