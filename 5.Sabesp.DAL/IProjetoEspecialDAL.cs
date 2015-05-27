
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
    public interface IProjetoEspecialDAL
    {	
        void Inserir(ProjetoEspecial entidade);
        void Atualizar(ProjetoEspecial entidade);
        void Excluir(ProjetoEspecial entidade);
        ProjetoEspecial Carregar(ProjetoEspecial entidade);
        List<ProjetoEspecial> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<ProjetoEspecial> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
