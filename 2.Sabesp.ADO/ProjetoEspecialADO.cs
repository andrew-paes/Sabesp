
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
	public class ProjetoEspecialADO : ADOSuper, IProjetoEspecialDAL {
	
	    /// <summary>
        /// Método que persiste um ProjetoEspecial.
        /// </summary>
        /// <param name="entidade">ProjetoEspecial contendo os dados a serem persistidos.</param>	
		public void Inserir(ProjetoEspecial entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ProjetoEspecial ");
			sbSQL.Append(" (ativo, url, arquivoThumbId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@ativo, @url, @arquivoThumbId) ");											

			sbSQL.Append(" ; SET @projetoEspecialId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@projetoEspecialId", DbType.Int32, 8);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			if (entidade.Url != null ) 
				_db.AddInParameter(command, "@url", DbType.String, entidade.Url);
			else
				_db.AddInParameter(command, "@url", DbType.String, null);

			if (entidade.ArquivoThumbId != null ) 
				_db.AddInParameter(command, "@arquivoThumbId", DbType.Int32, entidade.ArquivoThumbId.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoThumbId", DbType.Int32, null);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.ProjetoEspecialId = Convert.ToInt32(_db.GetParameterValue(command, "@projetoEspecialId"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um ProjetoEspecial.
        /// </summary>
        /// <param name="entidade">ProjetoEspecial contendo os dados a serem atualizados.</param>
		public void Atualizar(ProjetoEspecial entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ProjetoEspecial SET ");
			sbSQL.Append(" ativo=@ativo, url=@url, arquivoThumbId=@arquivoThumbId ");
			sbSQL.Append(" WHERE projetoEspecialId=@projetoEspecialId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@projetoEspecialId", DbType.Int32, entidade.ProjetoEspecialId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			if (entidade.Url != null ) 
				_db.AddInParameter(command, "@url", DbType.String, entidade.Url);
			else
				_db.AddInParameter(command, "@url", DbType.String, null);
			if (entidade.ArquivoThumbId != null ) 
				_db.AddInParameter(command, "@arquivoThumbId", DbType.Int32, entidade.ArquivoThumbId.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoThumbId", DbType.Int32, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um ProjetoEspecial da base de dados.
        /// </summary>
        /// <param name="entidade">ProjetoEspecial a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ProjetoEspecial entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM ProjetoEspecial ");
			sbSQL.Append("WHERE projetoEspecialId=@projetoEspecialId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@projetoEspecialId", DbType.Int32, entidade.ProjetoEspecialId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um ProjetoEspecial.
		/// </summary>
        /// <param name="entidade">ProjetoEspecial a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ProjetoEspecial</returns>
		public ProjetoEspecial Carregar(int projetoEspecialId) {		
			ProjetoEspecial entidade = new ProjetoEspecial();
			entidade.ProjetoEspecialId = projetoEspecialId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um ProjetoEspecial.
		/// </summary>
        /// <param name="entidade">ProjetoEspecial a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ProjetoEspecial</returns>
		public ProjetoEspecial Carregar(ProjetoEspecial entidade) {		
		
			ProjetoEspecial entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM ProjetoEspecial WHERE projetoEspecialId=@projetoEspecialId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@projetoEspecialId", DbType.Int32, entidade.ProjetoEspecialId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new ProjetoEspecial();
				PopulaProjetoEspecial(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de ProjetoEspecial.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ProjetoEspecial.</returns>
		public List<ProjetoEspecial> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<ProjetoEspecial> entidadesRetorno = new List<ProjetoEspecial>();
			
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
				sbOrder.Append( " ORDER BY projetoEspecialId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ProjetoEspecial");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ProjetoEspecial WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ProjetoEspecial ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT ProjetoEspecial.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ProjetoEspecial ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT ProjetoEspecial.* FROM ProjetoEspecial ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                ProjetoEspecial entidadeRetorno = new ProjetoEspecial();
                PopulaProjetoEspecial(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os ProjetoEspecial existentes na base de dados.
        /// </summary>
		public List<ProjetoEspecial> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ProjetoEspecial na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ProjetoEspecial na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM ProjetoEspecial");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um ProjetoEspecial baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">ProjetoEspecial a ser populado(.</param>
		public static void PopulaProjetoEspecial(IDataReader reader, ProjetoEspecial entidade) 
		{						
			if (reader["projetoEspecialId"] != DBNull.Value)
				entidade.ProjetoEspecialId = Convert.ToInt32(reader["projetoEspecialId"].ToString());
			
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());
			
			if (reader["url"] != DBNull.Value)
				entidade.Url = reader["url"].ToString();
			
			if (reader["arquivoThumbId"] != DBNull.Value) {
				entidade.ArquivoThumbId = new Arquivo();
				entidade.ArquivoThumbId.ArquivoId = Convert.ToInt32(reader["arquivoThumbId"].ToString());
			}


		}		
		
	}
}
		