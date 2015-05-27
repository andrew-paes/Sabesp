using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using System.Transactions;
using Sabesp.FilterHelper;
using Sabesp.BO;

namespace Sabesp.Data.Services
{
    public class TagService
    {
        private ITagDAL _tagDAL;

        public TagService() { }

        public ITagDAL TagDAL
        {
            get
            {
                if (_tagDAL == null)
                    _tagDAL = new TagADO();

                return _tagDAL;
            }
            set
            {
                _tagDAL = value;
            }
        }

        public int TotalRegistros(TagFH filtro)
        {
            return TagDAL.TotalRegistros(filtro);
        }

        public IList<Tag> RetornaTodos()
        {
            return TagDAL.CarregarTodos();
        }

        public IList<Tag> RetornaTodos(int registrosPorPagina, int numeroPagina, string ordemColunas, string ordemSentidos, TagFH filtro)
        {
            return TagDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public Tag Carregar(int tagId)
        {
            return TagDAL.Carregar(tagId);
        }

        public Tag Carregar(string tag)
        {
            return TagDAL.Carregar(tag);
        }

        public Tag Carregar(Tag entidade)
        {
            return TagDAL.Carregar(entidade);
        }

        /// <summary>
        /// Método que carrega toda as Tag associadas a notícias não exipiradas, podendo ser filtradas por um determinado idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <returns></returns>
        public List<Tag> CarregarTagsDeNoticias(Idioma idioma)
        {
            return TagDAL.CarregarTagsDeNoticias(idioma);
        }

        /// <summary>
        /// Método que carrega toda as Tag associadas a eventos, podendo ser filtradas por um determinado idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <returns></returns>
        public List<Tag> CarregarTagsDeEventos(Idioma idioma)
        {
            return TagDAL.CarregarTagsDeEventos(idioma);
        }

        /// <summary>
        /// Método que carrega toda as Tag associadas a comunicados não exipiradas, podendo ser filtradas por um determinado idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <returns></returns>
        public List<Tag> CarregarTagsDeComunicados(Idioma idioma)
        {
            return TagDAL.CarregarTagsDeComunicados(idioma);
        }

        /// <summary>
        /// Método que carrega toda as Tag associadas a podcasts, podendo ser filtradas por um determinado idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <returns></returns>
        public List<Tag> CarregarTagsDePodcasts(Idioma idioma)
        {
            return TagDAL.CarregarTagsDePodcasts(idioma);
        }

        /// <summary>
        /// Método que carrega toda as Tag associadas a videos, podendo ser filtradas por um determinado idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <returns></returns>
        public List<Tag> CarregarTagsDeVideos(Idioma idioma)
        {
            return TagDAL.CarregarTagsDeVideos(idioma);
        }

        public void Inserir(Tag entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                TagDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(Tag entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                TagDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Tag entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                TagDAL.Excluir(entidade);

                tScope.Complete();
            }
        }

        public void Relacionar(Conteudo entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                if (entidade.Tages != null && entidade.Tages.Count > 0)
                {
                    Tag entidadeTag = new Tag();
                    ConteudoTag entidadeConteudoTag = new ConteudoTag();

                    // Exclude all register from "ConteudoTag" that have conteudoId like parameter
                    entidadeConteudoTag.Conteudo = new Conteudo();
                    entidadeConteudoTag.Conteudo.ConteudoId = entidade.ConteudoId;
                    new ConteudoTagService().Excluir(entidadeConteudoTag);

                    // List all Tags from the form
                    foreach (Tag tag in entidade.Tages)
                    {
                        entidadeTag = new Tag();
                        entidadeConteudoTag = new ConteudoTag();

                        if (!String.IsNullOrEmpty(tag.Palavra))
                        {
                            // Search a Tag by word
                            entidadeTag = this.Carregar(tag.Palavra);

                            // Verify if Tag exist
                            if (entidadeTag != null && entidadeTag.TagId > 0)
                            {
                                // If Tag exist, tagId must be inserted in ConteudoTag
                                entidadeConteudoTag.Tag = new Tag();
                                entidadeConteudoTag.Tag.TagId = entidadeTag.TagId;
                                entidadeConteudoTag.Conteudo = new Conteudo();
                                entidadeConteudoTag.Conteudo.ConteudoId = entidade.ConteudoId;

                                new ConteudoTagService().Inserir(entidadeConteudoTag);
                            }
                            else
                            {
                                // If Tag not exist, Tag must be inserted in Tag
                                entidadeTag = new Tag();
                                entidadeTag.Palavra = tag.Palavra;
                                entidadeTag.Idioma = new Idioma();
                                entidadeTag.Idioma.IdiomaId = tag.Idioma.IdiomaId;
                                new TagService().Inserir(entidadeTag);

                                if (entidadeTag != null && entidadeTag.TagId > 0)
                                {
                                    entidadeConteudoTag.Tag = new Tag();
                                    entidadeConteudoTag.Tag.TagId = entidadeTag.TagId;
                                    entidadeConteudoTag.Conteudo = new Conteudo();
                                    entidadeConteudoTag.Conteudo.ConteudoId = entidade.ConteudoId;
                                    new ConteudoTagService().Inserir(entidadeConteudoTag);
                                }
                            }
                        }
                    }
                }

                tScope.Complete();
            }
        }
    }
}