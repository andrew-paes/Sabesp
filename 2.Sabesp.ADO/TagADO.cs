
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
using System.Data;
using System.Data.Common;

using System.Collections;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
    public class TagADO : ADOSuper, ITagDAL
    {
        /// <summary>
        /// Método que persiste um Tag.
        /// </summary>
        /// <param name="entidade">Tag contendo os dados a serem persistidos.</param>	
        public void Inserir(Tag entidade)
        {
            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            // Monta a string de insert.
            sbSQL.Append(" INSERT INTO Tag ");
            sbSQL.Append(" (palavra, hits, idiomaId) ");
            sbSQL.Append(" VALUES ");
            sbSQL.Append(" (@palavra, @hits, @idiomaId) ");

            sbSQL.Append(" ; SET @tagId = SCOPE_IDENTITY(); ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddOutParameter(command, "@tagId", DbType.Int32, 8);

            _db.AddInParameter(command, "@palavra", DbType.String, entidade.Palavra);

            _db.AddInParameter(command, "@hits", DbType.Int32, entidade.Hits);

            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);


            // Executa a query.
            _db.ExecuteNonQuery(command);

            entidade.TagId = Convert.ToInt32(_db.GetParameterValue(command, "@tagId"));
        }

        /// <summary>
        /// Método que atualiza os dados de um Tag.
        /// </summary>
        /// <param name="entidade">Tag contendo os dados a serem atualizados.</param>
        public void Atualizar(Tag entidade)
        {
            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            // Monta a string de atualização.
            sbSQL.Append(" UPDATE Tag SET ");
            sbSQL.Append(" palavra=@palavra, hits=@hits, idiomaId=@idiomaId ");
            sbSQL.Append(" WHERE tagId=@tagId ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Parâmetros
            _db.AddInParameter(command, "@tagId", DbType.Int32, entidade.TagId);
            _db.AddInParameter(command, "@palavra", DbType.String, entidade.Palavra);
            _db.AddInParameter(command, "@hits", DbType.Int32, entidade.Hits);
            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

            // Executa a query.
            _db.ExecuteNonQuery(command);

        }

        /// <summary>
        /// Método que remove um Tag da base de dados.
        /// </summary>
        /// <param name="entidade">Tag a ser excluído (somente o identificador é necessário).</param>		
        public void Excluir(Tag entidade)
        {
            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            sbSQL.Append("DELETE FROM Tag ");
            sbSQL.Append("WHERE tagId=@tagId ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@tagId", DbType.Int32, entidade.TagId);


            _db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Método que carrega um Tag.
        /// </summary>
        /// <param name="entidade">Tag a ser carregado (somente o identificador é necessário).</param>
        /// <returns>Tag</returns>
        public Tag Carregar(int tagId)
        {
            Tag entidade = new Tag();
            entidade.TagId = tagId;
            return Carregar(entidade);
        }

        public Tag Carregar(string tag)
        {
            Tag entidade = new Tag();
            entidade.Palavra = tag;
            return Carregar(entidade);
        }


        /// <summary>
        /// Método que carrega um Tag.
        /// </summary>
        /// <param name="entidade">Tag a ser carregado (somente o identificador é necessário).</param>
        /// <returns>Tag</returns>
        public Tag Carregar(Tag entidade)
        {
            Tag entidadeRetorno = null;

            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            sbSQL.Append("SELECT * FROM Tag WHERE");

            if (entidade.TagId > 0)
            {
                sbSQL.Append(" tagId = @tagId");
                command = _db.GetSqlStringCommand(sbSQL.ToString());
                _db.AddInParameter(command, "@tagId", DbType.Int32, entidade.TagId);
            }
            else
            {
                sbSQL.Append(" palavra = @palavra");
                command = _db.GetSqlStringCommand(sbSQL.ToString());
                _db.AddInParameter(command, "@palavra", DbType.String, entidade.Palavra);
            }

            IDataReader reader = _db.ExecuteReader(command);

            if (reader.Read())
            {
                entidadeRetorno = new Tag();
                PopulaTag(reader, entidadeRetorno);
            }
            reader.Close();

            return entidadeRetorno;
        }


        /// <summary>
        /// Método que retorna uma coleção de Tag.
        /// </summary>
        /// <param name="entidade">Conteudo relacionado(a) (somente o identificador é necessário).</param>		
        /// <returns>Retorna uma coleção de Tag.</returns>
        public List<Tag> Carregar(Conteudo entidade)
        {
            List<Tag> entidadesRetorno = new List<Tag>();

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT Tag.* FROM Tag INNER JOIN ConteudoTag ON Tag.tagId=ConteudoTag.tagId WHERE ConteudoTag.conteudoId=@conteudoId");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
            _db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.ConteudoId);

            IDataReader reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                Tag entidadeRetorno = new Tag();
                PopulaTag(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;

        }


        /// <summary>
        /// Método que retorna uma coleção de Tag.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
        ///  <returns>Retorna um List contendos Tag.</returns>
        public List<Tag> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
        {

            List<Tag> entidadesRetorno = new List<Tag>();

            StringBuilder sbSQL = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            StringBuilder sbOrder = new StringBuilder();
            DbCommand command;
            IDataReader reader;

            // Monta o "OrderBy"
            if (ordemColunas != null)
            {
                for (int i = 0; i < ordemColunas.Length; i++)
                {
                    if (sbOrder.Length > 0) { sbOrder.Append(", "); }
                    sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
                }
                if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }
            }
            else
            {
                sbOrder.Append(" ORDER BY tagId");
            }


            if (registrosPagina > 0)
            {

                //sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Tag");
                //if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
                //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Tag WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
                //} else {
                //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Tag ORDER BY " + orderBy + ")");				
                //}	
                sbSQL.Append("SELECT * FROM ( ");
                sbSQL.Append("SELECT Tag.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Tag ");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
                sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

            }
            else
            {
                sbSQL.Append("SELECT Tag.* FROM Tag ");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
                if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
            }

            command = _db.GetSqlStringCommand(sbSQL.ToString());
            reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                Tag entidadeRetorno = new Tag();
                PopulaTag(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;

        }

        /// <summary>
        /// Método que retorna todas os Tag existentes na base de dados.
        /// </summary>
        public List<Tag> CarregarTodos()
        {
            return CarregarTodos(0, 0, null, null, null);
        }

        /// <summary>
        /// Método que retorna o total de Tag na base de dados.
        /// </summary>
        /// <returns></returns>
        public int TotalRegistros()
        {
            return TotalRegistros(null);
        }

        /// <summary>
        /// Método que retorna o total de Tag na base de dados, aceita filtro.
        /// </summary>
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
        /// <returns></returns>
        public int TotalRegistros(IFilterHelper filtro)
        {
            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT COUNT(*) AS Total FROM Tag");

            if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
                sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Executa a query.

            int resultado = (int)_db.ExecuteScalar(command);


            return resultado;
        }

        /// <summary>
        /// Método que retorna popula um Tag baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">Tag a ser populado(.</param>
        public static void PopulaTag(IDataReader reader, Tag entidade)
        {
            if (reader["tagId"] != DBNull.Value)
                entidade.TagId = Convert.ToInt32(reader["tagId"].ToString());

            if (reader["palavra"] != DBNull.Value)
                entidade.Palavra = reader["palavra"].ToString();

            if (reader["hits"] != DBNull.Value)
                entidade.Hits = Convert.ToInt32(reader["hits"].ToString());

            if (reader["idiomaId"] != DBNull.Value)
            {
                entidade.Idioma = new Idioma();
                entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
            }
        }

        /// <summary>
        /// Método que retorna todas as Tags relacionadas a Notícias. Pode ser especificado o Idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <returns>Coleção de objetos do tipo Tag.</returns>
        public List<Tag> CarregarTagsDeNoticias(Idioma idioma)
        {

            return CarregarTagDeConteudoComValidade(idioma, "Noticia");
        }

        /// <summary>
        /// Método que retorna todas as Tags relacionadas a Notícias. Pode ser especificado o Idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Evento com id configurado.</param>
        /// <returns>Coleção de objetos do tipo Tag.</returns>
        public List<Tag> CarregarTagsDeEventos(Idioma idioma)
        {
            return CarregarTagDeConteudoSemValidade(idioma, "Evento");
        }

        /// <summary>
        /// Método que retorna todas as Tags relacionadas a Comunicados. Pode ser especificado o Idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <returns>Coleção de objetos do tipo Tag.</returns>
        public List<Tag> CarregarTagsDeComunicados(Idioma idioma)
        {
            return CarregarTagDeConteudoComValidade(idioma, "Comunicado");
        }

        /// <summary>
        /// Método que retorna todas as Tags relacionadas a Podcasts. Pode ser especificado o Idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Evento com id configurado.</param>
        /// <returns>Coleção de objetos do tipo Tag.</returns>
        public List<Tag> CarregarTagsDePodcasts(Idioma idioma)
        {
            return CarregarTagDeConteudoSemValidade(idioma, "Podcast");
        }

        /// <summary>
        /// Método que retorna todas as Tags relacionadas a Vídeos. Pode ser especificado o Idioma.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <returns>Coleção de objetos do tipo Tag.</returns>
        public List<Tag> CarregarTagsDeVideos(Idioma idioma)
        {

            return CarregarTagDeConteudoSemValidade(idioma, "Video");
        }

        /// <summary>
        /// Método que carregas as Tags de conteúdos sem prazo de validade.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <param name="nomeDaTabela">String contendo o nome da tabela.</param>
        /// <returns></returns>
        private List<Tag> CarregarTagDeConteudoSemValidade(Idioma idioma, string nomeDaTabela)
        {
            return CarregarTagDeConteudos(idioma, nomeDaTabela, false);
        }

        /// <summary>
        /// Método que carregas as Tags de conteúdos com prazo de validade.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <param name="nomeDaTabela">String contendo o nome da tabela.</param>
        /// <returns></returns>
        private List<Tag> CarregarTagDeConteudoComValidade(Idioma idioma, string nomeDaTabela)
        {
            return CarregarTagDeConteudos(idioma, nomeDaTabela, true);
        }

        /// <summary>
        /// Método que carregas as Tags de conteúdos sem prazo de validade.
        /// </summary>
        /// <param name="idioma">Objeto do tipo Idioma com id configurado.</param>
        /// <param name="nomeDaTabela">String contendo o nome da tabela.</param>
        /// <param name="comValidade">Booleano informando se deve ser feita ou não a checagem de validade do conteúdo.</param>
        /// <returns></returns>
        private List<Tag> CarregarTagDeConteudos(Idioma idioma, string nomeDaTabela, bool comValidade)
        {
            // Verifica os parâmetros.
            if (String.IsNullOrEmpty(nomeDaTabela))
                throw new ArgumentException("Nome da tabela não informado!");

            if (idioma==null)
                throw new ArgumentException("Idioma não informado!");

            if (idioma.IdiomaId<=0)
                throw new ArgumentException("Idioma inválido!");

            List<Tag> entidadesRetorno = new List<Tag>();
            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT DISTINCT T.* FROM Tag T");
            sbSQL.Append(" INNER JOIN ConteudoTag CT ON T.tagId = CT.tagId");
            sbSQL.Append(" INNER JOIN Conteudo C ON C.conteudoId = CT.conteudoId");
            sbSQL.AppendFormat(" INNER JOIN {0} P	ON P.{0}Id = C.conteudoId", nomeDaTabela);
            sbSQL.AppendFormat(" INNER JOIN {0}Idioma I ON I.{0}Id = C.conteudoId", nomeDaTabela);
            sbSQL.Append(" WHERE I.idiomaId = @IdiomaId");
            if (comValidade)
                sbSQL.Append(" AND ((P.dataExibicaoInicio <= GETDATE() OR P.dataExibicaoInicio IS NULL) AND (P.dataExibicaoFim >= GETDATE() OR P.dataExibicaoFim IS NULL))");
            sbSQL.Append(" ORDER BY T.Palavra");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Verifica se o idioma foi informado.
            _db.AddInParameter(command, "@IdiomaId", DbType.Int32, idioma.IdiomaId);

            IDataReader reader;
            reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                Tag entidadeRetorno = new Tag();
                PopulaTag(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }

            reader.Close();

            return entidadesRetorno;
        }
    }
}