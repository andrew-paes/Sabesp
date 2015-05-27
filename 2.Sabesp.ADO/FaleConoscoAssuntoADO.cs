
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
	public class FaleConoscoAssuntoADO : ADOSuper, IFaleConoscoAssuntoDAL {
	
	    /// <summary>
        /// Método que persiste um FaleConoscoAssunto.
        /// </summary>
        /// <param name="entidade">FaleConoscoAssunto contendo os dados a serem persistidos.</param>	
		public void Inserir(FaleConoscoAssunto entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FaleConoscoAssunto ");
			sbSQL.Append(" (assunto, email, ativo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@assunto, @email, @ativo) ");											

			sbSQL.Append(" ; SET @faleConoscoAssuntoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@faleConoscoAssuntoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@assunto", DbType.String, entidade.Assunto);

			if (entidade.Email != null ) 
				_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			else
				_db.AddInParameter(command, "@email", DbType.String, null);

			if (entidade.Ativo != null ) 
				_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			else
				_db.AddInParameter(command, "@ativo", DbType.Int32, null);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.FaleConoscoAssuntoId = Convert.ToInt32(_db.GetParameterValue(command, "@faleConoscoAssuntoId"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um FaleConoscoAssunto.
        /// </summary>
        /// <param name="entidade">FaleConoscoAssunto contendo os dados a serem atualizados.</param>
		public void Atualizar(FaleConoscoAssunto entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FaleConoscoAssunto SET ");
			sbSQL.Append(" assunto=@assunto, email=@email, ativo=@ativo ");
			sbSQL.Append(" WHERE faleConoscoAssuntoId=@faleConoscoAssuntoId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@faleConoscoAssuntoId", DbType.Int32, entidade.FaleConoscoAssuntoId);
			_db.AddInParameter(command, "@assunto", DbType.String, entidade.Assunto);
			if (entidade.Email != null ) 
				_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			else
				_db.AddInParameter(command, "@email", DbType.String, null);
			if (entidade.Ativo != null ) 
				_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			else
				_db.AddInParameter(command, "@ativo", DbType.Int32, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um FaleConoscoAssunto da base de dados.
        /// </summary>
        /// <param name="entidade">FaleConoscoAssunto a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FaleConoscoAssunto entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM FaleConoscoAssunto ");
			sbSQL.Append("WHERE faleConoscoAssuntoId=@faleConoscoAssuntoId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@faleConoscoAssuntoId", DbType.Int32, entidade.FaleConoscoAssuntoId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um FaleConoscoAssunto.
		/// </summary>
        /// <param name="entidade">FaleConoscoAssunto a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FaleConoscoAssunto</returns>
		public FaleConoscoAssunto Carregar(int faleConoscoAssuntoId) {		
			FaleConoscoAssunto entidade = new FaleConoscoAssunto();
			entidade.FaleConoscoAssuntoId = faleConoscoAssuntoId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um FaleConoscoAssunto.
		/// </summary>
        /// <param name="entidade">FaleConoscoAssunto a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FaleConoscoAssunto</returns>
		public FaleConoscoAssunto Carregar(FaleConoscoAssunto entidade) {		
		
			FaleConoscoAssunto entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM FaleConoscoAssunto WHERE faleConoscoAssuntoId=@faleConoscoAssuntoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@faleConoscoAssuntoId", DbType.Int32, entidade.FaleConoscoAssuntoId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new FaleConoscoAssunto();
				PopulaFaleConoscoAssunto(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		

		/// <summary>
        /// Método que retorna uma coleção de FaleConoscoAssunto.
        /// </summary>
        /// <param name="entidade">FaleConoscoMensagem relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de FaleConoscoAssunto.</returns>
		public List<FaleConoscoAssunto> Carregar(FaleConoscoMensagem entidade)
		{		
			List<FaleConoscoAssunto> entidadesRetorno = new List<FaleConoscoAssunto>();
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT FaleConoscoAssunto.* FROM FaleConoscoAssunto INNER JOIN FaleConoscoMensagem ON FaleConoscoAssunto.faleConoscoAssuntoId=FaleConoscoMensagem.faleConoscoAssuntoId WHERE FaleConoscoMensagem.faleConoscoMensagemId=@faleConoscoMensagemId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@faleConoscoMensagemId", DbType.Int32, entidade.FaleConoscoMensagemId);
								
			IDataReader reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FaleConoscoAssunto entidadeRetorno = new FaleConoscoAssunto();
                PopulaFaleConoscoAssunto(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
			
		}
		
		
		/// <summary>
        /// Método que retorna uma coleção de FaleConoscoAssunto.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FaleConoscoAssunto.</returns>
		public List<FaleConoscoAssunto> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<FaleConoscoAssunto> entidadesRetorno = new List<FaleConoscoAssunto>();
			
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
				sbOrder.Append( " ORDER BY faleConoscoAssuntoId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FaleConoscoAssunto");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FaleConoscoAssunto WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FaleConoscoAssunto ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT FaleConoscoAssunto.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FaleConoscoAssunto ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT FaleConoscoAssunto.* FROM FaleConoscoAssunto ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FaleConoscoAssunto entidadeRetorno = new FaleConoscoAssunto();
                PopulaFaleConoscoAssunto(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os FaleConoscoAssunto existentes na base de dados.
        /// </summary>
		public List<FaleConoscoAssunto> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FaleConoscoAssunto na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FaleConoscoAssunto na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM FaleConoscoAssunto");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um FaleConoscoAssunto baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">FaleConoscoAssunto a ser populado(.</param>
		public static void PopulaFaleConoscoAssunto(IDataReader reader, FaleConoscoAssunto entidade) 
		{						
			if (reader["faleConoscoAssuntoId"] != DBNull.Value)
				entidade.FaleConoscoAssuntoId = Convert.ToInt32(reader["faleConoscoAssuntoId"].ToString());
			
			if (reader["assunto"] != DBNull.Value)
				entidade.Assunto = reader["assunto"].ToString();
			
			if (reader["email"] != DBNull.Value)
				entidade.Email = reader["email"].ToString();
			
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());
			

		}		
		
	}
}
		