
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
    public class ConteudoTagADO : ADOSuper, IConteudoTagDAL
    {

        /// <summary>
        /// Método que persiste a entidade.
        /// </summary>
        /// <param name="entidade">Entidade contendo os dados a serem persistidos.</param>	
        public void Inserir(ConteudoTag entidade)
        {

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" INSERT INTO ConteudoTag ");
            sbSQL.Append(" (conteudoId, tagId) ");
            sbSQL.Append(" VALUES ");
            sbSQL.Append(" (@conteudoId, @tagId); ");

         //   sbSQL.Append(" ; SET @tagId = SCOPE_IDENTITY(); ");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.Conteudo.ConteudoId);
            _db.AddInParameter(command, "@tagId", DbType.Int32, entidade.Tag.TagId);

            // Executa a query.
            _db.ExecuteNonQuery(command);


        }

        /// <summary>
        /// Método que atualiza os dados entidade.
        /// </summary>
        /// <param name="entidade">Entidade contendo os dados a serem atualizados.</param>
        public void Atualizar(ConteudoTag entidade)
        {


            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" UPDATE ConteudoTag SET ");
            sbSQL.Append(" conteudoId=@conteudoId, tagId=@tagId ");
            sbSQL.Append(" WHERE conteudoId=@conteudoId AND tagId=@tagId ");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.Conteudo.ConteudoId);
            _db.AddInParameter(command, "@tagId", DbType.Int32, entidade.Tag.TagId);

            _db.ExecuteNonQuery(command);

        }

        /// <summary>
        /// Método que remove uma entidade do repositório.
        /// </summary>
        /// <param name="entidade">Entidade a ser excluída (somente o identificador é necessário).</param>		
        public void Excluir(ConteudoTag entidade)
        {

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("DELETE FROM ConteudoTag ");

            sbSQL.Append("WHERE ");

            if (entidade.Conteudo != null)
            {
                if (!sbSQL.ToString().EndsWith("WHERE "))
                {
                    sbSQL.Append("AND ");
                }
                sbSQL.Append("conteudoId=@conteudoId ");
            }

            if (entidade.Tag != null)
            {
                if (!sbSQL.ToString().EndsWith("WHERE "))
                {
                    sbSQL.Append("AND ");
                }
                sbSQL.Append("tagId=@tagId ");
            }

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            if (entidade.Conteudo != null)
                _db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.Conteudo.ConteudoId);
            if (entidade.Tag != null)
                _db.AddInParameter(command, "@tagId", DbType.Int32, entidade.Tag.TagId);

            _db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Método que carrega uma entidade.
        /// </summary>
        /// <param name="entidade">Entidade a ser carregada (somente o identificador é necessário).</param>
        /// <returns></returns>
        public ConteudoTag Carregar(ConteudoTag entidade)
        {

            ConteudoTag entidadeRetorno = null;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM ConteudoTag WHERE conteudoId=@conteudoId AND tagId=@tagId");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@conteudoId", DbType.Int32, entidade.Conteudo.ConteudoId);
            _db.AddInParameter(command, "@tagId", DbType.Int32, entidade.Tag.TagId);

            IDataReader entidades = _db.ExecuteReader(command);

            if (entidades.Read())
            {
                entidadeRetorno = new ConteudoTag();
                PopulaConteudoTag(entidades, entidadeRetorno);
            }
            entidades.Close();

            return entidadeRetorno;
        }

        /// <summary>
        /// Método que retorna uma coleção de entidades.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordem">Nome do campo que se deseja ordernar.</param>
        /// <param name="ordemOrientacao">Orientação, "ASC" ou "DESC".</param>
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
        /// <returns>Retorna um List contendos as entidades.</returns>
        public IList<ConteudoTag> CarregarTodos(int registrosPagina, int numeroPagina, string ordem, string ordemOrientacao, IFilterHelper filtro)
        {

            IList<ConteudoTag> entidadesRetorno = new List<ConteudoTag>();

            StringBuilder sbSQL = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();

            // Monta o "Order By"
            if (ordem.Equals(String.Empty))
                ordem = "conteudoId";
            ordem = "tagId";
            if (ordemOrientacao.Equals(String.Empty))
                ordemOrientacao = "ASC";
            String orderBy = ordem + ' ' + ordemOrientacao;

            if (registrosPagina > 0)
            {
                sbSQL.Append("SELECT TOP " + registrosPagina + " * FROM ConteudoTag");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
                    sbWhere.Append("ConteudoTagId NOT IN (SELECT TOP " + ((numeroPagina - 1) * registrosPagina) + " ConteudoTagId FROM ConteudoTag WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ")");
                else
                    sbWhere.Append("ConteudoTagId NOT IN (SELECT TOP " + ((numeroPagina - 1) * registrosPagina) + " ConteudoTagId FROM ConteudoTag ORDER BY " + orderBy + ")");

            }
            else
            {
                sbSQL.Append("SELECT * FROM ConteudoTag");
            }

            if (sbWhere.Length > 0)
            { // Tem filtro.
                sbSQL.Append(" WHERE " + sbWhere.ToString());

                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
                    sbSQL.Append(" AND (" + filtro.GetWhereString() + ")");

            }
            else if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
            {
                sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");
            }

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString() + " ORDER BY " + orderBy);

            IDataReader entidades = _db.ExecuteReader(command);

            while (entidades.Read())
            {
                ConteudoTag entidadeRetorno = new ConteudoTag();
                PopulaConteudoTag(entidades, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            entidades.Close();

            return entidadesRetorno;

        }

        /// <summary>
        /// Método que retorna todas as entidades.
        /// </summary>
        public IList<ConteudoTag> CarregarTodos()
        {

            return CarregarTodos(0, 0, String.Empty, String.Empty, null);

        }


        /// <summary>
        /// Método que retorna o total de registros na base de dados.
        /// </summary>
        /// <returns></returns>
        public int TotalRegistros()
        {

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT COUNT(*) AS Total FROM ConteudoTag");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Executa a query.
            int resultado = (int)_db.ExecuteScalar(command);

            return resultado;

        }

        public int TotalRegistros(IFilterHelper filtro)
        {
            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT COUNT(*) AS Total FROM ConteudoTag");

            if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
                sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Executa a query.

            int resultado = (int)_db.ExecuteScalar(command);


            return resultado;
        }

        /// <summary>
        /// Método que retorna popula uma entidade baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="entidades">DataReader contendo os dados da entidade.</param>
        /// <param name="entidade">Entidade a ser populada.</param>
        public static void PopulaConteudoTag(IDataReader reader, ConteudoTag entidade)
        {
            if (reader["conteudoId"] != DBNull.Value)
            {
                entidade.Conteudo = new Conteudo();
                entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["conteudoId"].ToString());
            }

            if (reader["tagId"] != DBNull.Value)
            {
                entidade.Tag = new Tag();
                entidade.Tag.TagId = Convert.ToInt32(reader["tagId"].ToString());
            }
        }
    }
}