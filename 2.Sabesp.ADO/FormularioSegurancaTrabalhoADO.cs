
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
	public class FormularioSegurancaTrabalhoADO : ADOSuper, IFormularioSegurancaTrabalhoDAL {
	
	    /// <summary>
        /// Método que persiste um FormularioSegurancaTrabalho.
        /// </summary>
        /// <param name="entidade">FormularioSegurancaTrabalho contendo os dados a serem persistidos.</param>	
		public void Inserir(FormularioSegurancaTrabalho entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioSegurancaTrabalho ");
			sbSQL.Append(" (dataHoraContato, nome, email, empresa, cep, estadoId, cidade, bairro, endereco, telefoneDdd, telefoneNumero, receberInformacaoSabesp, receberInformacaoEventos, formularioId, duvida) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@dataHoraContato, @nome, @email, @empresa, @cep, @estadoId, @cidade, @bairro, @endereco, @telefoneDdd, @telefoneNumero, @receberInformacaoSabesp, @receberInformacaoEventos, @formularioId, @duvida) ");

			sbSQL.Append(" ; SET @formularioSegurancaTrabalhoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@formularioSegurancaTrabalhoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);

			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);

			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);

			_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);

			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);

			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);

			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);

			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);

			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);

			_db.AddInParameter(command, "@telefoneDdd", DbType.String, entidade.TelefoneDdd);

			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);

			_db.AddInParameter(command, "@receberInformacaoSabesp", DbType.Int32, entidade.ReceberInformacaoSabesp);

			_db.AddInParameter(command, "@receberInformacaoEventos", DbType.Int32, entidade.ReceberInformacaoEventos);

			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);

			if (entidade.Duvida != null)
				_db.AddInParameter(command, "@duvida", DbType.String, entidade.Duvida);
			else
				_db.AddInParameter(command, "@duvida", DbType.String, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.FormularioSegurancaTrabalhoId = Convert.ToInt32(_db.GetParameterValue(command, "@formularioSegurancaTrabalhoId"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um FormularioSegurancaTrabalho.
        /// </summary>
        /// <param name="entidade">FormularioSegurancaTrabalho contendo os dados a serem atualizados.</param>
		public void Atualizar(FormularioSegurancaTrabalho entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FormularioSegurancaTrabalho SET ");
			sbSQL.Append(" dataHoraContato=@dataHoraContato, nome=@nome, email=@email, empresa=@empresa, cep=@cep, estadoId=@estadoId, cidade=@cidade, bairro=@bairro, endereco=@endereco, telefoneDdd=@telefoneDdd, telefoneNumero=@telefoneNumero, receberInformacaoSabesp=@receberInformacaoSabesp, receberInformacaoEventos=@receberInformacaoEventos, formularioId=@formularioId, duvida=@duvida ");
			sbSQL.Append(" WHERE formularioSegurancaTrabalhoId=@formularioSegurancaTrabalhoId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@formularioSegurancaTrabalhoId", DbType.Int32, entidade.FormularioSegurancaTrabalhoId);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			_db.AddInParameter(command, "@telefoneDdd", DbType.String, entidade.TelefoneDdd);
			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			_db.AddInParameter(command, "@receberInformacaoSabesp", DbType.Int32, entidade.ReceberInformacaoSabesp);
			_db.AddInParameter(command, "@receberInformacaoEventos", DbType.Int32, entidade.ReceberInformacaoEventos);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			if (entidade.Duvida != null)
				_db.AddInParameter(command, "@duvida", DbType.String, entidade.Duvida);
			else
				_db.AddInParameter(command, "@duvida", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um FormularioSegurancaTrabalho da base de dados.
        /// </summary>
        /// <param name="entidade">FormularioSegurancaTrabalho a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FormularioSegurancaTrabalho entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM FormularioSegurancaTrabalho ");
			sbSQL.Append("WHERE formularioSegurancaTrabalhoId=@formularioSegurancaTrabalhoId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@formularioSegurancaTrabalhoId", DbType.Int32, entidade.FormularioSegurancaTrabalhoId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um FormularioSegurancaTrabalho.
		/// </summary>
        /// <param name="entidade">FormularioSegurancaTrabalho a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioSegurancaTrabalho</returns>
		public FormularioSegurancaTrabalho Carregar(int formularioSegurancaTrabalhoId) {		
			FormularioSegurancaTrabalho entidade = new FormularioSegurancaTrabalho();
			entidade.FormularioSegurancaTrabalhoId = formularioSegurancaTrabalhoId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um FormularioSegurancaTrabalho.
		/// </summary>
        /// <param name="entidade">FormularioSegurancaTrabalho a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioSegurancaTrabalho</returns>
		public FormularioSegurancaTrabalho Carregar(FormularioSegurancaTrabalho entidade) {		
		
			FormularioSegurancaTrabalho entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM FormularioSegurancaTrabalho WHERE formularioSegurancaTrabalhoId=@formularioSegurancaTrabalhoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@formularioSegurancaTrabalhoId", DbType.Int32, entidade.FormularioSegurancaTrabalhoId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new FormularioSegurancaTrabalho();
				PopulaFormularioSegurancaTrabalho(reader, entidadeRetorno);
			}
			
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de FormularioSegurancaTrabalho.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FormularioSegurancaTrabalho.</returns>
		public List<FormularioSegurancaTrabalho> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<FormularioSegurancaTrabalho> entidadesRetorno = new List<FormularioSegurancaTrabalho>();
			
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
				sbOrder.Append( " ORDER BY formularioSegurancaTrabalhoId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FormularioSegurancaTrabalho");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioSegurancaTrabalho WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioSegurancaTrabalho ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT FormularioSegurancaTrabalho.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FormularioSegurancaTrabalho ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT FormularioSegurancaTrabalho.* FROM FormularioSegurancaTrabalho ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FormularioSegurancaTrabalho entidadeRetorno = new FormularioSegurancaTrabalho();
                PopulaFormularioSegurancaTrabalho(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
			
            reader.Close();

            return entidadesRetorno;
		}	
		
		/// <summary>
        /// Método que retorna todas os FormularioSegurancaTrabalho existentes na base de dados.
        /// </summary>
		public List<FormularioSegurancaTrabalho> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FormularioSegurancaTrabalho na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FormularioSegurancaTrabalho na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM FormularioSegurancaTrabalho");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um FormularioSegurancaTrabalho baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">FormularioSegurancaTrabalho a ser populado(.</param>
		public static void PopulaFormularioSegurancaTrabalho(IDataReader reader, FormularioSegurancaTrabalho entidade) 
		{						
			if (reader["formularioSegurancaTrabalhoId"] != DBNull.Value)
				entidade.FormularioSegurancaTrabalhoId = Convert.ToInt32(reader["formularioSegurancaTrabalhoId"].ToString());
			
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
			
			if (reader["telefoneDdd"] != DBNull.Value)
				entidade.TelefoneDdd = reader["telefoneDdd"].ToString();
			
			if (reader["telefoneNumero"] != DBNull.Value)
				entidade.TelefoneNumero = reader["telefoneNumero"].ToString();
			
			if (reader["receberInformacaoSabesp"] != DBNull.Value)
				entidade.ReceberInformacaoSabesp = Convert.ToBoolean(reader["receberInformacaoSabesp"].ToString());
			
			if (reader["receberInformacaoEventos"] != DBNull.Value)
				entidade.ReceberInformacaoEventos = Convert.ToBoolean(reader["receberInformacaoEventos"].ToString());

			if (reader["duvida"] != DBNull.Value)
				entidade.Duvida = reader["duvida"].ToString();

			if (reader["estadoId"] != DBNull.Value)
			{
				entidade.Estado = new Estado();
				entidade.Estado.EstadoId = Convert.ToInt32(reader["estadoId"].ToString());
			}

			if (reader["formularioId"] != DBNull.Value) {
				entidade.Formulario = new Formulario();
				entidade.Formulario.FormularioId = Convert.ToInt32(reader["formularioId"].ToString());
			}


		}		
		
	}
}
		