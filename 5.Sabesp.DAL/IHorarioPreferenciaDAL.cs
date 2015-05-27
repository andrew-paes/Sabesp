
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
    public interface IHorarioPreferenciaDAL
    {	
        void Inserir(HorarioPreferencia entidade);
        void Atualizar(HorarioPreferencia entidade);
        void Excluir(HorarioPreferencia entidade);
        HorarioPreferencia Carregar(HorarioPreferencia entidade);
        List<HorarioPreferencia> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<HorarioPreferencia> CarregarTodos();
        int TotalRegistros();	
		int TotalRegistros(IFilterHelper filtro);
	}
}
