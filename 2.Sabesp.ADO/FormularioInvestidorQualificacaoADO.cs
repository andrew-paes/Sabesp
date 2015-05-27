
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
	public class FormularioInvestidorQualificacaoADO : ADOSuper, IFormularioInvestidorQualificacaoDAL {
	
	    /// <summary>
        /// Método que persiste um FormularioInvestidorQualificacao.
        /// </summary>
        /// <param name="entidade">FormularioInvestidorQualificacao contendo os dados a serem persistidos.</param>	
		public void Inserir(FormularioInvestidorQualificacao entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioInvestidorQualificacao ");
			sbSQL.Append(" (formularioInvestidorQualificacaoId, qualificacao) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@formularioInvestidorQualificacaoId, @qualificacao) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@formularioInvestidorQualificacaoId", DbType.Int32, entidade.FormularioInvestidorQualificacaoId);

			_db.AddInParameter(command, "@qualificacao", DbType.String, entidade.Qualificacao);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um FormularioInvestidorQualificacao.
        /// </summary>
        /// <param name="entidade">FormularioInvestidorQualificacao contendo os dados a serem atualizados.</param>
		public void Atualizar(FormularioInvestidorQualificacao entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FormularioInvestidorQualificacao SET ");
			sbSQL.Append(" qualificacao=@qualificacao ");
			sbSQL.Append(" WHERE formularioInvestidorQualificacaoId=@formularioInvestidorQualificacaoId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@formularioInvestidorQualificacaoId", DbType.Int32, entidade.FormularioInvestidorQualificacaoId);
			_db.AddInParameter(command, "@qualificacao", DbType.String, entidade.Qualificacao);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um FormularioInvestidorQualificacao da base de dados.
        /// </summary>
        /// <param name="entidade">FormularioInvestidorQualificacao a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FormularioInvestidorQualificacao entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM FormularioInvestidorQualificacao ");
			sbSQL.Append("WHERE formularioInvestidorQualificacaoId=@formularioInvestidorQualificacaoId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@formularioInvestidorQualificacaoId", DbType.Int32, entidade.FormularioInvestidorQualificacaoId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um FormularioInvestidorQualificacao.
		/// </summary>
        /// <param name="entidade">FormularioInvestidorQualificacao a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioInvestidorQualificacao</returns>
		public FormularioInvestidorQualificacao Carregar(int formularioInvestidorQualificacaoId) {		
			FormularioInvestidorQualificacao entidade = new FormularioInvestidorQualificacao();
			entidade.FormularioInvestidorQualificacaoId = formularioInvestidorQualificacaoId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um FormularioInvestidorQualificacao.
		/// </summary>
        /// <param name="entidade">FormularioInvestidorQualificacao a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioInvestidorQualificacao</returns>
		public FormularioInvestidorQualificacao Carregar(FormularioInvestidorQualificacao entidade) {		
		
			FormularioInvestidorQualificacao entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM FormularioInvestidorQualificacao WHERE formularioInvestidorQualificacaoId=@formularioInvestidorQualificacaoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@formularioInvestidorQualificacaoId", DbType.Int32, entidade.FormularioInvestidorQualificacaoId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new FormularioInvestidorQualificacao();
				PopulaFormularioInvestidorQualificacao(reader, entidadeRetorno);
			}
			
			reader.Close();
			
			return entidadeRetorno;
		}
		

		/// <summary>
        /// Método que retorna uma coleção de FormularioInvestidorQualificacao.
        /// </summary>
        /// <param name="entidade">FormularioInvestidor relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de FormularioInvestidorQualificacao.</returns>
		public List<FormularioInvestidorQualificacao> Carregar(FormularioInvestidor entidade)
		{		
			List<FormularioInvestidorQualificacao> entidadesRetorno = new List<FormularioInvestidorQualificacao>();
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT FormularioInvestidorQualificacao.* FROM FormularioInvestidorQualificacao INNER JOIN FormularioInvestidor ON FormularioInvestidorQualificacao.formularioInvestidorQualificacaoId=FormularioInvestidor.formularioInvestidorQualificacaoId WHERE FormularioInvestidor.formularioInvestidorId=@formularioInvestidorId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioInvestidorId", DbType.Int32, entidade.FormularioInvestidorId);
								
			IDataReader reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FormularioInvestidorQualificacao entidadeRetorno = new FormularioInvestidorQualificacao();
                PopulaFormularioInvestidorQualificacao(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
			
            reader.Close();

            return entidadesRetorno;
		}
		
		
		/// <summary>
        /// Método que retorna uma coleção de FormularioInvestidorQualificacao.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FormularioInvestidorQualificacao.</returns>
		public List<FormularioInvestidorQualificacao> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<FormularioInvestidorQualificacao> entidadesRetorno = new List<FormularioInvestidorQualificacao>();
			
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
				sbOrder.Append( " ORDER BY formularioInvestidorQualificacaoId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FormularioInvestidorQualificacao");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioInvestidorQualificacao WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioInvestidorQualificacao ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT FormularioInvestidorQualificacao.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FormularioInvestidorQualificacao ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT FormularioInvestidorQualificacao.* FROM FormularioInvestidorQualificacao ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FormularioInvestidorQualificacao entidadeRetorno = new FormularioInvestidorQualificacao();
                PopulaFormularioInvestidorQualificacao(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
			
            reader.Close();

            return entidadesRetorno;
		}	
		
		/// <summary>
        /// Método que retorna todas os FormularioInvestidorQualificacao existentes na base de dados.
        /// </summary>
		public List<FormularioInvestidorQualificacao> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FormularioInvestidorQualificacao na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FormularioInvestidorQualificacao na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM FormularioInvestidorQualificacao");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um FormularioInvestidorQualificacao baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">FormularioInvestidorQualificacao a ser populado(.</param>
		public static void PopulaFormularioInvestidorQualificacao(IDataReader reader, FormularioInvestidorQualificacao entidade) 
		{						
			if (reader["formularioInvestidorQualificacaoId"] != DBNull.Value)
				entidade.FormularioInvestidorQualificacaoId = Convert.ToInt32(reader["formularioInvestidorQualificacaoId"].ToString());
			
			if (reader["qualificacao"] != DBNull.Value)
				entidade.Qualificacao = reader["qualificacao"].ToString();
			

		}		
		
	}
}
		