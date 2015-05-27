
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
    public interface IReleaseImagemComentarioDAL
    {	
        void Inserir(ReleaseImagemComentario entidade);
        void Atualizar(ReleaseImagemComentario entidade);
        void Excluir(ReleaseImagemComentario entidade);
        ReleaseImagemComentario Carregar(ReleaseImagemComentario entidade);
        List<ReleaseImagemComentario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<ReleaseImagemComentario> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
