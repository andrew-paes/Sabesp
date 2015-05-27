
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
    public interface IMaterialImprensaIdiomaDAL
    {	
        void Inserir(MaterialImprensaIdioma entidade);
        void Atualizar(MaterialImprensaIdioma entidade);
        void Excluir(MaterialImprensaIdioma entidade);
        MaterialImprensaIdioma Carregar(MaterialImprensaIdioma entidade);
        List<MaterialImprensaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<MaterialImprensaIdioma> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
