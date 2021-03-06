
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
	public class GlossarioADO : ADOSuper, IGlossarioDAL {
	
	    /// <summary>
        /// Método que persiste um Glossario.
        /// </summary>
        /// <param name="entidade">Glossario contendo os dados a serem persistidos.</param>	
		public void Inserir(Glossario entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Glossario ");
			sbSQL.Append(" (glossarioId, ativo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@glossarioId, @ativo) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@glossarioId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um Glossario.
        /// </summary>
        /// <param name="entidade">Glossario contendo os dados a serem atualizados.</param>
		public void Atualizar(Glossario entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Glossario SET ");
			sbSQL.Append(" ativo=@ativo ");
			sbSQL.Append(" WHERE glossarioId=@glossarioId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@glossarioId", DbType.Int32, entidade.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um Glossario da base de dados.
        /// </summary>
        /// <param name="entidade">Glossario a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Glossario entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM Glossario ");
			sbSQL.Append("WHERE glossarioId=@glossarioId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@glossarioId", DbType.Int32, entidade.Conteudo.ConteudoId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um Glossario.
		/// </summary>
        /// <param name="entidade">Glossario a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Glossario</returns>
		public Glossario Carregar(Glossario entidade) {		
		
			Glossario entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM Glossario WHERE glossarioId=@glossarioId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@glossarioId", DbType.Int32, entidade.Conteudo.ConteudoId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new Glossario();
				PopulaGlossario(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de Glossario.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Glossario.</returns>
		public List<Glossario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<Glossario> entidadesRetorno = new List<Glossario>();
			
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
				sbOrder.Append( " ORDER BY glossarioId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Glossario");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Glossario WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Glossario ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT Glossario.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Glossario ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT Glossario.* FROM Glossario ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                Glossario entidadeRetorno = new Glossario();
                PopulaGlossario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os Glossario existentes na base de dados.
        /// </summary>
		public List<Glossario> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de Glossario na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de Glossario na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM Glossario");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um Glossario baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">Glossario a ser populado(.</param>
		public static void PopulaGlossario(IDataReader reader, Glossario entidade) 
		{						
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());
			
			if (reader["glossarioId"] != DBNull.Value) {
				entidade.Conteudo = new Conteudo();
				entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["glossarioId"].ToString());
			}


		}		
		
	}
}
		