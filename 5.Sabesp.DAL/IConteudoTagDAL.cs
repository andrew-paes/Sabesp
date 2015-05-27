
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
    public interface IConteudoTagDAL
    {
        void Inserir(ConteudoTag entidade);
        void Atualizar(ConteudoTag entidade);
        void Excluir(ConteudoTag entidade);
        ConteudoTag Carregar(ConteudoTag entidade);
        IList<ConteudoTag> CarregarTodos(int registrosPagina, int numeroPagina, string ordem, string ordemOrientacao, IFilterHelper filtro);
        IList<ConteudoTag> CarregarTodos();
        int TotalRegistros();
        int TotalRegistros(IFilterHelper filtro);
    }
}

