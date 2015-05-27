
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
	public class NoticiaImagemComentarioADO : ADOSuper, INoticiaImagemComentarioDAL {
	
	    /// <summary>
        /// Método que persiste um NoticiaImagemComentario.
        /// </summary>
        /// <param name="entidade">NoticiaImagemComentario contendo os dados a serem persistidos.</param>	
		public void Inserir(NoticiaImagemComentario entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO NoticiaImagemComentario ");
			sbSQL.Append(" (noticiaImagemId, idiomaId, comentarioImagem) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@noticiaImagemId, @idiomaId, @comentarioImagem) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@noticiaImagemId", DbType.Int32, entidade.NoticiaImagem.NoticiaImagemId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@comentarioImagem", DbType.String, entidade.ComentarioImagem);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um NoticiaImagemComentario.
        /// </summary>
        /// <param name="entidade">NoticiaImagemComentario contendo os dados a serem atualizados.</param>
		public void Atualizar(NoticiaImagemComentario entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE NoticiaImagemComentario SET ");
			sbSQL.Append(" comentarioImagem=@comentarioImagem ");
			sbSQL.Append(" WHERE noticiaImagemId=@noticiaImagemId AND idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@noticiaImagemId", DbType.Int32, entidade.NoticiaImagem.NoticiaImagemId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@comentarioImagem", DbType.String, entidade.ComentarioImagem);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um NoticiaImagemComentario da base de dados.
        /// </summary>
        /// <param name="entidade">NoticiaImagemComentario a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(NoticiaImagemComentario entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM NoticiaImagemComentario ");
			sbSQL.Append("WHERE noticiaImagemId=@noticiaImagemId AND idiomaId=@idiomaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@noticiaImagemId", DbType.Int32, entidade.NoticiaImagem.NoticiaImagemId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um NoticiaImagemComentario.
		/// </summary>
        /// <param name="entidade">NoticiaImagemComentario a ser carregado (somente o identificador é necessário).</param>
		/// <returns>NoticiaImagemComentario</returns>
		public NoticiaImagemComentario Carregar(NoticiaImagemComentario entidade) {		
		
			NoticiaImagemComentario entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM NoticiaImagemComentario WHERE noticiaImagemId=@noticiaImagemId AND idiomaId=@idiomaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@noticiaImagemId", DbType.Int32, entidade.NoticiaImagem.NoticiaImagemId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new NoticiaImagemComentario();
				PopulaNoticiaImagemComentario(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de NoticiaImagemComentario.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos NoticiaImagemComentario.</returns>
		public List<NoticiaImagemComentario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<NoticiaImagemComentario> entidadesRetorno = new List<NoticiaImagemComentario>();
			
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
				sbOrder.Append( " ORDER BY noticiaImagemId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM NoticiaImagemComentario");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM NoticiaImagemComentario WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM NoticiaImagemComentario ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT NoticiaImagemComentario.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM NoticiaImagemComentario ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT NoticiaImagemComentario.* FROM NoticiaImagemComentario ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                NoticiaImagemComentario entidadeRetorno = new NoticiaImagemComentario();
                PopulaNoticiaImagemComentario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os NoticiaImagemComentario existentes na base de dados.
        /// </summary>
		public List<NoticiaImagemComentario> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de NoticiaImagemComentario na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de NoticiaImagemComentario na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM NoticiaImagemComentario");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um NoticiaImagemComentario baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">NoticiaImagemComentario a ser populado(.</param>
		public static void PopulaNoticiaImagemComentario(IDataReader reader, NoticiaImagemComentario entidade) 
		{						
			if (reader["comentarioImagem"] != DBNull.Value)
				entidade.ComentarioImagem=reader["comentarioImagem"].ToString();
			
			if (reader["noticiaImagemId"] != DBNull.Value) {
				entidade.NoticiaImagem = new NoticiaImagem();
				entidade.NoticiaImagem.NoticiaImagemId = Convert.ToInt32(reader["noticiaImagemId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		