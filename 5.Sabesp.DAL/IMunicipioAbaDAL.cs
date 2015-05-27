
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
    public interface IMunicipioAbaDAL
    {	
        void Inserir(MunicipioAba entidade);
        void Atualizar(MunicipioAba entidade);
		void Excluir(MunicipioAba entidade);
		void ExcluirRelacionados(Municipio entidade);
        MunicipioAba Carregar(MunicipioAba entidade);
        List<MunicipioAba> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<MunicipioAba> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
