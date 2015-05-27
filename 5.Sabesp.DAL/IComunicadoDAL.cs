
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
    public interface IComunicadoDAL
    {
        void Inserir(Comunicado entidade);
        void Atualizar(Comunicado entidade);
        void Excluir(Comunicado entidade);
        Comunicado Carregar(Comunicado entidade);
        List<Comunicado> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<Comunicado> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<Comunicado> CarregarTodos();
        List<Comunicado> CarregarTagged(int tagId); 
        int TotalRegistros();
        int TotalRegistros(IFilterHelper filtro);
        Comunicado CarregarToSite(int comunicadoId);
		List<Comunicado> CarregarPorRegiao(int qtdComunicados, int regiaoId);
    }
}
