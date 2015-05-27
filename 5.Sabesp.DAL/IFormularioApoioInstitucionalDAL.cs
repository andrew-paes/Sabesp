
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
    public interface IFormularioApoioInstitucionalDAL
    {	
        void Inserir(FormularioApoioInstitucional entidade);
        void Atualizar(FormularioApoioInstitucional entidade);
        void Excluir(FormularioApoioInstitucional entidade);
        FormularioApoioInstitucional Carregar(FormularioApoioInstitucional entidade);
        List<FormularioApoioInstitucional> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FormularioApoioInstitucional> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
