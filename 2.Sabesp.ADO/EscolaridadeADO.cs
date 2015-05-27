
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
	public class EscolaridadeADO : ADOSuper, IEscolaridadeDAL {
	
	    /// <summary>
        /// Método que persiste um Escolaridade.
        /// </summary>
        /// <param name="entidade">Escolaridade contendo os dados a serem persistidos.</param>	
		public void Inserir(Escolaridade entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Escolaridade ");
			sbSQL.Append(" (escolaridadeId, nomeEscolaridade) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@escolaridadeId, @nomeEscolaridade) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@escolaridadeId", DbType.Int32, entidade.EscolaridadeId);

			_db.AddInParameter(command, "@nomeEscolaridade", DbType.String, entidade.NomeEscolaridade);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um Escolaridade.
        /// </summary>
        /// <param name="entidade">Escolaridade contendo os dados a serem atualizados.</param>
		public void Atualizar(Escolaridade entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Escolaridade SET ");
			sbSQL.Append(" nomeEscolaridade=@nomeEscolaridade ");
			sbSQL.Append(" WHERE escolaridadeId=@escolaridadeId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@escolaridadeId", DbType.Int32, entidade.EscolaridadeId);
			_db.AddInParameter(command, "@nomeEscolaridade", DbType.String, entidade.NomeEscolaridade);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um Escolaridade da base de dados.
        /// </summary>
        /// <param name="entidade">Escolaridade a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Escolaridade entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM Escolaridade ");
			sbSQL.Append("WHERE escolaridadeId=@escolaridadeId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@escolaridadeId", DbType.Int32, entidade.EscolaridadeId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um Escolaridade.
		/// </summary>
        /// <param name="entidade">Escolaridade a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Escolaridade</returns>
		public Escolaridade Carregar(int escolaridadeId) {		
			Escolaridade entidade = new Escolaridade();
			entidade.EscolaridadeId = escolaridadeId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um Escolaridade.
		/// </summary>
        /// <param name="entidade">Escolaridade a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Escolaridade</returns>
		public Escolaridade Carregar(Escolaridade entidade) {		
		
			Escolaridade entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM Escolaridade WHERE escolaridadeId=@escolaridadeId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@escolaridadeId", DbType.Int32, entidade.EscolaridadeId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new Escolaridade();
				PopulaEscolaridade(reader, entidadeRetorno);
			}
			
			reader.Close();
			
			return entidadeRetorno;
		}
		

		/// <summary>
        /// Método que retorna uma coleção de Escolaridade.
        /// </summary>
        /// <param name="entidade">FormularioCursoVazamento relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Escolaridade.</returns>
		public List<Escolaridade> Carregar(FormularioCursoVazamento entidade)
		{		
			List<Escolaridade> entidadesRetorno = new List<Escolaridade>();
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT Escolaridade.* FROM Escolaridade INNER JOIN FormularioCursoVazamento ON Escolaridade.escolaridadeId=FormularioCursoVazamento.escolaridadeId WHERE FormularioCursoVazamento.formularioCursoVazamentoId=@formularioCursoVazamentoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);
								
			IDataReader reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                Escolaridade entidadeRetorno = new Escolaridade();
                PopulaEscolaridade(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
			
            reader.Close();

            return entidadesRetorno;
		}
		
		
		/// <summary>
        /// Método que retorna uma coleção de Escolaridade.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Escolaridade.</returns>
		public List<Escolaridade> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<Escolaridade> entidadesRetorno = new List<Escolaridade>();
			
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
				sbOrder.Append( " ORDER BY escolaridadeId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Escolaridade");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Escolaridade WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Escolaridade ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT Escolaridade.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Escolaridade ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT Escolaridade.* FROM Escolaridade ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                Escolaridade entidadeRetorno = new Escolaridade();
                PopulaEscolaridade(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
			
            reader.Close();

            return entidadesRetorno;
		}	
		
		/// <summary>
        /// Método que retorna todas os Escolaridade existentes na base de dados.
        /// </summary>
		public List<Escolaridade> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de Escolaridade na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de Escolaridade na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM Escolaridade");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um Escolaridade baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">Escolaridade a ser populado(.</param>
		public static void PopulaEscolaridade(IDataReader reader, Escolaridade entidade) 
		{						
			if (reader["escolaridadeId"] != DBNull.Value)
				entidade.EscolaridadeId = Convert.ToInt32(reader["escolaridadeId"].ToString());
			
			if (reader["nomeEscolaridade"] != DBNull.Value)
				entidade.NomeEscolaridade = reader["nomeEscolaridade"].ToString();
			

		}		
		
	}
}
		