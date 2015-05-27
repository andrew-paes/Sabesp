
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
    public interface IFormularioVideotecaDAL
    {	
        void Inserir(FormularioVideoteca entidade);
        void Atualizar(FormularioVideoteca entidade);
        void Excluir(FormularioVideoteca entidade);
        FormularioVideoteca Carregar(FormularioVideoteca entidade);
        List<FormularioVideoteca> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<FormularioVideoteca> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
