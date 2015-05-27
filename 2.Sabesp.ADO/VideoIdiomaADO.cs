
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
	public class VideoIdiomaADO : ADOSuper, IVideoIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um VideoIdioma.
        /// </summary>
        /// <param name="entidade">VideoIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(VideoIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO VideoIdioma ");
			sbSQL.Append(" (videoId, idiomaId, tituloVideo, descricaoVideo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@videoId, @idiomaId, @tituloVideo, @descricaoVideo) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@videoId", DbType.Int32, entidade.Video.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@tituloVideo", DbType.String, entidade.TituloVideo);

			if (entidade.DescricaoVideo != null ) 
				_db.AddInParameter(command, "@descricaoVideo", DbType.String, entidade.DescricaoVideo);
			else
				_db.AddInParameter(command, "@descricaoVideo", DbType.String, null);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um VideoIdioma.
        /// </summary>
        /// <param name="entidade">VideoIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(VideoIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE VideoIdioma SET ");
			sbSQL.Append(" tituloVideo=@tituloVideo, descricaoVideo=@descricaoVideo ");
			sbSQL.Append(" WHERE videoId=@videoId AND idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@videoId", DbType.Int32, entidade.Video.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@tituloVideo", DbType.String, entidade.TituloVideo);
			if (entidade.DescricaoVideo != null ) 
				_db.AddInParameter(command, "@descricaoVideo", DbType.String, entidade.DescricaoVideo);
			else
				_db.AddInParameter(command, "@descricaoVideo", DbType.String, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um VideoIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">VideoIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(VideoIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM VideoIdioma ");
			sbSQL.Append("WHERE videoId=@videoId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@videoId", DbType.Int32, entidade.Video.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um VideoIdioma.
		/// </summary>
        /// <param name="entidade">VideoIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>VideoIdioma</returns>
		public VideoIdioma Carregar(VideoIdioma entidade) {		
		
			VideoIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM VideoIdioma WHERE videoId=@videoId AND idiomaId=@idiomaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@videoId", DbType.Int32, entidade.Video.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new VideoIdioma();
				PopulaVideoIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de VideoIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos VideoIdioma.</returns>
		public List<VideoIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<VideoIdioma> entidadesRetorno = new List<VideoIdioma>();
			
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
				sbOrder.Append( " ORDER BY videoId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM VideoIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM VideoIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM VideoIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT VideoIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM VideoIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT VideoIdioma.* FROM VideoIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                VideoIdioma entidadeRetorno = new VideoIdioma();
                PopulaVideoIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os VideoIdioma existentes na base de dados.
        /// </summary>
		public List<VideoIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de VideoIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de VideoIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM VideoIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um VideoIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">VideoIdioma a ser populado(.</param>
		public static void PopulaVideoIdioma(IDataReader reader, VideoIdioma entidade) 
		{						
			if (reader["tituloVideo"] != DBNull.Value)
				entidade.TituloVideo=reader["tituloVideo"].ToString();
			
			if (reader["descricaoVideo"] != DBNull.Value)
				entidade.DescricaoVideo=reader["descricaoVideo"].ToString();
			
			if (reader["videoId"] != DBNull.Value) {
				entidade.Video = new Video();
                entidade.Video.Conteudo = new Conteudo();
				entidade.Video.Conteudo.ConteudoId = Convert.ToInt32(reader["videoId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		