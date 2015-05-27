
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
    public interface IReleaseIdiomaDAL
    {	
        void Inserir(ReleaseIdioma entidade);
        void Atualizar(ReleaseIdioma entidade);
        void Excluir(ReleaseIdioma entidade);
        ReleaseIdioma Carregar(ReleaseIdioma entidade);
        List<ReleaseIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<ReleaseIdioma> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
