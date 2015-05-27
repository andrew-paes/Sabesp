
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
	public interface IContatoDAL
	{
		void Inserir(Contato entidade);
		void Atualizar(Contato entidade);
		void Excluir(Contato entidade);
		Contato Carregar(Contato entidade);
		List<Contato> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
		List<Contato> CarregarTodos();
		int TotalRegistros();
		int TotalRegistros(IFilterHelper filtro);
		List<Contato> Carregar(Formulario entidade);
	}
}
