
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
	public class ProjetoEspecialIdiomaADO : ADOSuper, IProjetoEspecialIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um ProjetoEspecialIdioma.
        /// </summary>
        /// <param name="entidade">ProjetoEspecialIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(ProjetoEspecialIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ProjetoEspecialIdioma ");
			sbSQL.Append(" (projetoEspecialId, idiomaId, tituloProjeto, chamadaProjeto) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@projetoEspecialId, @idiomaId, @tituloProjeto, @chamadaProjeto) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@projetoEspecialId", DbType.Int32, entidade.ProjetoEspecial.ProjetoEspecialId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			if (entidade.TituloProjeto != null ) 
				_db.AddInParameter(command, "@tituloProjeto", DbType.String, entidade.TituloProjeto);
			else
				_db.AddInParameter(command, "@tituloProjeto", DbType.String, null);

			if (entidade.ChamadaProjeto != null ) 
				_db.AddInParameter(command, "@chamadaProjeto", DbType.String, entidade.ChamadaProjeto);
			else
				_db.AddInParameter(command, "@chamadaProjeto", DbType.String, null);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um ProjetoEspecialIdioma.
        /// </summary>
        /// <param name="entidade">ProjetoEspecialIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(ProjetoEspecialIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ProjetoEspecialIdioma SET ");
			sbSQL.Append(" tituloProjeto=@tituloProjeto, chamadaProjeto=@chamadaProjeto ");
			sbSQL.Append(" WHERE projetoEspecialId=@projetoEspecialId AND idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@projetoEspecialId", DbType.Int32, entidade.ProjetoEspecial.ProjetoEspecialId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			if (entidade.TituloProjeto != null ) 
				_db.AddInParameter(command, "@tituloProjeto", DbType.String, entidade.TituloProjeto);
			else
				_db.AddInParameter(command, "@tituloProjeto", DbType.String, null);
			if (entidade.ChamadaProjeto != null ) 
				_db.AddInParameter(command, "@chamadaProjeto", DbType.String, entidade.ChamadaProjeto);
			else
				_db.AddInParameter(command, "@chamadaProjeto", DbType.String, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um ProjetoEspecialIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">ProjetoEspecialIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ProjetoEspecialIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM ProjetoEspecialIdioma ");
			sbSQL.Append("WHERE projetoEspecialId=@projetoEspecialId AND idiomaId=@idiomaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@projetoEspecialId", DbType.Int32, entidade.ProjetoEspecial.ProjetoEspecialId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um ProjetoEspecialIdioma.
		/// </summary>
        /// <param name="entidade">ProjetoEspecialIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ProjetoEspecialIdioma</returns>
		public ProjetoEspecialIdioma Carregar(ProjetoEspecialIdioma entidade) {		
		
			ProjetoEspecialIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM ProjetoEspecialIdioma WHERE projetoEspecialId=@projetoEspecialId AND idiomaId=@idiomaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@projetoEspecialId", DbType.Int32, entidade.ProjetoEspecial.ProjetoEspecialId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new ProjetoEspecialIdioma();
				PopulaProjetoEspecialIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de ProjetoEspecialIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ProjetoEspecialIdioma.</returns>
		public List<ProjetoEspecialIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<ProjetoEspecialIdioma> entidadesRetorno = new List<ProjetoEspecialIdioma>();
			
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
				sbOrder.Append( " ORDER BY projetoEspecialId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ProjetoEspecialIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ProjetoEspecialIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ProjetoEspecialIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT ProjetoEspecialIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ProjetoEspecialIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT ProjetoEspecialIdioma.* FROM ProjetoEspecialIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                ProjetoEspecialIdioma entidadeRetorno = new ProjetoEspecialIdioma();
                PopulaProjetoEspecialIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os ProjetoEspecialIdioma existentes na base de dados.
        /// </summary>
		public List<ProjetoEspecialIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ProjetoEspecialIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ProjetoEspecialIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM ProjetoEspecialIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um ProjetoEspecialIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">ProjetoEspecialIdioma a ser populado(.</param>
		public static void PopulaProjetoEspecialIdioma(IDataReader reader, ProjetoEspecialIdioma entidade) 
		{						
			if (reader["tituloProjeto"] != DBNull.Value)
				entidade.TituloProjeto = reader["tituloProjeto"].ToString();
			
			if (reader["chamadaProjeto"] != DBNull.Value)
				entidade.ChamadaProjeto = reader["chamadaProjeto"].ToString();
			
			if (reader["projetoEspecialId"] != DBNull.Value) {
				entidade.ProjetoEspecial = new ProjetoEspecial();
				entidade.ProjetoEspecial.ProjetoEspecialId = Convert.ToInt32(reader["projetoEspecialId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		