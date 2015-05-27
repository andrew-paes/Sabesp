
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
	public class ReleaseImagemComentarioADO : ADOSuper, IReleaseImagemComentarioDAL {
	
	    /// <summary>
        /// Método que persiste um ReleaseImagemComentario.
        /// </summary>
        /// <param name="entidade">ReleaseImagemComentario contendo os dados a serem persistidos.</param>	
		public void Inserir(ReleaseImagemComentario entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ReleaseImagemComentario ");
			sbSQL.Append(" (releaseImagemId, idiomaId, comentarioImagem) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@releaseImagemId, @idiomaId, @comentarioImagem) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@releaseImagemId", DbType.Int32, entidade.ReleaseImagem.ReleaseImagemID);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@comentarioImagem", DbType.String, entidade.ComentarioImagem);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um ReleaseImagemComentario.
        /// </summary>
        /// <param name="entidade">ReleaseImagemComentario contendo os dados a serem atualizados.</param>
		public void Atualizar(ReleaseImagemComentario entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ReleaseImagemComentario SET ");
			sbSQL.Append(" comentarioImagem=@comentarioImagem ");
			sbSQL.Append(" WHERE releaseImagemId=@releaseImagemId AND idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@releaseImagemId", DbType.Int32, entidade.ReleaseImagem.ReleaseImagemID);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@comentarioImagem", DbType.String, entidade.ComentarioImagem);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um ReleaseImagemComentario da base de dados.
        /// </summary>
        /// <param name="entidade">ReleaseImagemComentario a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ReleaseImagemComentario entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM ReleaseImagemComentario ");
			sbSQL.Append("WHERE releaseImagemId=@releaseImagemId AND idiomaId=@idiomaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@releaseImagemId", DbType.Int32, entidade.ReleaseImagem.ReleaseImagemID);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um ReleaseImagemComentario.
		/// </summary>
        /// <param name="entidade">ReleaseImagemComentario a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ReleaseImagemComentario</returns>
		public ReleaseImagemComentario Carregar(ReleaseImagemComentario entidade) {		
		
			ReleaseImagemComentario entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM ReleaseImagemComentario WHERE releaseImagemId=@releaseImagemId AND idiomaId=@idiomaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@releaseImagemId", DbType.Int32, entidade.ReleaseImagem.ReleaseImagemID);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new ReleaseImagemComentario();
				PopulaReleaseImagemComentario(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de ReleaseImagemComentario.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ReleaseImagemComentario.</returns>
		public List<ReleaseImagemComentario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<ReleaseImagemComentario> entidadesRetorno = new List<ReleaseImagemComentario>();
			
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
				sbOrder.Append( " ORDER BY releaseImagemId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ReleaseImagemComentario");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ReleaseImagemComentario WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ReleaseImagemComentario ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT ReleaseImagemComentario.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ReleaseImagemComentario ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT ReleaseImagemComentario.* FROM ReleaseImagemComentario ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                ReleaseImagemComentario entidadeRetorno = new ReleaseImagemComentario();
                PopulaReleaseImagemComentario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os ReleaseImagemComentario existentes na base de dados.
        /// </summary>
		public List<ReleaseImagemComentario> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ReleaseImagemComentario na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ReleaseImagemComentario na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM ReleaseImagemComentario");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um ReleaseImagemComentario baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">ReleaseImagemComentario a ser populado(.</param>
		public static void PopulaReleaseImagemComentario(IDataReader reader, ReleaseImagemComentario entidade) 
		{						
			if (reader["comentarioImagem"] != DBNull.Value)
				entidade.ComentarioImagem=reader["comentarioImagem"].ToString();
			
			if (reader["releaseImagemId"] != DBNull.Value) {
				entidade.ReleaseImagem = new ReleaseImagem();
				entidade.ReleaseImagem.ReleaseImagemID = Convert.ToInt32(reader["releaseImagemId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		