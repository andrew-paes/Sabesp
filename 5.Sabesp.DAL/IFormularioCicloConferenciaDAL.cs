
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
    public interface IFormularioCicloConferenciaDAL
    {	
        void Inserir(FormularioCicloConferencia entidade);
        void Atualizar(FormularioCicloConferencia entidade);
        void Excluir(FormularioCicloConferencia entidade);
        FormularioCicloConferencia Carregar(FormularioCicloConferencia entidade);
        List<FormularioCicloConferencia> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FormularioCicloConferencia> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
