
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
    public interface ITagDAL
    {
        void Inserir(Tag entidade);
        void Atualizar(Tag entidade);
        void Excluir(Tag entidade);
        Tag Carregar(int tagId);
        Tag Carregar(string tag);
        Tag Carregar(Tag entidade);
        List<Tag> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro);
        List<Tag> CarregarTodos();
        List<Tag> CarregarTagsDeNoticias(Idioma idioma);
        List<Tag> CarregarTagsDeEventos(Idioma idioma);
        List<Tag> CarregarTagsDeComunicados(Idioma idioma);
        List<Tag> CarregarTagsDePodcasts(Idioma idioma);
        List<Tag> CarregarTagsDeVideos(Idioma idioma);
        int TotalRegistros();
        int TotalRegistros(IFilterHelper filtro);
    }
}
