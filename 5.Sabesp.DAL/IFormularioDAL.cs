
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
    public interface IFormularioDAL
    {	
        void Inserir(Formulario entidade);
        void Atualizar(Formulario entidade);
        void Excluir(Formulario entidade);
        Formulario Carregar(Formulario entidade);
        List<Formulario> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<Formulario> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
		int TotalRegistrosRelacionado(int contatoId, int formularioId);
		void InserirRelacionado(int contatoId, int formularioId);
		void ExcluirRelacionado(int entidade);
	}
}
