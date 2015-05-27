
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
	public class MaterialImprensaADO : ADOSuper, IMaterialImprensaDAL {
	
	    /// <summary>
        /// Método que persiste um MaterialImprensa.
        /// </summary>
        /// <param name="entidade">MaterialImprensa contendo os dados a serem persistidos.</param>	
		public void Inserir(MaterialImprensa entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO MaterialImprensa ");
			sbSQL.Append(" (ativo, arquivoIdThumb, dataHoraPublicacao) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@ativo, @arquivoIdThumb, @dataHoraPublicacao) ");											

			sbSQL.Append(" ; SET @materialImprensaId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@materialImprensaId", DbType.Int32, 8);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			_db.AddInParameter(command, "@arquivoIdThumb", DbType.Int32, entidade.ArquivoThumb.ArquivoId);

			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.MaterialImprensaId = Convert.ToInt32(_db.GetParameterValue(command, "@materialImprensaId"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um MaterialImprensa.
        /// </summary>
        /// <param name="entidade">MaterialImprensa contendo os dados a serem atualizados.</param>
		public void Atualizar(MaterialImprensa entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE MaterialImprensa SET ");
			sbSQL.Append(" ativo=@ativo, arquivoIdThumb=@arquivoIdThumb, dataHoraPublicacao=@dataHoraPublicacao ");
			sbSQL.Append(" WHERE materialImprensaId=@materialImprensaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@materialImprensaId", DbType.Int32, entidade.MaterialImprensaId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			_db.AddInParameter(command, "@arquivoIdThumb", DbType.Int32, entidade.ArquivoThumb.ArquivoId);
			_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um MaterialImprensa da base de dados.
        /// </summary>
        /// <param name="entidade">MaterialImprensa a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(MaterialImprensa entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM MaterialImprensa ");
			sbSQL.Append("WHERE materialImprensaId=@materialImprensaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@materialImprensaId", DbType.Int32, entidade.MaterialImprensaId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um MaterialImprensa.
		/// </summary>
        /// <param name="entidade">MaterialImprensa a ser carregado (somente o identificador é necessário).</param>
		/// <returns>MaterialImprensa</returns>
		public MaterialImprensa Carregar(int materialImprensaId) {		
			MaterialImprensa entidade = new MaterialImprensa();
			entidade.MaterialImprensaId = materialImprensaId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um MaterialImprensa.
		/// </summary>
        /// <param name="entidade">MaterialImprensa a ser carregado (somente o identificador é necessário).</param>
		/// <returns>MaterialImprensa</returns>
		public MaterialImprensa Carregar(MaterialImprensa entidade) {		
		
			MaterialImprensa entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM MaterialImprensa WHERE materialImprensaId=@materialImprensaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@materialImprensaId", DbType.Int32, entidade.MaterialImprensaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new MaterialImprensa();
				PopulaMaterialImprensa(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de MaterialImprensa.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos MaterialImprensa.</returns>
		public List<MaterialImprensa> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<MaterialImprensa> entidadesRetorno = new List<MaterialImprensa>();
			
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
				sbOrder.Append( " ORDER BY materialImprensaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM MaterialImprensa");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM MaterialImprensa WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM MaterialImprensa ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT MaterialImprensa.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM MaterialImprensa ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT MaterialImprensa.* FROM MaterialImprensa ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                MaterialImprensa entidadeRetorno = new MaterialImprensa();
                PopulaMaterialImprensa(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os MaterialImprensa existentes na base de dados.
        /// </summary>
		public List<MaterialImprensa> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de MaterialImprensa na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de MaterialImprensa na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM MaterialImprensa");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um MaterialImprensa baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">MaterialImprensa a ser populado(.</param>
		public static void PopulaMaterialImprensa(IDataReader reader, MaterialImprensa entidade) 
		{						
			if (reader["materialImprensaId"] != DBNull.Value)
				entidade.MaterialImprensaId = Convert.ToInt32(reader["materialImprensaId"].ToString());
			
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());
			
			if (reader["dataHoraPublicacao"] != DBNull.Value)
				entidade.DataHoraPublicacao = Convert.ToDateTime(reader["dataHoraPublicacao"].ToString());
			
			if (reader["arquivoIdThumb"] != DBNull.Value) {
				entidade.ArquivoThumb = new Arquivo();
				entidade.ArquivoThumb.ArquivoId = Convert.ToInt32(reader["arquivoIdThumb"].ToString());
			}


		}		
		
	}
}
		