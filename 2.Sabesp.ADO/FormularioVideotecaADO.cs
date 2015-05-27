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
	public class FormularioVideotecaADO : ADOSuper, IFormularioVideotecaDAL
	{
		/// <summary>
		/// Método que persiste um FormularioVideoteca.
		/// </summary>
		/// <param name="entidade">FormularioVideoteca contendo os dados a serem persistidos.</param>	
		public void Inserir(FormularioVideoteca entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioVideoteca ");
			sbSQL.Append(" (dataHoraContato, nome, email, rg, cadastroNacionalPessoa, profissao, empresa, estadoId, formularioId, cidade, bairro, endereco, telefoneDdd, telefoneNumero, interesseGotaBorralheira, interesseAguaNaBoca, interesseAguaVideos, interesseChuaChuagua, interesseTratamento, utilizacaoMaterial, cep, interesseSuperH20) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@dataHoraContato, @nome, @email, @rg, @cadastroNacionalPessoa, @profissao, @empresa, @estadoId, @formularioId, @cidade, @bairro, @endereco, @telefoneDdd, @telefoneNumero, @interesseGotaBorralheira, @interesseAguaNaBoca, @interesseAguaVideos, @interesseChuaChuagua, @interesseTratamento, @utilizacaoMaterial, @cep, @interesseSuperH20) ");
			sbSQL.Append(" ; SET @formularioVideotecaId = SCOPE_IDENTITY(); ");
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddOutParameter(command, "@formularioVideotecaId", DbType.Int32, 8);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@rg", DbType.String, entidade.Rg);
			_db.AddInParameter(command, "@cadastroNacionalPessoa", DbType.String, entidade.CadastroNacionalPessoa);
			_db.AddInParameter(command, "@profissao", DbType.String, entidade.Profissao);
			_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			_db.AddInParameter(command, "@telefoneDdd", DbType.String, entidade.TelefoneDdd);
			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			_db.AddInParameter(command, "@interesseGotaBorralheira", DbType.Int32, entidade.InteresseGotaBorralheira);
			_db.AddInParameter(command, "@interesseAguaNaBoca", DbType.Int32, entidade.InteresseAguaNaBoca);
			_db.AddInParameter(command, "@interesseAguaVideos", DbType.Int32, entidade.InteresseAguaVideos);
			_db.AddInParameter(command, "@interesseChuaChuagua", DbType.Int32, entidade.InteresseChuaChuagua);
			_db.AddInParameter(command, "@interesseTratamento", DbType.Int32, entidade.InteresseTratamento);
			_db.AddInParameter(command, "@utilizacaoMaterial", DbType.String, entidade.UtilizacaoMaterial);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);
			_db.AddInParameter(command, "@interesseSuperH20", DbType.Int32, entidade.InteresseSuperH20);

			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.FormularioVideotecaId = Convert.ToInt32(_db.GetParameterValue(command, "@formularioVideotecaId"));
		}

		/// <summary>
		/// Método que atualiza os dados de um FormularioVideoteca.
		/// </summary>
		/// <param name="entidade">FormularioVideoteca contendo os dados a serem atualizados.</param>
		public void Atualizar(FormularioVideoteca entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FormularioVideoteca SET ");
			sbSQL.Append(" dataHoraContato=@dataHoraContato, nome=@nome, email=@email, rg=@rg, cadastroNacionalPessoa=@cadastroNacionalPessoa, profissao=@profissao, empresa=@empresa, estadoId=@estadoId, formularioId=@formularioId, cidade=@cidade, bairro=@bairro, endereco=@endereco, telefoneDdd=@telefoneDdd, telefoneNumero=@telefoneNumero, interesseGotaBorralheira=@interesseGotaBorralheira, interesseAguaNaBoca=@interesseAguaNaBoca, interesseAguaVideos=@interesseAguaVideos, interesseChuaChuagua=@interesseChuaChuagua, interesseTratamento=@interesseTratamento, utilizacaoMaterial=@utilizacaoMaterial, cep=@cep, interesseSuperH20=@interesseSuperH20 ");
			sbSQL.Append(" WHERE formularioVideotecaId=@formularioVideotecaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@formularioVideotecaId", DbType.Int32, entidade.FormularioVideotecaId);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@rg", DbType.String, entidade.Rg);
			_db.AddInParameter(command, "@cadastroNacionalPessoa", DbType.String, entidade.CadastroNacionalPessoa);
			_db.AddInParameter(command, "@profissao", DbType.String, entidade.Profissao);
			_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			_db.AddInParameter(command, "@telefoneDdd", DbType.String, entidade.TelefoneDdd);
			_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			_db.AddInParameter(command, "@interesseGotaBorralheira", DbType.Int32, entidade.InteresseGotaBorralheira);
			_db.AddInParameter(command, "@interesseAguaNaBoca", DbType.Int32, entidade.InteresseAguaNaBoca);
			_db.AddInParameter(command, "@interesseAguaVideos", DbType.Int32, entidade.InteresseAguaVideos);
			_db.AddInParameter(command, "@interesseChuaChuagua", DbType.Int32, entidade.InteresseChuaChuagua);
			_db.AddInParameter(command, "@interesseTratamento", DbType.Int32, entidade.InteresseTratamento);
			_db.AddInParameter(command, "@utilizacaoMaterial", DbType.String, entidade.UtilizacaoMaterial);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);
			_db.AddInParameter(command, "@interesseSuperH20", DbType.Int32, entidade.InteresseSuperH20);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um FormularioVideoteca da base de dados.
		/// </summary>
		/// <param name="entidade">FormularioVideoteca a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FormularioVideoteca entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM FormularioVideoteca ");
			sbSQL.Append("WHERE formularioVideotecaId=@formularioVideotecaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioVideotecaId", DbType.Int32, entidade.FormularioVideotecaId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um FormularioVideoteca.
		/// </summary>
		/// <param name="entidade">FormularioVideoteca a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioVideoteca</returns>
		public FormularioVideoteca Carregar(int formularioVideotecaId)
		{
			FormularioVideoteca entidade = new FormularioVideoteca();
			entidade.FormularioVideotecaId = formularioVideotecaId;
			return Carregar(entidade);
		}

		/// <summary>
		/// Método que carrega um FormularioVideoteca.
		/// </summary>
		/// <param name="entidade">FormularioVideoteca a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioVideoteca</returns>
		public FormularioVideoteca Carregar(FormularioVideoteca entidade)
		{
			FormularioVideoteca entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM FormularioVideoteca WHERE formularioVideotecaId=@formularioVideotecaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioVideotecaId", DbType.Int32, entidade.FormularioVideotecaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new FormularioVideoteca();
				PopulaFormularioVideoteca(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de FormularioVideoteca.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FormularioVideoteca.</returns>
		public List<FormularioVideoteca> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			List<FormularioVideoteca> entidadesRetorno = new List<FormularioVideoteca>();

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
				sbOrder.Append(" ORDER BY formularioVideotecaId");
			}

			if (registrosPagina > 0)
			{
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FormularioVideoteca");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioVideoteca WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioVideoteca ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT FormularioVideoteca.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FormularioVideoteca ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());
			}
			else
			{
				sbSQL.Append("SELECT FormularioVideoteca.* FROM FormularioVideoteca ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				FormularioVideoteca entidadeRetorno = new FormularioVideoteca();
				PopulaFormularioVideoteca(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os FormularioVideoteca existentes na base de dados.
		/// </summary>
		public List<FormularioVideoteca> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de FormularioVideoteca na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de FormularioVideoteca na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM FormularioVideoteca");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um FormularioVideoteca baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">FormularioVideoteca a ser populado(.</param>
		public static void PopulaFormularioVideoteca(IDataReader reader, FormularioVideoteca entidade)
		{
			if (reader["formularioVideotecaId"] != DBNull.Value)
				entidade.FormularioVideotecaId = Convert.ToInt32(reader["formularioVideotecaId"].ToString());

			if (reader["dataHoraContato"] != DBNull.Value)
				entidade.DataHoraContato = Convert.ToDateTime(reader["dataHoraContato"].ToString());

			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();

			if (reader["email"] != DBNull.Value)
				entidade.Email = reader["email"].ToString();

			if (reader["rg"] != DBNull.Value)
				entidade.Rg = reader["rg"].ToString();

			if (reader["cadastroNacionalPessoa"] != DBNull.Value)
				entidade.CadastroNacionalPessoa = reader["cadastroNacionalPessoa"].ToString();

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

			if (reader["telefoneDdd"] != DBNull.Value)
				entidade.TelefoneDdd = reader["telefoneDdd"].ToString();

			if (reader["telefoneNumero"] != DBNull.Value)
				entidade.TelefoneNumero = reader["telefoneNumero"].ToString();

			if (reader["interesseGotaBorralheira"] != DBNull.Value)
				entidade.InteresseGotaBorralheira = Convert.ToBoolean(reader["interesseGotaBorralheira"].ToString());

			if (reader["interesseAguaNaBoca"] != DBNull.Value)
				entidade.InteresseAguaNaBoca = Convert.ToBoolean(reader["interesseAguaNaBoca"].ToString());

			if (reader["interesseAguaVideos"] != DBNull.Value)
				entidade.InteresseAguaVideos = Convert.ToBoolean(reader["interesseAguaVideos"].ToString());

			if (reader["interesseChuaChuagua"] != DBNull.Value)
				entidade.InteresseChuaChuagua = Convert.ToBoolean(reader["interesseChuaChuagua"].ToString());

			if (reader["interesseTratamento"] != DBNull.Value)
				entidade.InteresseTratamento = Convert.ToBoolean(reader["interesseTratamento"].ToString());

			if (reader["utilizacaoMaterial"] != DBNull.Value)
				entidade.UtilizacaoMaterial = reader["utilizacaoMaterial"].ToString();

			if (reader["cep"] != DBNull.Value)
				entidade.Cep = reader["cep"].ToString();

			if (reader["interesseSuperH20"] != DBNull.Value)
				entidade.InteresseSuperH20 = Convert.ToBoolean(reader["interesseSuperH20"].ToString());

			if (reader["estadoId"] != DBNull.Value)
			{
				entidade.Estado = new Estado();
				entidade.Estado.EstadoId = Convert.ToInt32(reader["estadoId"].ToString());
			}

			if (reader["formularioId"] != DBNull.Value)
			{
				entidade.Formulario = new Formulario();
				entidade.Formulario.FormularioId = Convert.ToInt32(reader["formularioId"].ToString());
			}
		}
	}
}