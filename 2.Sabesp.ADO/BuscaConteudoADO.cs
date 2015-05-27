using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class BuscaConteudoADO : ADOSuper, IBuscaConteudoDAL
	{
		public List<BuscaConteudo> Carregar(Idioma idioma, string search, string search2)
		{
			List<BuscaConteudo> entidadeRetorno = new List<BuscaConteudo>();
			BuscaConteudo entidade = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("dbo.SearchContent");

			DbCommand command = _db.GetStoredProcCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, idioma.IdiomaId);
			_db.AddInParameter(command, "@search", DbType.String, search);
			_db.AddInParameter(command, "@search2", DbType.String, search2);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				entidade = new BuscaConteudo();
				PopulaBuscaConteudo(reader, entidade);
				entidadeRetorno.Add(entidade);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna popula um BuscaConteudo baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">BuscaConteudo a ser populado(.</param>
		public static void PopulaBuscaConteudo(IDataReader reader, BuscaConteudo entidade)
		{
			if (reader["conteudoId"] != DBNull.Value)
			{
				entidade.ConteudoId = Convert.ToInt32(reader["conteudoId"]);
			}

			if (reader["titulo"] != DBNull.Value)
			{
				entidade.Titulo = Convert.ToString(reader["titulo"]);
			}

			if (reader["descricao"] != DBNull.Value)
			{
				entidade.Descricao = Convert.ToString(reader["descricao"]);
			}

			if (reader["tipo"] != DBNull.Value)
			{
				entidade.ConteudoTipo = new ConteudoTipo();
				entidade.ConteudoTipo.ConteudoTipoId = Convert.ToInt32(reader["tipo"]);
			}
		}
	}
}