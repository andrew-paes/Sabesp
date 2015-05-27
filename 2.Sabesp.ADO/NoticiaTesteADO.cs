
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
	public class NoticiaTesteADO : ADOSuper, INoticiaTesteDAL {
	
	    /// <summary>
        /// Método que persiste um NoticiaTeste.
        /// </summary>
        /// <param name="entidade">NoticiaTeste contendo os dados a serem persistidos.</param>	
		public void Inserir(NoticiaTeste entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO NoticiaTeste ");
			sbSQL.Append(" (dataCadastro, workflowId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@dataCadastro, @workflowId) ");											

			sbSQL.Append(" ; SET @noticiaTesteId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@noticiaTesteId", DbType.Int32, 8);

			if (entidade.DataCadastro != null && entidade.DataCadastro != DateTime.MinValue ) 
				_db.AddInParameter(command, "@dataCadastro", DbType.DateTime, entidade.DataCadastro);
			else
				_db.AddInParameter(command, "@dataCadastro", DbType.DateTime, null);

			if (entidade.Workflow != null ) 
				_db.AddInParameter(command, "@workflowId", DbType.Int32, entidade.Workflow.WorkflowId);
			else
				_db.AddInParameter(command, "@workflowId", DbType.Int32, null);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.NoticiaTesteId = Convert.ToInt32(_db.GetParameterValue(command, "@noticiaTesteId"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um NoticiaTeste.
        /// </summary>
        /// <param name="entidade">NoticiaTeste contendo os dados a serem atualizados.</param>
		public void Atualizar(NoticiaTeste entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE NoticiaTeste SET ");
			sbSQL.Append(" dataCadastro=@dataCadastro, workflowId=@workflowId ");
			sbSQL.Append(" WHERE noticiaTesteId=@noticiaTesteId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@noticiaTesteId", DbType.Int32, entidade.NoticiaTesteId);
			if (entidade.DataCadastro != null && entidade.DataCadastro != DateTime.MinValue ) 
				_db.AddInParameter(command, "@dataCadastro", DbType.DateTime, entidade.DataCadastro);
			else
				_db.AddInParameter(command, "@dataCadastro", DbType.DateTime, null);
			if (entidade.Workflow != null ) 
				_db.AddInParameter(command, "@workflowId", DbType.Int32, entidade.Workflow.WorkflowId);
			else
				_db.AddInParameter(command, "@workflowId", DbType.Int32, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um NoticiaTeste da base de dados.
        /// </summary>
        /// <param name="entidade">NoticiaTeste a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(NoticiaTeste entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM NoticiaTeste ");
			sbSQL.Append("WHERE noticiaTesteId=@noticiaTesteId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@noticiaTesteId", DbType.Int32, entidade.NoticiaTesteId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um NoticiaTeste.
		/// </summary>
        /// <param name="entidade">NoticiaTeste a ser carregado (somente o identificador é necessário).</param>
		/// <returns>NoticiaTeste</returns>
		public NoticiaTeste Carregar(int noticiaTesteId) {		
			NoticiaTeste entidade = new NoticiaTeste();
			entidade.NoticiaTesteId = noticiaTesteId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um NoticiaTeste.
		/// </summary>
        /// <param name="entidade">NoticiaTeste a ser carregado (somente o identificador é necessário).</param>
		/// <returns>NoticiaTeste</returns>
		public NoticiaTeste Carregar(NoticiaTeste entidade) {		
		
			NoticiaTeste entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM NoticiaTeste WHERE noticiaTesteId=@noticiaTesteId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@noticiaTesteId", DbType.Int32, entidade.NoticiaTesteId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new NoticiaTeste();
				PopulaNoticiaTeste(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de NoticiaTeste.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos NoticiaTeste.</returns>
		public List<NoticiaTeste> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<NoticiaTeste> entidadesRetorno = new List<NoticiaTeste>();
			
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
				sbOrder.Append( " ORDER BY noticiaTesteId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM NoticiaTeste");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM NoticiaTeste WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM NoticiaTeste ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT NoticiaTeste.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM NoticiaTeste ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT NoticiaTeste.* FROM NoticiaTeste ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                NoticiaTeste entidadeRetorno = new NoticiaTeste();
                PopulaNoticiaTeste(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os NoticiaTeste existentes na base de dados.
        /// </summary>
		public List<NoticiaTeste> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de NoticiaTeste na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de NoticiaTeste na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM NoticiaTeste");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um NoticiaTeste baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">NoticiaTeste a ser populado(.</param>
		public static void PopulaNoticiaTeste(IDataReader reader, NoticiaTeste entidade) 
		{						
			if (reader["noticiaTesteId"] != DBNull.Value)
				entidade.NoticiaTesteId=Convert.ToInt32(reader["noticiaTesteId"].ToString());
			
			if (reader["dataCadastro"] != DBNull.Value)
				entidade.DataCadastro=Convert.ToDateTime(reader["dataCadastro"].ToString());
			
			if (reader["workflowId"] != DBNull.Value) {
				entidade.Workflow = new Workflow();
				entidade.Workflow.WorkflowId = Convert.ToInt32(reader["workflowId"].ToString());
			}


		}		
		
	}
}
		