
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
	public class EventoCategoriaIdiomaADO : ADOSuper, IEventoCategoriaIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um EventoCategoriaIdioma.
        /// </summary>
        /// <param name="entidade">EventoCategoriaIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(EventoCategoriaIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO EventoCategoriaIdioma ");
			sbSQL.Append(" (eventoCategoriaId, categoriaEvento, idiomaId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@eventoCategoriaId, @categoriaEvento, @idiomaId) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@eventoCategoriaId", DbType.Int32, entidade.EventoCategoria.EventoCategoriaId);

			_db.AddInParameter(command, "@categoriaEvento", DbType.String, entidade.CategoriaEvento);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um EventoCategoriaIdioma.
        /// </summary>
        /// <param name="entidade">EventoCategoriaIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(EventoCategoriaIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE EventoCategoriaIdioma SET ");
			sbSQL.Append(" categoriaEvento=@categoriaEvento, idiomaId=@idiomaId ");
			sbSQL.Append(" WHERE eventoCategoriaId=@eventoCategoriaId ");
            sbSQL.Append(" and idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@eventoCategoriaId", DbType.Int32, entidade.EventoCategoria.EventoCategoriaId);
			_db.AddInParameter(command, "@categoriaEvento", DbType.String, entidade.CategoriaEvento);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um EventoCategoriaIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">EventoCategoriaIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(EventoCategoriaIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM EventoCategoriaIdioma ");
			sbSQL.Append("WHERE eventoCategoriaId=@eventoCategoriaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@eventoCategoriaId", DbType.Int32, entidade.EventoCategoria.EventoCategoriaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um EventoCategoriaIdioma.
		/// </summary>
        /// <param name="entidade">EventoCategoriaIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>EventoCategoriaIdioma</returns>
		public EventoCategoriaIdioma Carregar(EventoCategoriaIdioma entidade) {		
		
			EventoCategoriaIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM EventoCategoriaIdioma WHERE eventoCategoriaId=@eventoCategoriaId");
            sbSQL.Append(" and idiomaId=@idiomaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@eventoCategoriaId", DbType.Int32, entidade.EventoCategoria.EventoCategoriaId);
            _db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new EventoCategoriaIdioma();
				PopulaEventoCategoriaIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de EventoCategoriaIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos EventoCategoriaIdioma.</returns>
		public List<EventoCategoriaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<EventoCategoriaIdioma> entidadesRetorno = new List<EventoCategoriaIdioma>();
			
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
				sbOrder.Append( " ORDER BY eventoCategoriaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM EventoCategoriaIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM EventoCategoriaIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM EventoCategoriaIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT EventoCategoriaIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM EventoCategoriaIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT EventoCategoriaIdioma.* FROM EventoCategoriaIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                EventoCategoriaIdioma entidadeRetorno = new EventoCategoriaIdioma();
                PopulaEventoCategoriaIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os EventoCategoriaIdioma existentes na base de dados.
        /// </summary>
		public List<EventoCategoriaIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de EventoCategoriaIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de EventoCategoriaIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM EventoCategoriaIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um EventoCategoriaIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">EventoCategoriaIdioma a ser populado(.</param>
		public static void PopulaEventoCategoriaIdioma(IDataReader reader, EventoCategoriaIdioma entidade) 
		{						
			if (reader["categoriaEvento"] != DBNull.Value)
				entidade.CategoriaEvento=reader["categoriaEvento"].ToString();
			
			if (reader["eventoCategoriaId"] != DBNull.Value) {
				entidade.EventoCategoria = new EventoCategoria();
				entidade.EventoCategoriaId = Convert.ToInt32(reader["eventoCategoriaId"].ToString());
                entidade.EventoCategoria.EventoCategoriaId = Convert.ToInt32(reader["eventoCategoriaId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		