
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
	public class ControleTipoADO : ADOSuper, IControleTipoDAL {
	
	    /// <summary>
        /// Método que persiste um ControleTipo.
        /// </summary>
        /// <param name="entidade">ControleTipo contendo os dados a serem persistidos.</param>	
		public void Inserir(ControleTipo entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ControleTipo ");
			sbSQL.Append(" (controleTipoId, nome, hardcode, arquivoControle) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@controleTipoId, @nome, @hardcode, @arquivoControle) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@controleTipoId", DbType.Int32, entidade.ControleTipoId);

			if (entidade.Nome != null ) 
				_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			else
				_db.AddInParameter(command, "@nome", DbType.String, null);

			if (entidade.Hardcode != null ) 
				_db.AddInParameter(command, "@hardcode", DbType.Int32, entidade.Hardcode);
			else
				_db.AddInParameter(command, "@hardcode", DbType.Int32, null);

			if (entidade.ArquivoControle != null ) 
				_db.AddInParameter(command, "@arquivoControle", DbType.String, entidade.ArquivoControle);
			else
				_db.AddInParameter(command, "@arquivoControle", DbType.String, null);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um ControleTipo.
        /// </summary>
        /// <param name="entidade">ControleTipo contendo os dados a serem atualizados.</param>
		public void Atualizar(ControleTipo entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ControleTipo SET ");
			sbSQL.Append(" nome=@nome, hardcode=@hardcode, arquivoControle=@arquivoControle ");
			sbSQL.Append(" WHERE controleTipoId=@controleTipoId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@controleTipoId", DbType.Int32, entidade.ControleTipoId);
			if (entidade.Nome != null ) 
				_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			else
				_db.AddInParameter(command, "@nome", DbType.String, null);
			if (entidade.Hardcode != null ) 
				_db.AddInParameter(command, "@hardcode", DbType.Int32, entidade.Hardcode);
			else
				_db.AddInParameter(command, "@hardcode", DbType.Int32, null);
			if (entidade.ArquivoControle != null ) 
				_db.AddInParameter(command, "@arquivoControle", DbType.String, entidade.ArquivoControle);
			else
				_db.AddInParameter(command, "@arquivoControle", DbType.String, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um ControleTipo da base de dados.
        /// </summary>
        /// <param name="entidade">ControleTipo a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ControleTipo entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM ControleTipo ");
			sbSQL.Append("WHERE controleTipoId=@controleTipoId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@controleTipoId", DbType.Int32, entidade.ControleTipoId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um ControleTipo.
		/// </summary>
        /// <param name="entidade">ControleTipo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleTipo</returns>
		public ControleTipo Carregar(int controleTipoId) {		
			ControleTipo entidade = new ControleTipo();
			entidade.ControleTipoId = controleTipoId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um ControleTipo.
		/// </summary>
        /// <param name="entidade">ControleTipo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ControleTipo</returns>
		public ControleTipo Carregar(ControleTipo entidade) {		
		
			ControleTipo entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM ControleTipo WHERE controleTipoId=@controleTipoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@controleTipoId", DbType.Int32, entidade.ControleTipoId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new ControleTipo();
				PopulaControleTipo(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		

		/// <summary>
        /// Método que retorna uma coleção de ControleTipo.
        /// </summary>
        /// <param name="entidade">Controle relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de ControleTipo.</returns>
		public List<ControleTipo> Carregar(Controle entidade)
		{		
			List<ControleTipo> entidadesRetorno = new List<ControleTipo>();
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT ControleTipo.* FROM ControleTipo INNER JOIN Controle ON ControleTipo.controleTipoId=Controle.controleTipoId WHERE Controle.controleId=@controleId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@controleId", DbType.Int32, entidade.ControleId);
								
			IDataReader reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                ControleTipo entidadeRetorno = new ControleTipo();
                PopulaControleTipo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
			
		}
		
		
		/// <summary>
        /// Método que retorna uma coleção de ControleTipo.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ControleTipo.</returns>
		public List<ControleTipo> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<ControleTipo> entidadesRetorno = new List<ControleTipo>();
			
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
				sbOrder.Append( " ORDER BY controleTipoId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ControleTipo");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleTipo WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ControleTipo ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT ControleTipo.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ControleTipo ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT ControleTipo.* FROM ControleTipo ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                ControleTipo entidadeRetorno = new ControleTipo();
                PopulaControleTipo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os ControleTipo existentes na base de dados.
        /// </summary>
		public List<ControleTipo> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ControleTipo na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ControleTipo na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM ControleTipo");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um ControleTipo baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">ControleTipo a ser populado(.</param>
		public static void PopulaControleTipo(IDataReader reader, ControleTipo entidade) 
		{						
			if (reader["controleTipoId"] != DBNull.Value)
				entidade.ControleTipoId=Convert.ToInt32(reader["controleTipoId"].ToString());
			
			if (reader["nome"] != DBNull.Value)
				entidade.Nome=reader["nome"].ToString();
			
			if (reader["hardcode"] != DBNull.Value)
				entidade.Hardcode=Convert.ToBoolean(reader["hardcode"].ToString());
			
			if (reader["arquivoControle"] != DBNull.Value)
				entidade.ArquivoControle=reader["arquivoControle"].ToString();
			

		}		
		
	}
}
		