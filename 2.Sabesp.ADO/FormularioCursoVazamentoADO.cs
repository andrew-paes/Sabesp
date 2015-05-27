
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
	public class FormularioCursoVazamentoADO : ADOSuper, IFormularioCursoVazamentoDAL
	{

		/// <summary>
		/// Método que persiste um FormularioCursoVazamento.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento contendo os dados a serem persistidos.</param>	
		public void Inserir(FormularioCursoVazamento entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioCursoVazamento ");
			sbSQL.Append(" (formularioId, dataHoraContato, nome, email, cep, estadoId, cidade, bairro, endereco, telefoneDDD, telefoneNumero, escolaridadeId, escolaridadeOutro, tipoImovelId, tipoImovelOutro, indicacaoId, indicacaoOutro, localCursoId, horarioPreferenciaId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@formularioId, @dataHoraContato, @nome, @email, @cep, @estadoId, @cidade, @bairro, @endereco, @telefoneDDD, @telefoneNumero, @escolaridadeId, @escolaridadeOutro, @tipoImovelId, @tipoImovelOutro, @indicacaoId, @indicacaoOutro, @localCursoId, @horarioPreferenciaId) ");

			sbSQL.Append(" ; SET @formularioCursoVazamentoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@formularioCursoVazamentoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);

			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);

			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);

			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);

			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);

			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);

			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);

			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);

			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);

			_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);

			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);

			_db.AddInParameter(command, "@escolaridadeId", DbType.Int32, entidade.Escolaridade.EscolaridadeId);

			if (entidade.EscolaridadeOutro != null)
				_db.AddInParameter(command, "@escolaridadeOutro", DbType.String, entidade.EscolaridadeOutro);
			else
				_db.AddInParameter(command, "@escolaridadeOutro", DbType.String, null);

			_db.AddInParameter(command, "@tipoImovelId", DbType.Int32, entidade.TipoImovel.TipoImovelId);

			if (entidade.TipoImovelOutro != null)
				_db.AddInParameter(command, "@tipoImovelOutro", DbType.String, entidade.TipoImovelOutro);
			else
				_db.AddInParameter(command, "@tipoImovelOutro", DbType.String, null);

			_db.AddInParameter(command, "@indicacaoId", DbType.Int32, entidade.Indicacao.IndicacaoId);

			_db.AddInParameter(command, "@indicacaoOutro", DbType.String, entidade.IndicacaoOutro);

			_db.AddInParameter(command, "@localCursoId", DbType.Int32, entidade.LocalCurso.LocalCursoId);

			_db.AddInParameter(command, "@horarioPreferenciaId", DbType.Int32, entidade.HorarioPreferencia.HorarioPreferenciaId);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.FormularioCursoVazamentoId = Convert.ToInt32(_db.GetParameterValue(command, "@formularioCursoVazamentoId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um FormularioCursoVazamento.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento contendo os dados a serem atualizados.</param>
		public void Atualizar(FormularioCursoVazamento entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FormularioCursoVazamento SET ");
			sbSQL.Append(" formularioId=@formularioId, dataHoraContato=@dataHoraContato, nome=@nome, email=@email, cep=@cep, estadoId=@estadoId, cidade=@cidade, bairro=@bairro, endereco=@endereco, telefoneDDD=@telefoneDDD, telefoneNumero=@telefoneNumero, escolaridadeId=@escolaridadeId, escolaridadeOutro=@escolaridadeOutro, tipoImovelId=@tipoImovelId, tipoImovelOutro=@tipoImovelOutro, indicacaoId=@indicacaoId, indicacaoOutro=@indicacaoOutro, localCursoId=@localCursoId, horarioPreferenciaId=@horarioPreferenciaId ");
			sbSQL.Append(" WHERE formularioCursoVazamentoId=@formularioCursoVazamentoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);
			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			_db.AddInParameter(command, "@escolaridadeId", DbType.Int32, entidade.Escolaridade.EscolaridadeId);
			if (entidade.EscolaridadeOutro != null)
				_db.AddInParameter(command, "@escolaridadeOutro", DbType.String, entidade.EscolaridadeOutro);
			else
				_db.AddInParameter(command, "@escolaridadeOutro", DbType.String, null);
			_db.AddInParameter(command, "@tipoImovelId", DbType.Int32, entidade.TipoImovel.TipoImovelId);
			if (entidade.TipoImovelOutro != null)
				_db.AddInParameter(command, "@tipoImovelOutro", DbType.String, entidade.TipoImovelOutro);
			else
				_db.AddInParameter(command, "@tipoImovelOutro", DbType.String, null);
			_db.AddInParameter(command, "@indicacaoId", DbType.Int32, entidade.Indicacao.IndicacaoId);
			_db.AddInParameter(command, "@indicacaoOutro", DbType.String, entidade.IndicacaoOutro);
			_db.AddInParameter(command, "@localCursoId", DbType.Int32, entidade.LocalCurso.LocalCursoId);
			_db.AddInParameter(command, "@horarioPreferenciaId", DbType.Int32, entidade.HorarioPreferencia.HorarioPreferenciaId);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um FormularioCursoVazamento da base de dados.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FormularioCursoVazamento entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM FormularioCursoVazamento ");
			sbSQL.Append("WHERE formularioCursoVazamentoId=@formularioCursoVazamentoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um FormularioCursoVazamento.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioCursoVazamento</returns>
		public FormularioCursoVazamento Carregar(int formularioCursoVazamentoId)
		{
			FormularioCursoVazamento entidade = new FormularioCursoVazamento();
			entidade.FormularioCursoVazamentoId = formularioCursoVazamentoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um FormularioCursoVazamento.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioCursoVazamento</returns>
		public FormularioCursoVazamento Carregar(FormularioCursoVazamento entidade)
		{

			FormularioCursoVazamento entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM FormularioCursoVazamento WHERE formularioCursoVazamentoId=@formularioCursoVazamentoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new FormularioCursoVazamento();
				PopulaFormularioCursoVazamento(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de FormularioCursoVazamento.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FormularioCursoVazamento.</returns>
		public List<FormularioCursoVazamento> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<FormularioCursoVazamento> entidadesRetorno = new List<FormularioCursoVazamento>();

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
				sbOrder.Append(" ORDER BY formularioCursoVazamentoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FormularioCursoVazamento");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioCursoVazamento WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioCursoVazamento ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT FormularioCursoVazamento.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FormularioCursoVazamento ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT FormularioCursoVazamento.* FROM FormularioCursoVazamento ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				FormularioCursoVazamento entidadeRetorno = new FormularioCursoVazamento();
				PopulaFormularioCursoVazamento(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os FormularioCursoVazamento existentes na base de dados.
		/// </summary>
		public List<FormularioCursoVazamento> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de FormularioCursoVazamento na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de FormularioCursoVazamento na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM FormularioCursoVazamento");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um FormularioCursoVazamento baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">FormularioCursoVazamento a ser populado(.</param>
		public static void PopulaFormularioCursoVazamento(IDataReader reader, FormularioCursoVazamento entidade)
		{
			if (reader["formularioCursoVazamentoId"] != DBNull.Value)
				entidade.FormularioCursoVazamentoId = Convert.ToInt32(reader["formularioCursoVazamentoId"].ToString());

			if (reader["dataHoraContato"] != DBNull.Value)
				entidade.DataHoraContato = Convert.ToDateTime(reader["dataHoraContato"].ToString());

			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();

			if (reader["email"] != DBNull.Value)
				entidade.Email = reader["email"].ToString();

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

			if (reader["escolaridadeOutro"] != DBNull.Value)
				entidade.EscolaridadeOutro = reader["escolaridadeOutro"].ToString();

			if (reader["tipoImovelOutro"] != DBNull.Value)
				entidade.TipoImovelOutro = reader["tipoImovelOutro"].ToString();

			if (reader["indicacaoOutro"] != DBNull.Value)
				entidade.IndicacaoOutro = reader["indicacaoOutro"].ToString();

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

			if (reader["escolaridadeId"] != DBNull.Value)
			{
				entidade.Escolaridade = new Escolaridade();
				entidade.Escolaridade.EscolaridadeId = Convert.ToInt32(reader["escolaridadeId"].ToString());
			}

			if (reader["tipoImovelId"] != DBNull.Value)
			{
				entidade.TipoImovel = new TipoImovel();
				entidade.TipoImovel.TipoImovelId = Convert.ToInt32(reader["tipoImovelId"].ToString());
			}

			if (reader["indicacaoId"] != DBNull.Value)
			{
				entidade.Indicacao = new Indicacao();
				entidade.Indicacao.IndicacaoId = Convert.ToInt32(reader["indicacaoId"].ToString());
			}

			if (reader["localCursoId"] != DBNull.Value)
			{
				entidade.LocalCurso = new LocalCurso();
				entidade.LocalCurso.LocalCursoId = Convert.ToInt32(reader["localCursoId"].ToString());
			}

			if (reader["horarioPreferenciaId"] != DBNull.Value)
			{
				entidade.HorarioPreferencia = new HorarioPreferencia();
				entidade.HorarioPreferencia.HorarioPreferenciaId = Convert.ToInt32(reader["horarioPreferenciaId"].ToString());
			}


		}

	}
}
