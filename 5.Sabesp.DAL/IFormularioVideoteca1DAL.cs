
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
    public interface IFormularioVideoteca1DAL
    {	
        void Inserir(FormularioVideoteca1 entidade);
        void Atualizar(FormularioVideoteca1 entidade);
        void Excluir(FormularioVideoteca1 entidade);
        FormularioVideoteca1 Carregar(FormularioVideoteca1 entidade);
        List<FormularioVideoteca1> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FormularioVideoteca1> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
