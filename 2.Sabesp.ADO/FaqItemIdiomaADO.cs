
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
	public class FaqItemIdiomaADO : ADOSuper, IFaqItemIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um FaqItemIdioma.
        /// </summary>
        /// <param name="entidade">FaqItemIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(FaqItemIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FaqItemIdioma ");
			sbSQL.Append(" (faqItemId, idiomaId, pergunta, resposta) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@faqItemId, @idiomaId, @pergunta, @resposta) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@faqItemId", DbType.Int32, entidade.FaqItem.FaqItemId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@pergunta", DbType.String, entidade.Pergunta);

			_db.AddInParameter(command, "@resposta", DbType.String, entidade.Resposta);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um FaqItemIdioma.
        /// </summary>
        /// <param name="entidade">FaqItemIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(FaqItemIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FaqItemIdioma SET ");
			sbSQL.Append(" pergunta=@pergunta, resposta=@resposta ");
			sbSQL.Append(" WHERE faqItemId=@faqItemId AND idiomaId=@idiomaId ");
            sbSQL.Append(" and idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@faqItemId", DbType.Int32, entidade.FaqItem.FaqItemId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@pergunta", DbType.String, entidade.Pergunta);
			_db.AddInParameter(command, "@resposta", DbType.String, entidade.Resposta);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um FaqItemIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">FaqItemIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FaqItemIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM FaqItemIdioma ");
			sbSQL.Append("WHERE faqItemId=@faqItemId AND idiomaId=@idiomaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@faqItemId", DbType.Int32, entidade.FaqItem.FaqItemId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um FaqItemIdioma.
		/// </summary>
        /// <param name="entidade">FaqItemIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FaqItemIdioma</returns>
		public FaqItemIdioma Carregar(FaqItemIdioma entidade) {		
		
			FaqItemIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM FaqItemIdioma WHERE faqItemId=@faqItemId AND idiomaId=@idiomaId");
            sbSQL.Append(" and idiomaId=@idiomaId ");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@faqItemId", DbType.Int32, entidade.FaqItem.FaqItemId);
            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new FaqItemIdioma();
				PopulaFaqItemIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de FaqItemIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FaqItemIdioma.</returns>
		public List<FaqItemIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<FaqItemIdioma> entidadesRetorno = new List<FaqItemIdioma>();
			
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
				sbOrder.Append( " ORDER BY faqItemId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FaqItemIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FaqItemIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FaqItemIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT FaqItemIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FaqItemIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT FaqItemIdioma.* FROM FaqItemIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FaqItemIdioma entidadeRetorno = new FaqItemIdioma();
                PopulaFaqItemIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os FaqItemIdioma existentes na base de dados.
        /// </summary>
		public List<FaqItemIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FaqItemIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FaqItemIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM FaqItemIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um FaqItemIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">FaqItemIdioma a ser populado(.</param>
		public static void PopulaFaqItemIdioma(IDataReader reader, FaqItemIdioma entidade) 
		{						
			if (reader["pergunta"] != DBNull.Value)
				entidade.Pergunta = reader["pergunta"].ToString();
			
			if (reader["resposta"] != DBNull.Value)
				entidade.Resposta = reader["resposta"].ToString();
			
			if (reader["faqItemId"] != DBNull.Value) {
				entidade.FaqItem = new FaqItem();
				entidade.FaqItem.FaqItemId = Convert.ToInt32(reader["faqItemId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		