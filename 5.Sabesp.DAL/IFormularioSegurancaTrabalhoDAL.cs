
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
    public interface IFormularioSegurancaTrabalhoDAL
    {	
        void Inserir(FormularioSegurancaTrabalho entidade);
        void Atualizar(FormularioSegurancaTrabalho entidade);
        void Excluir(FormularioSegurancaTrabalho entidade);
        FormularioSegurancaTrabalho Carregar(FormularioSegurancaTrabalho entidade);
        List<FormularioSegurancaTrabalho> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FormularioSegurancaTrabalho> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
