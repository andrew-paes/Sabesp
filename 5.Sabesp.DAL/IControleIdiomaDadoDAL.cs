
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
    public interface IControleIdiomaDadoDAL
    {	
        void Inserir(ControleIdiomaDado entidade);
        void Atualizar(ControleIdiomaDado entidade);
        void Excluir(ControleIdiomaDado entidade);
		void ExcluirRelacionados(ControleIdioma entidade);
        ControleIdiomaDado Carregar(ControleIdiomaDado entidade);
        List<ControleIdiomaDado> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<ControleIdiomaDado> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
