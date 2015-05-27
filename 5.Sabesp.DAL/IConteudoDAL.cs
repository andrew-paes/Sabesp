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
using System.Data;

namespace Sabesp.DAL
{
    public interface IConteudoDAL
    {
        void Inserir(Conteudo entidade);
        void InserirRelacionado(Conteudo entidade, int regiaoId);
        void Atualizar(Conteudo entidade);
        void Excluir(Conteudo entidade);
        void ExcluirRelacionado(Conteudo entidade);
        Conteudo Carregar(Conteudo entidade);
        List<Conteudo> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<Conteudo> CarregarTodos();
        int TotalRegistros();
        int TotalRegistros(IFilterHelper filtro);
        DataTable RetornaConteudoRelacionado(int conteudoId);
    }
}
