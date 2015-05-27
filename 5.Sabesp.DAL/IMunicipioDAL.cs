
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
	public interface IMunicipioDAL
	{
		void Inserir(Municipio entidade);
		void Atualizar(Municipio entidade);
		void Excluir(Municipio entidade);
		void ExcluirRelacionados(Municipio entidade);
		Municipio Carregar(Municipio entidade);
		List<Municipio> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
		List<Municipio> CarregarTodos();
		List<Municipio> CarregarDifExiste();
		List<Municipio> CarregarDifExisteRegiao(int regiaoId);
		int TotalRegistros();
		int TotalRegistros(IFilterHelper filtro);
		int BuscarMunicipioId(string nomeMunicipio);
	}
}
