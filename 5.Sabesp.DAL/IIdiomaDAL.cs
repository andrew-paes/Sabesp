
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
    public interface IIdiomaDAL
    {	
        void Inserir(Idioma entidade);
        void Atualizar(Idioma entidade);
        void Excluir(Idioma entidade);
        Idioma Carregar(Idioma entidade);
        List<Idioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Idioma> CarregarTodos();
        List<Idioma> CarregarIdiomasSemSolucaoAmbiental();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
