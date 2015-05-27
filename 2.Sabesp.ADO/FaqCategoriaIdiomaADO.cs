
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
	public class FaqCategoriaIdiomaADO : ADOSuper, IFaqCategoriaIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um FaqCategoriaIdioma.
        /// </summary>
        /// <param name="entidade">FaqCategoriaIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(FaqCategoriaIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FaqCategoriaIdioma ");
			sbSQL.Append(" (faqCategoriaId, nomeCategoria, idiomaId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@faqCategoriaId, @nomeCategoria, @idiomaId) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@faqCategoriaId", DbType.Int32, entidade.FaqCategoria.FaqCategoriaId);

			_db.AddInParameter(command, "@nomeCategoria", DbType.String, entidade.NomeCategoria);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um FaqCategoriaIdioma.
        /// </summary>
        /// <param name="entidade">FaqCategoriaIdioma contendo os dados a serem atualizados.</param>
        public void Atualizar(FaqCategoriaIdioma entidade)
        {

            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            // Monta a string de atualização.
            sbSQL.Append(" UPDATE FaqCategoriaIdioma SET ");
            sbSQL.Append(" nomeCategoria=@nomeCategoria, idiomaId=@idiomaId ");
            sbSQL.Append(" WHERE faqCategoriaId=@faqCategoriaId ");
            sbSQL.Append(" and idiomaId=@idiomaId ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Parâmetros
            _db.AddInParameter(command, "@faqCategoriaId", DbType.Int32, entidade.FaqCategoria.FaqCategoriaId);
            _db.AddInParameter(command, "@nomeCategoria", DbType.String, entidade.NomeCategoria);
            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

            // Executa a query.
            _db.ExecuteNonQuery(command);

        }
		
        /// <summary>
        /// Método que remove um FaqCategoriaIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">FaqCategoriaIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FaqCategoriaIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM FaqCategoriaIdioma ");
			sbSQL.Append("WHERE faqCategoriaId=@faqCategoriaId AND idiomaId=@idiomaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@faqCategoriaId", DbType.Int32, entidade.FaqCategoria.FaqCategoriaId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}

        /// <summary>
        /// Método que carrega um FaqCategoriaIdioma.
        /// </summary>
		/// <summary>
		/// Método que carrega um FaqCategoriaIdioma.
		/// </summary>
        /// <param name="entidade">FaqCategoriaIdioma a ser carregado (somente o identificador é necessário).</param>
        /// <returns>FaqCategoriaIdioma</returns>
        public FaqCategoriaIdioma Carregar(FaqCategoriaIdioma entidade)
        {

            FaqCategoriaIdioma entidadeRetorno = null;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM FaqCategoriaIdioma WHERE faqCategoriaId=@faqCategoriaId");
            sbSQL.Append(" and idiomaId=@idiomaId");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@faqCategoriaId", DbType.Int32, entidade.FaqCategoria.FaqCategoriaId);
            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

            IDataReader reader = _db.ExecuteReader(command);

            if (reader.Read())
            {
                entidadeRetorno = new FaqCategoriaIdioma();
                PopulaFaqCategoriaIdioma(reader, entidadeRetorno);
            }
            reader.Close();

            return entidadeRetorno;
        }

		/// <summary>
        /// Método que retorna uma coleção de FaqCategoriaIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FaqCategoriaIdioma.</returns>
		public List<FaqCategoriaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<FaqCategoriaIdioma> entidadesRetorno = new List<FaqCategoriaIdioma>();
			
			StringBuilder sbSQL = new StringBuilder();
			StringBuilder sbWhere = new StringBuilder();
			StringBuilder sbOrder = new StringBuilder();
			DbCommand command;
			IDataReader reader;
			
			// Monta o "OrderBy"
			if (ordemColunas!=null) {
				for(int i=0; i<ordemColunas.Length; i++) {
					if (sbOrder.Length>0) { sbOrder.Append( ", " ); }
					sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
				} 
				if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }				
			} else {
				sbOrder.Append( " ORDER BY faqCategoriaId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FaqCategoriaIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FaqCategoriaIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FaqCategoriaIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT FaqCategoriaIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FaqCategoriaIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT FaqCategoriaIdioma.* FROM FaqCategoriaIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FaqCategoriaIdioma entidadeRetorno = new FaqCategoriaIdioma();
                PopulaFaqCategoriaIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os FaqCategoriaIdioma existentes na base de dados.
        /// </summary>
		public List<FaqCategoriaIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FaqCategoriaIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FaqCategoriaIdioma na base de dados, aceita filtro.
        /// </summary>
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
        /// <returns></returns>
        public int TotalRegistros(IFilterHelper filtro)
        {
            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT COUNT(*) AS Total FROM FaqCategoriaIdioma");

            if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
                sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Executa a query.

            int resultado = (int)_db.ExecuteScalar(command);


            return resultado;
        }
        		
		/// <summary>
        /// Método que retorna popula um FaqCategoriaIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">FaqCategoriaIdioma a ser populado(.</param>
		public static void PopulaFaqCategoriaIdioma(IDataReader reader, FaqCategoriaIdioma entidade) 
		{						
			if (reader["nomeCategoria"] != DBNull.Value)
				entidade.NomeCategoria = reader["nomeCategoria"].ToString();
			
			if (reader["faqCategoriaId"] != DBNull.Value) {
				entidade.FaqCategoria = new FaqCategoria();
				entidade.FaqCategoria.FaqCategoriaId = Convert.ToInt32(reader["faqCategoriaId"].ToString());
                entidade.FaqCategoriaId = Convert.ToInt32(reader["faqCategoriaId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		