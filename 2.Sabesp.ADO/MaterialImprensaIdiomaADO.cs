
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
	public class MaterialImprensaIdiomaADO : ADOSuper, IMaterialImprensaIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um MaterialImprensaIdioma.
        /// </summary>
        /// <param name="entidade">MaterialImprensaIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(MaterialImprensaIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO MaterialImprensaIdioma ");
			sbSQL.Append(" (materialImprensaId, idiomaId, arquivoId, tituloMaterial, textoMaterial) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@materialImprensaId, @idiomaId, @arquivoId, @tituloMaterial, @textoMaterial) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@materialImprensaId", DbType.Int32, entidade.MaterialImprensa.MaterialImprensaId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.Arquivo.ArquivoId);

			if (entidade.TituloMaterial != null ) 
				_db.AddInParameter(command, "@tituloMaterial", DbType.String, entidade.TituloMaterial);
			else
				_db.AddInParameter(command, "@tituloMaterial", DbType.String, null);

			if (entidade.TextoMaterial != null ) 
				_db.AddInParameter(command, "@textoMaterial", DbType.String, entidade.TextoMaterial);
			else
				_db.AddInParameter(command, "@textoMaterial", DbType.String, null);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um MaterialImprensaIdioma.
        /// </summary>
        /// <param name="entidade">MaterialImprensaIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(MaterialImprensaIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE MaterialImprensaIdioma SET ");
			sbSQL.Append(" arquivoId=@arquivoId, tituloMaterial=@tituloMaterial, textoMaterial=@textoMaterial ");
			sbSQL.Append(" WHERE materialImprensaId=@materialImprensaId AND idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@materialImprensaId", DbType.Int32, entidade.MaterialImprensa.MaterialImprensaId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.Arquivo.ArquivoId);
			if (entidade.TituloMaterial != null ) 
				_db.AddInParameter(command, "@tituloMaterial", DbType.String, entidade.TituloMaterial);
			else
				_db.AddInParameter(command, "@tituloMaterial", DbType.String, null);
			if (entidade.TextoMaterial != null ) 
				_db.AddInParameter(command, "@textoMaterial", DbType.String, entidade.TextoMaterial);
			else
				_db.AddInParameter(command, "@textoMaterial", DbType.String, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um MaterialImprensaIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">MaterialImprensaIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(MaterialImprensaIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM MaterialImprensaIdioma ");
			sbSQL.Append("WHERE materialImprensaId=@materialImprensaId AND idiomaId=@idiomaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@materialImprensaId", DbType.Int32, entidade.MaterialImprensa.MaterialImprensaId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um MaterialImprensaIdioma.
		/// </summary>
        /// <param name="entidade">MaterialImprensaIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>MaterialImprensaIdioma</returns>
		public MaterialImprensaIdioma Carregar(MaterialImprensaIdioma entidade) {		
		
			MaterialImprensaIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM MaterialImprensaIdioma WHERE materialImprensaId=@materialImprensaId AND idiomaId=@idiomaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@materialImprensaId", DbType.Int32, entidade.MaterialImprensa.MaterialImprensaId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new MaterialImprensaIdioma();
				PopulaMaterialImprensaIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de MaterialImprensaIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos MaterialImprensaIdioma.</returns>
		public List<MaterialImprensaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<MaterialImprensaIdioma> entidadesRetorno = new List<MaterialImprensaIdioma>();
			
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
				sbOrder.Append( " ORDER BY materialImprensaId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM MaterialImprensaIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM MaterialImprensaIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM MaterialImprensaIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT MaterialImprensaIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM MaterialImprensaIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT MaterialImprensaIdioma.* FROM MaterialImprensaIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                MaterialImprensaIdioma entidadeRetorno = new MaterialImprensaIdioma();
                PopulaMaterialImprensaIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os MaterialImprensaIdioma existentes na base de dados.
        /// </summary>
		public List<MaterialImprensaIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de MaterialImprensaIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de MaterialImprensaIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM MaterialImprensaIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um MaterialImprensaIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">MaterialImprensaIdioma a ser populado(.</param>
		public static void PopulaMaterialImprensaIdioma(IDataReader reader, MaterialImprensaIdioma entidade) 
		{						
			if (reader["tituloMaterial"] != DBNull.Value)
				entidade.TituloMaterial = reader["tituloMaterial"].ToString();
			
			if (reader["textoMaterial"] != DBNull.Value)
				entidade.TextoMaterial = reader["textoMaterial"].ToString();
			
			if (reader["materialImprensaId"] != DBNull.Value) {
				entidade.MaterialImprensa = new MaterialImprensa();
				entidade.MaterialImprensa.MaterialImprensaId = Convert.ToInt32(reader["materialImprensaId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}

			if (reader["arquivoId"] != DBNull.Value) {
				entidade.Arquivo = new Arquivo();
				entidade.Arquivo.ArquivoId = Convert.ToInt32(reader["arquivoId"].ToString());
			}


		}		
		
	}
}
		