
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
	public class FormularioCicloConferenciaADO : ADOSuper, IFormularioCicloConferenciaDAL {
	
	    /// <summary>
        /// Método que persiste um FormularioCicloConferencia.
        /// </summary>
        /// <param name="entidade">FormularioCicloConferencia contendo os dados a serem persistidos.</param>	
		public void Inserir(FormularioCicloConferencia entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioCicloConferencia ");
			sbSQL.Append(" (formularioId, dataHoraContato, nome, email, empresa, cep, estadoId, cidade, bairro, endereco, telefoneDDD, telefoneNumero, receberInformacaoSabesp, receberInformacaoEventos) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@formularioId, @dataHoraContato, @nome, @email, @empresa, @cep, @estadoId, @cidade, @bairro, @endereco, @telefoneDDD, @telefoneNumero, @receberInformacaoSabesp, @receberInformacaoEventos) ");											

			sbSQL.Append(" ; SET @formularioCicloConferenciaId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@formularioCicloConferenciaId", DbType.Int32, 8);

			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);

			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);

			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);

			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);

			if (entidade.Empresa != null ) 
				_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			else
				_db.AddInParameter(command, "@empresa", DbType.String, null);

			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);

			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);

			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);

			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);

			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);

			if (entidade.TelefoneDDD != null ) 
				_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);
			else
				_db.AddInParameter(command, "@telefoneDDD", DbType.String, null);

			if (entidade.TelefoneNumero != null ) 
				_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			else
				_db.AddInParameter(command, "@telefoneNumero", DbType.String, null);

			_db.AddInParameter(command, "@receberInformacaoSabesp", DbType.Int32, entidade.ReceberInformacaoSabesp);

			_db.AddInParameter(command, "@receberInformacaoEventos", DbType.Int32, entidade.ReceberInformacaoEventos);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.FormularioCicloConferenciaId = Convert.ToInt32(_db.GetParameterValue(command, "@formularioCicloConferenciaId"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um FormularioCicloConferencia.
        /// </summary>
        /// <param name="entidade">FormularioCicloConferencia contendo os dados a serem atualizados.</param>
		public void Atualizar(FormularioCicloConferencia entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FormularioCicloConferencia SET ");
			sbSQL.Append(" formularioId=@formularioId, dataHoraContato=@dataHoraContato, nome=@nome, email=@email, empresa=@empresa, cep=@cep, estadoId=@estadoId, cidade=@cidade, bairro=@bairro, endereco=@endereco, telefoneDDD=@telefoneDDD, telefoneNumero=@telefoneNumero, receberInformacaoSabesp=@receberInformacaoSabesp, receberInformacaoEventos=@receberInformacaoEventos ");
			sbSQL.Append(" WHERE formularioCicloConferenciaId=@formularioCicloConferenciaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@formularioCicloConferenciaId", DbType.Int32, entidade.FormularioCicloConferenciaId);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			if (entidade.Empresa != null ) 
				_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			else
				_db.AddInParameter(command, "@empresa", DbType.String, null);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			if (entidade.TelefoneDDD != null ) 
				_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);
			else
				_db.AddInParameter(command, "@telefoneDDD", DbType.String, null);
			if (entidade.TelefoneNumero != null ) 
				_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			else
				_db.AddInParameter(command, "@telefoneNumero", DbType.String, null);
			_db.AddInParameter(command, "@receberInformacaoSabesp", DbType.Int32, entidade.ReceberInformacaoSabesp);
			_db.AddInParameter(command, "@receberInformacaoEventos", DbType.Int32, entidade.ReceberInformacaoEventos);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um FormularioCicloConferencia da base de dados.
        /// </summary>
        /// <param name="entidade">FormularioCicloConferencia a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FormularioCicloConferencia entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM FormularioCicloConferencia ");
			sbSQL.Append("WHERE formularioCicloConferenciaId=@formularioCicloConferenciaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@formularioCicloConferenciaId", DbType.Int32, entidade.FormularioCicloConferenciaId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um FormularioCicloConferencia.
		/// </summary>
        /// <param name="entidade">FormularioCicloConferencia a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioCicloConferencia</returns>
		public FormularioCicloConferencia Carregar(int formularioCicloConferenciaId) {		
			FormularioCicloConferencia entidade = new FormularioCicloConferencia();
			entidade.FormularioCicloConferenciaId = formularioCicloConferenciaId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um FormularioCicloConferencia.
		/// </summary>
        /// <param name="entidade">FormularioCicloConferencia a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioCicloConferencia</returns>
		public FormularioCicloConferencia Carregar(FormularioCicloConferencia entidade) {		
		
			FormularioCicloConferencia entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM FormularioCicloConferencia WHERE formularioCicloConferenciaId=@formularioCicloConferenciaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@formularioCicloConferenciaId", DbType.Int32, entidade.FormularioCicloConferenciaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new FormularioCicloConferencia();
				PopulaFormularioCicloConferencia(reader, entidadeRetorno);
			}
			
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de FormularioCicloConferencia.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FormularioCicloConferencia.</returns>
		public List<FormularioCicloConferencia> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<FormularioCicloConferencia> entidadesRetorno = new List<FormularioCicloConferencia>();
			
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
				sbOrder.Append( " ORDER BY formularioCicloConferenciaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FormularioCicloConferencia");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioCicloConferencia WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioCicloConferencia ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT FormularioCicloConferencia.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FormularioCicloConferencia ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT FormularioCicloConferencia.* FROM FormularioCicloConferencia ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FormularioCicloConferencia entidadeRetorno = new FormularioCicloConferencia();
                PopulaFormularioCicloConferencia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
			
            reader.Close();

            return entidadesRetorno;
		}	
		
		/// <summary>
        /// Método que retorna todas os FormularioCicloConferencia existentes na base de dados.
        /// </summary>
		public List<FormularioCicloConferencia> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FormularioCicloConferencia na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FormularioCicloConferencia na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM FormularioCicloConferencia");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um FormularioCicloConferencia baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">FormularioCicloConferencia a ser populado(.</param>
		public static void PopulaFormularioCicloConferencia(IDataReader reader, FormularioCicloConferencia entidade) 
		{						
			if (reader["formularioCicloConferenciaId"] != DBNull.Value)
				entidade.FormularioCicloConferenciaId = Convert.ToInt32(reader["formularioCicloConferenciaId"].ToString());
			
			if (reader["dataHoraContato"] != DBNull.Value)
				entidade.DataHoraContato = Convert.ToDateTime(reader["dataHoraContato"].ToString());
			
			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();
			
			if (reader["email"] != DBNull.Value)
				entidade.Email = reader["email"].ToString();
			
			if (reader["empresa"] != DBNull.Value)
				entidade.Empresa = reader["empresa"].ToString();
			
			if (reader["cep"] != DBNull.Value)
				entidade.Cep = reader["cep"].ToString();
			
			if (reader["cidade"] != DBNull.Value)
				entidade.Cidade = reader["cidade"].ToString();
			
			if (reader["bairro"] != DBNull.Value)
				entidade.Bairro = reader["bairro"].ToString();
			
			if (reader["endereco"] != DBNull.Value)
				entidade.Endereco = reader["endereco"].ToString();
			
			if (reader["telefoneDDD"] != DBNull.Value)
				entidade.TelefoneDDD = reader["telefoneDDD"].ToString();
			
			if (reader["telefoneNumero"] != DBNull.Value)
				entidade.TelefoneNumero = reader["telefoneNumero"].ToString();
			
			if (reader["receberInformacaoSabesp"] != DBNull.Value)
				entidade.ReceberInformacaoSabesp = Convert.ToBoolean(reader["receberInformacaoSabesp"].ToString());
			
			if (reader["receberInformacaoEventos"] != DBNull.Value)
				entidade.ReceberInformacaoEventos = Convert.ToBoolean(reader["receberInformacaoEventos"].ToString());
			
			if (reader["formularioId"] != DBNull.Value) {
				entidade.Formulario = new Formulario();
				entidade.Formulario.FormularioId = Convert.ToInt32(reader["formularioId"].ToString());
			}

			if (reader["estadoId"] != DBNull.Value) {
				entidade.Estado = new Estado();
				entidade.Estado.EstadoId = Convert.ToInt32(reader["estadoId"].ToString());
			}


		}		
		
	}
}
		