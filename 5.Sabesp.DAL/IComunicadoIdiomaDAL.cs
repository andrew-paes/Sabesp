
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
    public interface IComunicadoIdiomaDAL
    {
        void Inserir(ComunicadoIdioma entidade);
        void Atualizar(ComunicadoIdioma entidade);
        void Excluir(ComunicadoIdioma entidade);
        ComunicadoIdioma Carregar(ComunicadoIdioma entidade);
        List<ComunicadoIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro);
        List<ComunicadoIdioma> CarregarTodos();
        int TotalRegistros();
        int TotalRegistros(IFilterHelper filtro);
    }
}
