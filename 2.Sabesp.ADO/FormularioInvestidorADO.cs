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
	public class FormularioInvestidorADO : ADOSuper, IFormularioInvestidorDAL
	{
		/// <summary>
		/// Método que persiste um FormularioInvestidor.
		/// </summary>
		/// <param name="entidade">FormularioInvestidor contendo os dados a serem persistidos.</param>	
		public void Inserir(FormularioInvestidor entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioInvestidor ");
			sbSQL.Append(" (dataHoraContato, formularioId, nome, email, companhia, formularioInvestidorQualificacaoId, cargo, profissao, empresa, estadoId, cidade, bairro, endereco, telefoneDDD, telefoneNumero, contatoPorEmail, contatoPorTelefone, cep) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@dataHoraContato, @formularioId, @nome, @email, @companhia, @formularioInvestidorQualificacaoId, @cargo, @profissao, @empresa, @estadoId, @cidade, @bairro, @endereco, @telefoneDDD, @telefoneNumero, @contatoPorEmail, @contatoPorTelefone, @cep) ");
			sbSQL.Append(" ; SET @formularioInvestidorId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@formularioInvestidorId", DbType.Int32, 8);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@companhia", DbType.String, entidade.Companhia);
			_db.AddInParameter(command, "@formularioInvestidorQualificacaoId", DbType.Int32, entidade.FormularioInvestidorQualificacao.FormularioInvestidorQualificacaoId);
			_db.AddInParameter(command, "@cargo", DbType.String, entidade.Cargo);
			_db.AddInParameter(command, "@profissao", DbType.String, entidade.Profissao);
			_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);
			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			_db.AddInParameter(command, "@contatoPorEmail", DbType.Int32, entidade.ContatoPorEmail);
			_db.AddInParameter(command, "@contatoPorTelefone", DbType.Int32, entidade.ContatoPorTelefone);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);

			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.FormularioInvestidorId = Convert.ToInt32(_db.GetParameterValue(command, "@formularioInvestidorId"));
		}

		/// <summary>
		/// Método que atualiza os dados de um FormularioInvestidor.
		/// </summary>
		/// <param name="entidade">FormularioInvestidor contendo os dados a serem atualizados.</param>
		public void Atualizar(FormularioInvestidor entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FormularioInvestidor SET ");
			sbSQL.Append(" dataHoraContato=@dataHoraContato, formularioId=@formularioId, nome=@nome, email=@email, companhia=@companhia, formularioInvestidorQualificacaoId=@formularioInvestidorQualificacaoId, cargo=@cargo, profissao=@profissao, empresa=@empresa, estadoId=@estadoId, cidade=@cidade, bairro=@bairro, endereco=@endereco, telefoneDDD=@telefoneDDD, telefoneNumero=@telefoneNumero, contatoPorEmail=@contatoPorEmail, contatoPorTelefone=@contatoPorTelefone, cep=@cep ");
			sbSQL.Append(" WHERE formularioInvestidorId=@formularioInvestidorId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@formularioInvestidorId", DbType.Int32, entidade.FormularioInvestidorId);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@companhia", DbType.String, entidade.Companhia);
			_db.AddInParameter(command, "@formularioInvestidorQualificacaoId", DbType.Int32, entidade.FormularioInvestidorQualificacao.FormularioInvestidorQualificacaoId);
			_db.AddInParameter(command, "@cargo", DbType.String, entidade.Cargo);
			_db.AddInParameter(command, "@profissao", DbType.String, entidade.Profissao);
			_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);
			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			_db.AddInParameter(command, "@contatoPorEmail", DbType.Int32, entidade.ContatoPorEmail);
			_db.AddInParameter(command, "@contatoPorTelefone", DbType.Int32, entidade.ContatoPorTelefone);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um FormularioInvestidor da base de dados.
		/// </summary>
		/// <param name="entidade">FormularioInvestidor a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FormularioInvestidor entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM FormularioInvestidor ");
			sbSQL.Append("WHERE formularioInvestidorId=@formularioInvestidorId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioInvestidorId", DbType.Int32, entidade.FormularioInvestidorId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um FormularioInvestidor.
		/// </summary>
		/// <param name="entidade">FormularioInvestidor a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioInvestidor</returns>
		public FormularioInvestidor Carregar(int formularioInvestidorId)
		{
			FormularioInvestidor entidade = new FormularioInvestidor();
			entidade.FormularioInvestidorId = formularioInvestidorId;
			return Carregar(entidade);
		}

		/// <summary>
		/// Método que carrega um FormularioInvestidor.
		/// </summary>
		/// <param name="entidade">FormularioInvestidor a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioInvestidor</returns>
		public FormularioInvestidor Carregar(FormularioInvestidor entidade)
		{
			FormularioInvestidor entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM FormularioInvestidor WHERE formularioInvestidorId=@formularioInvestidorId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioInvestidorId", DbType.Int32, entidade.FormularioInvestidorId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new FormularioInvestidor();
				PopulaFormularioInvestidor(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de FormularioInvestidor.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FormularioInvestidor.</returns>
		public List<FormularioInvestidor> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			List<FormularioInvestidor> entidadesRetorno = new List<FormularioInvestidor>();

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
				sbOrder.Append(" ORDER BY formularioInvestidorId");
			}

			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FormularioInvestidor");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioInvestidor WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioInvestidor ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT FormularioInvestidor.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FormularioInvestidor ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());
			}
			else
			{
				sbSQL.Append("SELECT FormularioInvestidor.* FROM FormularioInvestidor ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				FormularioInvestidor entidadeRetorno = new FormularioInvestidor();
				PopulaFormularioInvestidor(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os FormularioInvestidor existentes na base de dados.
		/// </summary>
		public List<FormularioInvestidor> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de FormularioInvestidor na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de FormularioInvestidor na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM FormularioInvestidor");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um FormularioInvestidor baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">FormularioInvestidor a ser populado(.</param>
		public static void PopulaFormularioInvestidor(IDataReader reader, FormularioInvestidor entidade)
		{
			if (reader["formularioInvestidorId"] != DBNull.Value)
				entidade.FormularioInvestidorId = Convert.ToInt32(reader["formularioInvestidorId"].ToString());

			if (reader["dataHoraContato"] != DBNull.Value)
				entidade.DataHoraContato = Convert.ToDateTime(reader["dataHoraContato"].ToString());

			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();

			if (reader["email"] != DBNull.Value)
				entidade.Email = reader["email"].ToString();

			if (reader["companhia"] != DBNull.Value)
				entidade.Companhia = reader["companhia"].ToString();

			if (reader["cargo"] != DBNull.Value)
				entidade.Cargo = reader["cargo"].ToString();

			if (reader["profissao"] != DBNull.Value)
				entidade.Profissao = reader["profissao"].ToString();

			if (reader["empresa"] != DBNull.Value)
				entidade.Empresa = reader["empresa"].ToString();

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

			if (reader["contatoPorEmail"] != DBNull.Value)
				entidade.ContatoPorEmail = Convert.ToBoolean(reader["contatoPorEmail"].ToString());

			if (reader["contatoPorTelefone"] != DBNull.Value)
				entidade.ContatoPorTelefone = Convert.ToBoolean(reader["contatoPorTelefone"].ToString());

			if (reader["cep"] != DBNull.Value)
				entidade.Cep = reader["cep"].ToString();

			if (reader["formularioId"] != DBNull.Value)
			{
				entidade.Formulario = new Formulario();
				entidade.Formulario.FormularioId = Convert.ToInt32(reader["formularioId"].ToString());
			}

			if (reader["formularioInvestidorQualificacaoId"] != DBNull.Value)
			{
				entidade.FormularioInvestidorQualificacao = new FormularioInvestidorQualificacao();
				entidade.FormularioInvestidorQualificacao.FormularioInvestidorQualificacaoId = Convert.ToInt32(reader["formularioInvestidorQualificacaoId"].ToString());
			}

			if (reader["estadoId"] != DBNull.Value)
			{
				entidade.Estado = new Estado();
				entidade.Estado.EstadoId = Convert.ToInt32(reader["estadoId"].ToString());
			}
		}
	}
}