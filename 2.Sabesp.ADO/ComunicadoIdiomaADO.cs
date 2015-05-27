
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
    public class ComunicadoIdiomaADO : ADOSuper, IComunicadoIdiomaDAL
    {

        /// <summary>
        /// Método que persiste um ComunicadoIdioma.
        /// </summary>
        /// <param name="entidade">ComunicadoIdioma contendo os dados a serem persistidos.</param>	
        public void Inserir(ComunicadoIdioma entidade)
        {
            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            // Monta a string de insert.
            sbSQL.Append(" INSERT INTO ComunicadoIdioma ");
            sbSQL.Append(" (comunicadoId, idiomaId, tituloComunicado, textoComunicado) ");
            sbSQL.Append(" VALUES ");
            sbSQL.Append(" (@comunicadoId, @idiomaId, @tituloComunicado, @textoComunicado) ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@comunicadoId", DbType.Int32, entidade.Comunicado.Conteudo.ConteudoId);

            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

            _db.AddInParameter(command, "@tituloComunicado", DbType.String, entidade.TituloComunicado);

            _db.AddInParameter(command, "@textoComunicado", DbType.String, entidade.TextoComunicado);


            // Executa a query.
            _db.ExecuteNonQuery(command);

        }

        /// <summary>
        /// Método que atualiza os dados de um ComunicadoIdioma.
        /// </summary>
        /// <param name="entidade">ComunicadoIdioma contendo os dados a serem atualizados.</param>
        public void Atualizar(ComunicadoIdioma entidade)
        {

            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            // Monta a string de atualização.
            sbSQL.Append(" UPDATE ComunicadoIdioma SET ");
            sbSQL.Append(" tituloComunicado=@tituloComunicado, textoComunicado=@textoComunicado ");
            sbSQL.Append(" WHERE comunicadoId=@comunicadoId AND idiomaId=@idiomaId ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Parâmetros
            _db.AddInParameter(command, "@comunicadoId", DbType.Int32, entidade.Comunicado.Conteudo.ConteudoId);
            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
            _db.AddInParameter(command, "@tituloComunicado", DbType.String, entidade.TituloComunicado);
            _db.AddInParameter(command, "@textoComunicado", DbType.String, entidade.TextoComunicado);

            // Executa a query.
            _db.ExecuteNonQuery(command);

        }

        /// <summary>
        /// Método que remove um ComunicadoIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">ComunicadoIdioma a ser excluído (somente o identificador é necessário).</param>		
        public void Excluir(ComunicadoIdioma entidade)
        {
            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            sbSQL.Append("DELETE FROM ComunicadoIdioma ");
            sbSQL.Append("WHERE comunicadoId=@comunicadoId ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@comunicadoId", DbType.Int32, entidade.Comunicado.Conteudo.ConteudoId);
            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);


            _db.ExecuteNonQuery(command);
        }


        /// <summary>
        /// Método que carrega um ComunicadoIdioma.
        /// </summary>
        /// <param name="entidade">ComunicadoIdioma a ser carregado (somente o identificador é necessário).</param>
        /// <returns>ComunicadoIdioma</returns>
        public ComunicadoIdioma Carregar(ComunicadoIdioma entidade)
        {

            ComunicadoIdioma entidadeRetorno = null;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM ComunicadoIdioma WHERE comunicadoId=@comunicadoId AND idiomaId=@idiomaId");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@comunicadoId", DbType.Int32, entidade.Comunicado.Conteudo.ConteudoId);
            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

            IDataReader reader = _db.ExecuteReader(command);

            if (reader.Read())
            {
                entidadeRetorno = new ComunicadoIdioma();
                PopulaComunicadoIdioma(reader, entidadeRetorno);
            }
            reader.Close();

            return entidadeRetorno;
        }



        /// <summary>
        /// Método que retorna uma coleção de ComunicadoIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
        ///  <returns>Retorna um List contendos ComunicadoIdioma.</returns>
        public List<ComunicadoIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {

            List<ComunicadoIdioma> entidadesRetorno = new List<ComunicadoIdioma>();

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
                sbOrder.Append(" ORDER BY comunicadoId, idiomaId");
            }


            if (registrosPagina > 0)
            {

                //sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ComunicadoIdioma");
                //if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
                //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ComunicadoIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
                //} else {
                //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ComunicadoIdioma ORDER BY " + orderBy + ")");				
                //}	
                sbSQL.Append("SELECT * FROM ( ");
                sbSQL.Append("SELECT ComunicadoIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ComunicadoIdioma ");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
                sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

            }
            else
            {
                sbSQL.Append("SELECT ComunicadoIdioma.* FROM ComunicadoIdioma ");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
                if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
            }

            command = _db.GetSqlStringCommand(sbSQL.ToString());
            reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                ComunicadoIdioma entidadeRetorno = new ComunicadoIdioma();
                PopulaComunicadoIdioma(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;

        }

        /// <summary>
        /// Método que retorna todas os ComunicadoIdioma existentes na base de dados.
        /// </summary>
        public List<ComunicadoIdioma> CarregarTodos()
        {
            return CarregarTodos(0, 0, null, null, null);
        }

        /// <summary>
        /// Método que retorna o total de ComunicadoIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
        public int TotalRegistros()
        {
            return TotalRegistros(null);
        }

        /// <summary>
        /// Método que retorna o total de ComunicadoIdioma na base de dados, aceita filtro.
        /// </summary>
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
        /// <returns></returns>
        public int TotalRegistros(IFilterHelper filtro)
        {
            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT COUNT(*) AS Total FROM ComunicadoIdioma");

            if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
                sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Executa a query.

            int resultado = (int)_db.ExecuteScalar(command);


            return resultado;
        }

        /// <summary>
        /// Método que retorna popula um ComunicadoIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">ComunicadoIdioma a ser populado(.</param>
        public static void PopulaComunicadoIdioma(IDataReader reader, ComunicadoIdioma entidade)
        {
            if (reader["tituloComunicado"] != DBNull.Value)
                entidade.TituloComunicado = reader["tituloComunicado"].ToString();

            if (reader["textoComunicado"] != DBNull.Value)
                entidade.TextoComunicado = reader["textoComunicado"].ToString();

            if (reader["comunicadoId"] != DBNull.Value)
            {
                entidade.Comunicado = new Comunicado();
                entidade.Comunicado.Conteudo = new Conteudo();
                entidade.Comunicado.Conteudo.ConteudoId = Convert.ToInt32(reader["comunicadoId"].ToString());
            }

            if (reader["idiomaId"] != DBNull.Value)
            {
                entidade.Idioma = new Idioma();
                entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
            }


        }

    }
}
