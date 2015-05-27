
/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.93
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
    public interface IReleaseImagemDAL
    {	
        void Inserir(ReleaseImagem entidade);
        void Atualizar(ReleaseImagem entidade);
		void Excluir(ReleaseImagem entidade);
		void ExcluirRelacionado(Release entidade);
        ReleaseImagem Carregar(ReleaseImagem entidade);
        List<ReleaseImagem> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<ReleaseImagem> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
