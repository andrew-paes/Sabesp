
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
	public class NoticiaTesteIdiomaADO : ADOSuper, INoticiaTesteIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um NoticiaTesteIdioma.
        /// </summary>
        /// <param name="entidade">NoticiaTesteIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(NoticiaTesteIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO NoticiaTesteIdioma ");
			sbSQL.Append(" (noticiaTesteId, idiomaId, titulo, conteudo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@noticiaTesteId, @idiomaId, @titulo, @conteudo) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@noticiaTesteId", DbType.Int32, entidade.NoticiaTeste.NoticiaTesteId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@titulo", DbType.String, entidade.Titulo);

			_db.AddInParameter(command, "@conteudo", DbType.String, entidade.Conteudo);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um NoticiaTesteIdioma.
        /// </summary>
        /// <param name="entidade">NoticiaTesteIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(NoticiaTesteIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE NoticiaTesteIdioma SET ");
			sbSQL.Append(" noticiaTesteId=@noticiaTesteId, idiomaId=@idiomaId, titulo=@titulo, conteudo=@conteudo ");
			sbSQL.Append(" WHERE  ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@noticiaTesteId", DbType.Int32, entidade.NoticiaTeste.NoticiaTesteId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@titulo", DbType.String, entidade.Titulo);
			_db.AddInParameter(command, "@conteudo", DbType.String, entidade.Conteudo);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um NoticiaTesteIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">NoticiaTesteIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(NoticiaTesteIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM NoticiaTesteIdioma ");
			sbSQL.Append("WHERE  ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um NoticiaTesteIdioma.
		/// </summary>
        /// <param name="entidade">NoticiaTesteIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>NoticiaTesteIdioma</returns>
		public NoticiaTesteIdioma Carregar(NoticiaTesteIdioma entidade) {		
		
			NoticiaTesteIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM NoticiaTesteIdioma WHERE ");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new NoticiaTesteIdioma();
				PopulaNoticiaTesteIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de NoticiaTesteIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos NoticiaTesteIdioma.</returns>
		public List<NoticiaTesteIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<NoticiaTesteIdioma> entidadesRetorno = new List<NoticiaTesteIdioma>();
			
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
				sbOrder.Append( " ORDER BY " );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM NoticiaTesteIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM NoticiaTesteIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM NoticiaTesteIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT NoticiaTesteIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM NoticiaTesteIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT NoticiaTesteIdioma.* FROM NoticiaTesteIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                NoticiaTesteIdioma entidadeRetorno = new NoticiaTesteIdioma();
                PopulaNoticiaTesteIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os NoticiaTesteIdioma existentes na base de dados.
        /// </summary>
		public List<NoticiaTesteIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de NoticiaTesteIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de NoticiaTesteIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM NoticiaTesteIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um NoticiaTesteIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">NoticiaTesteIdioma a ser populado(.</param>
		public static void PopulaNoticiaTesteIdioma(IDataReader reader, NoticiaTesteIdioma entidade) 
		{						
			if (reader["titulo"] != DBNull.Value)
				entidade.Titulo=reader["titulo"].ToString();
			
			if (reader["conteudo"] != DBNull.Value)
				entidade.Conteudo=reader["conteudo"].ToString();
			
			if (reader["noticiaTesteId"] != DBNull.Value) {
				entidade.NoticiaTeste = new NoticiaTeste();
				entidade.NoticiaTeste.NoticiaTesteId = Convert.ToInt32(reader["noticiaTesteId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		