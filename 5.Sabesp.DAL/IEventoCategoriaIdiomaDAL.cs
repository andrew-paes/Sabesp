
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
    public interface IEventoCategoriaIdiomaDAL
    {	
        void Inserir(EventoCategoriaIdioma entidade);
        void Atualizar(EventoCategoriaIdioma entidade);
        void Excluir(EventoCategoriaIdioma entidade);
        EventoCategoriaIdioma Carregar(EventoCategoriaIdioma entidade);
        List<EventoCategoriaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<EventoCategoriaIdioma> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
