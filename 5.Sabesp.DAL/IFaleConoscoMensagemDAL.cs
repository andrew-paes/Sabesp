
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
    public interface IFaleConoscoMensagemDAL
    {	
        void Inserir(FaleConoscoMensagem entidade);
        void Atualizar(FaleConoscoMensagem entidade);
        void Excluir(FaleConoscoMensagem entidade);
        FaleConoscoMensagem Carregar(FaleConoscoMensagem entidade);
        List<FaleConoscoMensagem> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FaleConoscoMensagem> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
