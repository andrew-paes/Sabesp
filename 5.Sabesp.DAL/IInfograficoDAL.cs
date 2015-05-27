
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
    public interface IInfograficoDAL
    {	
        void Inserir(Infografico entidade);
        void Atualizar(Infografico entidade);
        void Excluir(Infografico entidade);
        Infografico Carregar(Infografico entidade);
        List<Infografico> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Infografico> RetornaTodosSite(int qtdRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Infografico> CarregarTodos();
        Infografico CarregarToSite(int infograficoId);
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
