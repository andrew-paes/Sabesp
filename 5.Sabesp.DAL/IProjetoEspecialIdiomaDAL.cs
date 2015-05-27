
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
    public interface IProjetoEspecialIdiomaDAL
    {	
        void Inserir(ProjetoEspecialIdioma entidade);
        void Atualizar(ProjetoEspecialIdioma entidade);
        void Excluir(ProjetoEspecialIdioma entidade);
        ProjetoEspecialIdioma Carregar(ProjetoEspecialIdioma entidade);
        List<ProjetoEspecialIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<ProjetoEspecialIdioma> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
