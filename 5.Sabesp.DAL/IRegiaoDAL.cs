
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
    public interface IRegiaoDAL
    {	
        void Inserir(Regiao entidade);
        void InserirRelacionado(Regiao entidade, int idMunicipio);
        void Atualizar(Regiao entidade);
        void Excluir(Regiao entidade);
        void ExcluirRelacionado(int entidade);
		void ExcluirRelacionados(Regiao entidade);
		void ExcluirConteudoRelacionado(Regiao entidade);
        Regiao Carregar(Regiao entidade);
        List<Regiao> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<Regiao> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
        int TotalRegistrosRelacionado(int regiaoId, int municipioId);
        int TotalRegistrosRelacionadoConteudo(int regiaoId, int conteudoId);
		List<Regiao> CarregarPorMunicipio(int municipioId);
		List<Municipio> GetMunicipios(int regiaoId);
	}
}
