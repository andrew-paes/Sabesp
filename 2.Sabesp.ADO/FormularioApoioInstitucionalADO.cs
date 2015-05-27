
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
	public class FormularioApoioInstitucionalADO : ADOSuper, IFormularioApoioInstitucionalDAL
	{

		/// <summary>
		/// Método que persiste um FormularioApoioInstitucional.
		/// </summary>
		/// <param name="entidade">FormularioApoioInstitucional contendo os dados a serem persistidos.</param>	
		public void Inserir(FormularioApoioInstitucional entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioApoioInstitucional ");
			sbSQL.Append(" (formularioId, nome, email, empresa, cep, estadoId, cidade, bairro, endereco, telefoneDDD, telefoneNumero, receberInformacaoSabesp, receberInformacaoEventos, dataHoraContato, duvida) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@formularioId, @nome, @email, @empresa, @cep, @estadoId, @cidade, @bairro, @endereco, @telefoneDDD, @telefoneNumero, @receberInformacaoSabesp, @receberInformacaoEventos, @dataHoraContato, @duvida) ");

			sbSQL.Append(" ; SET @formularioApoioInstitucionalId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@formularioApoioInstitucionalId", DbType.Int32, 8);

			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);

			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);

			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);

			_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);

			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);

			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);

			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);

			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);

			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);

			_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);

			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);

			_db.AddInParameter(command, "@receberInformacaoSabesp", DbType.Int32, entidade.ReceberInformacaoSabesp);

			_db.AddInParameter(command, "@receberInformacaoEventos", DbType.Int32, entidade.ReceberInformacaoEventos);

			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);

			if (entidade.Duvida != null)
				_db.AddInParameter(command, "@duvida", DbType.String, entidade.Duvida);
			else
				_db.AddInParameter(command, "@duvida", DbType.String, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.FormularioApoioInstitucionalId = Convert.ToInt32(_db.GetParameterValue(command, "@formularioApoioInstitucionalId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um FormularioApoioInstitucional.
		/// </summary>
		/// <param name="entidade">FormularioApoioInstitucional contendo os dados a serem atualizados.</param>
		public void Atualizar(FormularioApoioInstitucional entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FormularioApoioInstitucional SET ");
			sbSQL.Append(" formularioId=@formularioId, nome=@nome, email=@email, empresa=@empresa, cep=@cep, estadoId=@estadoId, cidade=@cidade, bairro=@bairro, endereco=@endereco, telefoneDDD=@telefoneDDD, telefoneNumero=@telefoneNumero, receberInformacaoSabesp=@receberInformacaoSabesp, receberInformacaoEventos=@receberInformacaoEventos, dataHoraContato=@dataHoraContato, duvida=@duvida ");
			sbSQL.Append(" WHERE formularioApoioInstitucionalId=@formularioApoioInstitucionalId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@formularioApoioInstitucionalId", DbType.Int32, entidade.FormularioApoioInstitucionalId);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);
			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			_db.AddInParameter(command, "@receberInformacaoSabesp", DbType.Int32, entidade.ReceberInformacaoSabesp);
			_db.AddInParameter(command, "@receberInformacaoEventos", DbType.Int32, entidade.ReceberInformacaoEventos);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			if (entidade.Duvida != null)
				_db.AddInParameter(command, "@duvida", DbType.String, entidade.Duvida);
			else
				_db.AddInParameter(command, "@duvida", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um FormularioApoioInstitucional da base de dados.
		/// </summary>
		/// <param name="entidade">FormularioApoioInstitucional a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FormularioApoioInstitucional entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM FormularioApoioInstitucional ");
			sbSQL.Append("WHERE formularioApoioInstitucionalId=@formularioApoioInstitucionalId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioApoioInstitucionalId", DbType.Int32, entidade.FormularioApoioInstitucionalId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um FormularioApoioInstitucional.
		/// </summary>
		/// <param name="entidade">FormularioApoioInstitucional a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioApoioInstitucional</returns>
		public FormularioApoioInstitucional Carregar(int formularioApoioInstitucionalId)
		{
			FormularioApoioInstitucional entidade = new FormularioApoioInstitucional();
			entidade.FormularioApoioInstitucionalId = formularioApoioInstitucionalId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um FormularioApoioInstitucional.
		/// </summary>
		/// <param name="entidade">FormularioApoioInstitucional a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioApoioInstitucional</returns>
		public FormularioApoioInstitucional Carregar(FormularioApoioInstitucional entidade)
		{

			FormularioApoioInstitucional entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM FormularioApoioInstitucional WHERE formularioApoioInstitucionalId=@formularioApoioInstitucionalId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioApoioInstitucionalId", DbType.Int32, entidade.FormularioApoioInstitucionalId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new FormularioApoioInstitucional();
				PopulaFormularioApoioInstitucional(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de FormularioApoioInstitucional.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FormularioApoioInstitucional.</returns>
		public List<FormularioApoioInstitucional> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<FormularioApoioInstitucional> entidadesRetorno = new List<FormularioApoioInstitucional>();

			StringBuilder sbSQL = new StringBuilder();
			StringBuilder sbWhere = new StringBuilder();
			StringBuilder sbOrder = new StringBuilder();
			DbCommand command;
			IDataReader reader;

			// Monta o "OrderBy"
			if (ordemColunas != null)
			{
				for (int i = 0; i < ordemColunas.Length; i++)
				{
					if (sbOrder.Length > 0) { sbOrder.Append(", "); }
					sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
				}
				if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }
			}
			else
			{
				sbOrder.Append(" ORDER BY formularioApoioInstitucionalId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FormularioApoioInstitucional");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioApoioInstitucional WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioApoioInstitucional ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT FormularioApoioInstitucional.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FormularioApoioInstitucional ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT FormularioApoioInstitucional.* FROM FormularioApoioInstitucional ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				FormularioApoioInstitucional entidadeRetorno = new FormularioApoioInstitucional();
				PopulaFormularioApoioInstitucional(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os FormularioApoioInstitucional existentes na base de dados.
		/// </summary>
		public List<FormularioApoioInstitucional> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de FormularioApoioInstitucional na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de FormularioApoioInstitucional na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM FormularioApoioInstitucional");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um FormularioApoioInstitucional baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">FormularioApoioInstitucional a ser populado(.</param>
		public static void PopulaFormularioApoioInstitucional(IDataReader reader, FormularioApoioInstitucional entidade)
		{
			if (reader["formularioApoioInstitucionalId"] != DBNull.Value)
				entidade.FormularioApoioInstitucionalId = Convert.ToInt32(reader["formularioApoioInstitucionalId"].ToString());

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

			if (reader["dataHoraContato"] != DBNull.Value)
				entidade.DataHoraContato = Convert.ToDateTime(reader["dataHoraContato"].ToString());

			if (reader["duvida"] != DBNull.Value)
				entidade.Duvida = reader["duvida"].ToString();

			if (reader["formularioId"] != DBNull.Value)
			{
				entidade.Formulario = new Formulario();
				entidade.Formulario.FormularioId = Convert.ToInt32(reader["formularioId"].ToString());
			}

			if (reader["estadoId"] != DBNull.Value)
			{
				entidade.Estado = new Estado();
				entidade.Estado.EstadoId = Convert.ToInt32(reader["estadoId"].ToString());
			}


		}

	}
}
