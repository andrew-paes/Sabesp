
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
	public class GlossarioIdiomaADO : ADOSuper, IGlossarioIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um GlossarioIdioma.
        /// </summary>
        /// <param name="entidade">GlossarioIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(GlossarioIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO GlossarioIdioma ");
			sbSQL.Append(" (palavra, descricao, idiomaId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@palavra, @descricao, @idiomaId) ");											

			sbSQL.Append(" ; SET @glossarioId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@glossarioId", DbType.Int32, 8);

			_db.AddInParameter(command, "@palavra", DbType.String, entidade.Palavra);

			_db.AddInParameter(command, "@descricao", DbType.String, entidade.Descricao);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.GlossarioId = Convert.ToInt32(_db.GetParameterValue(command, "@glossarioId"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um GlossarioIdioma.
        /// </summary>
        /// <param name="entidade">GlossarioIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(GlossarioIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE GlossarioIdioma SET ");
			sbSQL.Append(" palavra=@palavra, descricao=@descricao ");
			sbSQL.Append(" WHERE glossarioId=@glossarioId AND idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@glossarioId", DbType.Int32, entidade.Glossario.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@palavra", DbType.String, entidade.Palavra);
			_db.AddInParameter(command, "@descricao", DbType.String, entidade.Descricao);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um GlossarioIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">GlossarioIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(GlossarioIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM GlossarioIdioma ");
			sbSQL.Append("WHERE glossarioId=@glossarioId AND idiomaId=@idiomaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@glossarioId", DbType.Int32, entidade.Glossario.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um GlossarioIdioma.
		/// </summary>
        /// <param name="entidade">GlossarioIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>GlossarioIdioma</returns>
		public GlossarioIdioma Carregar(GlossarioIdioma entidade) {		
		
			GlossarioIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM GlossarioIdioma WHERE glossarioId=@glossarioId AND idiomaId=@idiomaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@glossarioId", DbType.Int32, entidade.Glossario.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new GlossarioIdioma();
				PopulaGlossarioIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de GlossarioIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos GlossarioIdioma.</returns>
		public List<GlossarioIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<GlossarioIdioma> entidadesRetorno = new List<GlossarioIdioma>();
			
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
				sbOrder.Append( " ORDER BY glossarioId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM GlossarioIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM GlossarioIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM GlossarioIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT GlossarioIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM GlossarioIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT GlossarioIdioma.* FROM GlossarioIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                GlossarioIdioma entidadeRetorno = new GlossarioIdioma();
                PopulaGlossarioIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os GlossarioIdioma existentes na base de dados.
        /// </summary>
		public List<GlossarioIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de GlossarioIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de GlossarioIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM GlossarioIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um GlossarioIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">GlossarioIdioma a ser populado(.</param>
		public static void PopulaGlossarioIdioma(IDataReader reader, GlossarioIdioma entidade) 
		{						
			if (reader["palavra"] != DBNull.Value)
				entidade.Palavra = reader["palavra"].ToString();
			
			if (reader["descricao"] != DBNull.Value)
				entidade.Descricao = reader["descricao"].ToString();
			
			if (reader["glossarioId"] != DBNull.Value) {
				entidade.Glossario = new Glossario();
                entidade.Glossario.Conteudo = new Conteudo();
				entidade.Glossario.Conteudo.ConteudoId = Convert.ToInt32(reader["glossarioId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		