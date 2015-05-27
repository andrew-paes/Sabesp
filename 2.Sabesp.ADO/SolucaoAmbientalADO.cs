
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
using System.Data;
using System.Data.Common;

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class SolucaoAmbientalIdiomaADO : ADOSuper, ISolucaoAmbientalIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um SolucaoAmbientalIdioma.
        /// </summary>
        /// <param name="entidade">SolucaoAmbientalIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(SolucaoAmbientalIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO SolucaoAmbientalIdioma ");
			sbSQL.Append(" (arquivoIdFoto, tituloPrincipal, tituloChamada1, tituloChamada2, tituloChamada3, textoChamada1, textoChamada2, textoChamada3, link1, link2, link3, linkImagem, idiomaId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@arquivoIdFoto, @tituloPrincipal, @tituloChamada1, @tituloChamada2, @tituloChamada3, @textoChamada1, @textoChamada2, @textoChamada3, @link1, @link2, @link3, @linkImagem, @idiomaId) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			if (entidade.ArquivoFoto != null ) 
				_db.AddInParameter(command, "@arquivoIdFoto", DbType.Int32, entidade.ArquivoFoto.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdFoto", DbType.Int32, null);

			if (entidade.TituloPrincipal != null ) 
				_db.AddInParameter(command, "@tituloPrincipal", DbType.String, entidade.TituloPrincipal);
			else
				_db.AddInParameter(command, "@tituloPrincipal", DbType.String, null);

			if (entidade.TituloChamada1 != null ) 
				_db.AddInParameter(command, "@tituloChamada1", DbType.String, entidade.TituloChamada1);
			else
				_db.AddInParameter(command, "@tituloChamada1", DbType.String, null);

			if (entidade.TituloChamada2 != null ) 
				_db.AddInParameter(command, "@tituloChamada2", DbType.String, entidade.TituloChamada2);
			else
				_db.AddInParameter(command, "@tituloChamada2", DbType.String, null);

			if (entidade.TituloChamada3 != null ) 
				_db.AddInParameter(command, "@tituloChamada3", DbType.String, entidade.TituloChamada3);
			else
				_db.AddInParameter(command, "@tituloChamada3", DbType.String, null);

			if (entidade.TextoChamada1 != null ) 
				_db.AddInParameter(command, "@textoChamada1", DbType.String, entidade.TextoChamada1);
			else
				_db.AddInParameter(command, "@textoChamada1", DbType.String, null);

			if (entidade.TextoChamada2 != null ) 
				_db.AddInParameter(command, "@textoChamada2", DbType.String, entidade.TextoChamada2);
			else
				_db.AddInParameter(command, "@textoChamada2", DbType.String, null);

			if (entidade.TextoChamada3 != null ) 
				_db.AddInParameter(command, "@textoChamada3", DbType.String, entidade.TextoChamada3);
			else
				_db.AddInParameter(command, "@textoChamada3", DbType.String, null);

			if (entidade.Link1 != null ) 
				_db.AddInParameter(command, "@link1", DbType.String, entidade.Link1);
			else
				_db.AddInParameter(command, "@link1", DbType.String, null);

			if (entidade.Link2 != null ) 
				_db.AddInParameter(command, "@link2", DbType.String, entidade.Link2);
			else
				_db.AddInParameter(command, "@link2", DbType.String, null);

			if (entidade.Link3 != null ) 
				_db.AddInParameter(command, "@link3", DbType.String, entidade.Link3);
			else
				_db.AddInParameter(command, "@link3", DbType.String, null);

			if (entidade.LinkImagem != null ) 
				_db.AddInParameter(command, "@linkImagem", DbType.String, entidade.LinkImagem);
			else
				_db.AddInParameter(command, "@linkImagem", DbType.String, null);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um SolucaoAmbientalIdioma.
        /// </summary>
        /// <param name="entidade">SolucaoAmbientalIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(SolucaoAmbientalIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE SolucaoAmbientalIdioma SET ");
			sbSQL.Append(" arquivoIdFoto=@arquivoIdFoto, tituloPrincipal=@tituloPrincipal, tituloChamada1=@tituloChamada1, tituloChamada2=@tituloChamada2, tituloChamada3=@tituloChamada3, textoChamada1=@textoChamada1, textoChamada2=@textoChamada2, textoChamada3=@textoChamada3, link1=@link1, link2=@link2, link3=@link3, linkImagem=@linkImagem, idiomaId=@idiomaId ");
            sbSQL.Append(" WHERE idiomaId=@idiomaId ");										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			if (entidade.ArquivoFoto != null ) 
				_db.AddInParameter(command, "@arquivoIdFoto", DbType.Int32, entidade.ArquivoFoto.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdFoto", DbType.Int32, null);
			if (entidade.TituloPrincipal != null ) 
				_db.AddInParameter(command, "@tituloPrincipal", DbType.String, entidade.TituloPrincipal);
			else
				_db.AddInParameter(command, "@tituloPrincipal", DbType.String, null);
			if (entidade.TituloChamada1 != null ) 
				_db.AddInParameter(command, "@tituloChamada1", DbType.String, entidade.TituloChamada1);
			else
				_db.AddInParameter(command, "@tituloChamada1", DbType.String, null);
			if (entidade.TituloChamada2 != null ) 
				_db.AddInParameter(command, "@tituloChamada2", DbType.String, entidade.TituloChamada2);
			else
				_db.AddInParameter(command, "@tituloChamada2", DbType.String, null);
			if (entidade.TituloChamada3 != null ) 
				_db.AddInParameter(command, "@tituloChamada3", DbType.String, entidade.TituloChamada3);
			else
				_db.AddInParameter(command, "@tituloChamada3", DbType.String, null);
			if (entidade.TextoChamada1 != null ) 
				_db.AddInParameter(command, "@textoChamada1", DbType.String, entidade.TextoChamada1);
			else
				_db.AddInParameter(command, "@textoChamada1", DbType.String, null);
			if (entidade.TextoChamada2 != null ) 
				_db.AddInParameter(command, "@textoChamada2", DbType.String, entidade.TextoChamada2);
			else
				_db.AddInParameter(command, "@textoChamada2", DbType.String, null);
			if (entidade.TextoChamada3 != null ) 
				_db.AddInParameter(command, "@textoChamada3", DbType.String, entidade.TextoChamada3);
			else
				_db.AddInParameter(command, "@textoChamada3", DbType.String, null);
			if (entidade.Link1 != null ) 
				_db.AddInParameter(command, "@link1", DbType.String, entidade.Link1);
			else
				_db.AddInParameter(command, "@link1", DbType.String, null);
			if (entidade.Link2 != null ) 
				_db.AddInParameter(command, "@link2", DbType.String, entidade.Link2);
			else
				_db.AddInParameter(command, "@link2", DbType.String, null);
			if (entidade.Link3 != null ) 
				_db.AddInParameter(command, "@link3", DbType.String, entidade.Link3);
			else
				_db.AddInParameter(command, "@link3", DbType.String, null);
			if (entidade.LinkImagem != null ) 
				_db.AddInParameter(command, "@linkImagem", DbType.String, entidade.LinkImagem);
			else
				_db.AddInParameter(command, "@linkImagem", DbType.String, null);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um SolucaoAmbientalIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">SolucaoAmbientalIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(SolucaoAmbientalIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM SolucaoAmbientalIdioma ");
            sbSQL.Append(" WHERE idiomaId=@idiomaId ");	
			command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um SolucaoAmbientalIdioma.
		/// </summary>
        /// <param name="entidade">SolucaoAmbientalIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>SolucaoAmbientalIdioma</returns>
		public SolucaoAmbientalIdioma Carregar(SolucaoAmbientalIdioma entidade) {		
		
			SolucaoAmbientalIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM SolucaoAmbientalIdioma WHERE idiomaId=@idiomaId ");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new SolucaoAmbientalIdioma();
				PopulaSolucaoAmbientalIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}



        /// <summary>
        /// Método que retorna uma coleção de SolucaoAmbientalIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
        ///  <returns>Retorna um List contendos SolucaoAmbientalIdioma.</returns>
        public List<SolucaoAmbientalIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {

            List<SolucaoAmbientalIdioma> entidadesRetorno = new List<SolucaoAmbientalIdioma>();

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


            if (registrosPagina > 0)
            {

                //sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM SolucaoAmbientalIdioma");
                //if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
                //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM SolucaoAmbientalIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
                //} else {
                //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM SolucaoAmbientalIdioma ORDER BY " + orderBy + ")");				
                //}	
                sbSQL.Append("SELECT * FROM ( ");
                sbSQL.Append("SELECT SolucaoAmbientalIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM SolucaoAmbientalIdioma ");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
                sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

            }
            else
            {
                sbSQL.Append("SELECT SolucaoAmbientalIdioma.* FROM SolucaoAmbientalIdioma ");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
                if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
            }

            command = _db.GetSqlStringCommand(sbSQL.ToString());
            reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                SolucaoAmbientalIdioma entidadeRetorno = new SolucaoAmbientalIdioma();
                PopulaSolucaoAmbientalIdioma(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;

        }	
		
		/// <summary>
        /// Método que retorna todas os SolucaoAmbientalIdioma existentes na base de dados.
        /// </summary>
		public List<SolucaoAmbientalIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de SolucaoAmbientalIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de SolucaoAmbientalIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM SolucaoAmbientalIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}

        /// <summary>
        /// Método que carrega uma SolucaoAmbientalIdioma para exibição do site
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public SolucaoAmbientalIdioma CarregarToSite(int solucaoAmbientalIdiomaId)
        {
            SolucaoAmbientalIdioma entidadeRetorno = null;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM SolucaoAmbientalIdioma");


            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@idiomaId", DbType.Int32, solucaoAmbientalIdiomaId);
            IDataReader reader = _db.ExecuteReader(command);

            if (reader.Read())
            {
                entidadeRetorno = new SolucaoAmbientalIdioma();
                PopulaSolucaoAmbientalIdioma(reader, entidadeRetorno);
            }
            reader.Close();

            return entidadeRetorno;
        }


        public List<SolucaoAmbientalIdioma> RetornaTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            List<SolucaoAmbientalIdioma> entidadesRetorno = new List<SolucaoAmbientalIdioma>();

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


            sbSQL.Append("SELECT ");

            if (quantidadeRegistros > 0)
            {
                sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
            }

            sbSQL.Append("* FROM SolucaoAmbientalIdioma ");
            if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
            if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }

            command = _db.GetSqlStringCommand(sbSQL.ToString());
            reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                SolucaoAmbientalIdioma entidadeRetorno = new SolucaoAmbientalIdioma();
                PopulaSolucaoAmbientalIdioma(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
        }
        /// MÃ©todo que retorna popula um SolucaoAmbientalIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">SolucaoAmbientalIdioma a ser populado(.</param>
        public static void PopulaSolucaoAmbientalIdioma(IDataReader reader, SolucaoAmbientalIdioma entidade)
        {
            if (reader["tituloPrincipal"] != DBNull.Value)
                entidade.TituloPrincipal = reader["tituloPrincipal"].ToString();

            if (reader["tituloChamada1"] != DBNull.Value)
                entidade.TituloChamada1 = reader["tituloChamada1"].ToString();

            if (reader["tituloChamada2"] != DBNull.Value)
                entidade.TituloChamada2 = reader["tituloChamada2"].ToString();

            if (reader["tituloChamada3"] != DBNull.Value)
                entidade.TituloChamada3 = reader["tituloChamada3"].ToString();

            if (reader["textoChamada1"] != DBNull.Value)
                entidade.TextoChamada1 = reader["textoChamada1"].ToString();

            if (reader["textoChamada2"] != DBNull.Value)
                entidade.TextoChamada2 = reader["textoChamada2"].ToString();

            if (reader["textoChamada3"] != DBNull.Value)
                entidade.TextoChamada3 = reader["textoChamada3"].ToString();

            if (reader["link1"] != DBNull.Value)
                entidade.Link1 = reader["link1"].ToString();

            if (reader["link2"] != DBNull.Value)
                entidade.Link2 = reader["link2"].ToString();

            if (reader["link3"] != DBNull.Value)
                entidade.Link3 = reader["link3"].ToString();

            if (reader["linkImagem"] != DBNull.Value)
                entidade.LinkImagem = reader["linkImagem"].ToString();

            if (reader["arquivoIdFoto"] != DBNull.Value)
            {
                entidade.ArquivoFoto = new Arquivo();
                entidade.ArquivoFoto.ArquivoId = Convert.ToInt32(reader["arquivoIdFoto"].ToString());
            }

            if (reader["idiomaId"] != DBNull.Value)
            {
                entidade.Idioma = new Idioma();
                entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
            }


        }			
		
	}
}
		