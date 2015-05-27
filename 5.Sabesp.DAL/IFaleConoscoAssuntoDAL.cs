
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
    public interface IFaleConoscoAssuntoDAL
    {	
        void Inserir(FaleConoscoAssunto entidade);
        void Atualizar(FaleConoscoAssunto entidade);
        void Excluir(FaleConoscoAssunto entidade);
        FaleConoscoAssunto Carregar(FaleConoscoAssunto entidade);
        List<FaleConoscoAssunto> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FaleConoscoAssunto> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
