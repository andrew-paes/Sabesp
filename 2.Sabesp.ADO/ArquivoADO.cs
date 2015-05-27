
/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.93
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

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class ArquivoADO : ADOSuper, IArquivoDAL
	{

		/// <summary>
		/// Método que persiste um Arquivo.
		/// </summary>
		/// <param name="entidade">Arquivo contendo os dados a serem persistidos.</param>	
		public void Inserir(Arquivo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Arquivo ");
			sbSQL.Append(" (nomeArquivo, tamanho, extensao) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@nomeArquivo, @tamanho, @extensao) ");

			sbSQL.Append(" ; SET @arquivoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@arquivoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@nomeArquivo", DbType.String, entidade.NomeArquivo);

			_db.AddInParameter(command, "@tamanho", DbType.Int32, entidade.Tamanho);

			_db.AddInParameter(command, "@extensao", DbType.String, entidade.Extensao);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.ArquivoId = Convert.ToInt32(_db.GetParameterValue(command, "@arquivoId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um Arquivo.
		/// </summary>
		/// <param name="entidade">Arquivo contendo os dados a serem atualizados.</param>
		public void Atualizar(Arquivo entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Arquivo SET ");
			sbSQL.Append(" nomeArquivo=@nomeArquivo, tamanho=@tamanho, extensao=@extensao ");
			sbSQL.Append(" WHERE arquivoId=@arquivoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.ArquivoId);
			_db.AddInParameter(command, "@nomeArquivo", DbType.String, entidade.NomeArquivo);
			_db.AddInParameter(command, "@tamanho", DbType.Int32, entidade.Tamanho);
			_db.AddInParameter(command, "@extensao", DbType.String, entidade.Extensao);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Arquivo da base de dados.
		/// </summary>
		/// <param name="entidade">Arquivo a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Arquivo entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Arquivo ");
			sbSQL.Append("WHERE arquivoId=@arquivoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.ArquivoId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Arquivo.
		/// </summary>
		/// <param name="entidade">Arquivo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Arquivo</returns>
		public Arquivo Carregar(int arquivoId)
		{
			Arquivo entidade = new Arquivo();
			entidade.ArquivoId = arquivoId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um Arquivo.
		/// </summary>
		/// <param name="entidade">Arquivo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Arquivo</returns>
		public Arquivo Carregar(Arquivo entidade)
		{

			Arquivo entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Arquivo WHERE arquivoId=@arquivoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.ArquivoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">Evento relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(Evento entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Arquivo.* FROM Arquivo INNER JOIN Evento ON Arquivo.arquivoId=Evento.arquivoId WHERE Evento.eventoId=@eventoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">Noticia relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(Noticia entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append(@"SELECT Arquivo.* FROM Arquivo INNER JOIN Noticia ON Arquivo.arquivoId=Noticia.arquivoIdThumbGrande
				            and Arquivo.arquivoId=Noticia.arquivoIdThumbMedio WHERE Noticia.noticiaId=@noticiaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">NoticiaImagem relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(NoticiaImagem entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Arquivo.* FROM Arquivo INNER JOIN NoticiaImagem ON Arquivo.arquivoId=NoticiaImagem.arquivoId WHERE NoticiaImagem.noticiaImagemId=@noticiaImagemId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@noticiaImagemId", DbType.Int32, entidade.NoticiaImagemId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">ReleaseImagem relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(ReleaseImagem entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Arquivo.* FROM Arquivo INNER JOIN ReleaseImagem ON Arquivo.arquivoId=ReleaseImagem.arquivoId WHERE ReleaseImagem.releaseImagemID=@releaseImagemID");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@releaseImagemID", DbType.Int32, entidade.ReleaseImagemID);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}


		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Arquivo.</returns>
		public List<Arquivo> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<Arquivo> entidadesRetorno = new List<Arquivo>();

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
				sbOrder.Append(" ORDER BY arquivoId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Arquivo");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Arquivo WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Arquivo ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Arquivo.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Arquivo ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Arquivo.* FROM Arquivo ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Arquivo existentes na base de dados.
		/// </summary>
		public List<Arquivo> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Arquivo na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Arquivo na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Arquivo");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Arquivo baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Arquivo a ser populado(.</param>
		public static void PopulaArquivo(IDataReader reader, Arquivo entidade)
		{
			if (reader["arquivoId"] != DBNull.Value)
				entidade.ArquivoId = Convert.ToInt32(reader["arquivoId"].ToString());

			if (reader["nomeArquivo"] != DBNull.Value)
				entidade.NomeArquivo = reader["nomeArquivo"].ToString();

			if (reader["tamanho"] != DBNull.Value)
				entidade.Tamanho = Convert.ToInt32(reader["tamanho"].ToString());

			if (reader["extensao"] != DBNull.Value)
				entidade.Extensao = reader["extensao"].ToString();


		}

		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">MaterialImprensa relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(MaterialImprensa entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Arquivo.* FROM Arquivo INNER JOIN MaterialImprensa ON Arquivo.arquivoId=MaterialImprensa.arquivoId WHERE MaterialImprensa.materialImprensaId=@materialImprensaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@materialImprensaId", DbType.Int32, entidade.MaterialImprensaId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}


		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">Produto relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(Produto entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Arquivo.* FROM Arquivo INNER JOIN Produto ON Arquivo.arquivoId=Produto.arquivoId WHERE Produto.produtoId=@produtoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@produtoId", DbType.Int32, entidade.ProdutoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">ProdutoImagem relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(ProdutoImagem entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Arquivo.* FROM Arquivo INNER JOIN ProdutoImagem ON Arquivo.arquivoId=ProdutoImagem.arquivoId WHERE ProdutoImagem.produtoImagemId=@produtoImagemId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@produtoImagemId", DbType.Int32, entidade.ProdutoImagemId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">ProdutoTipo relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(ProdutoTipo entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Arquivo.* FROM Arquivo INNER JOIN ProdutoTipo ON Arquivo.arquivoId=ProdutoTipo.arquivoId WHERE ProdutoTipo.produtoTipoId=@produtoTipoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@produtoTipoId", DbType.Int32, entidade.ProdutoTipoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="entidade">ProjetoEspecial relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Arquivo.</returns>
		public List<Arquivo> Carregar(ProjetoEspecial entidade)
		{
			List<Arquivo> entidadesRetorno = new List<Arquivo>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Arquivo.* FROM Arquivo INNER JOIN ProjetoEspecial ON Arquivo.arquivoId=ProjetoEspecial.arquivoId WHERE ProjetoEspecial.projetoEspecialId=@projetoEspecialId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@projetoEspecialId", DbType.Int32, entidade.ProjetoEspecialId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Arquivo entidadeRetorno = new Arquivo();
				PopulaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna uma coleção de Arquivo.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Arquivo.</returns>
		//public List<Arquivo> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		//{

		//    List<Arquivo> entidadesRetorno = new List<Arquivo>();

		//    StringBuilder sbSQL = new StringBuilder();
		//    StringBuilder sbWhere = new StringBuilder();
		//    StringBuilder sbOrder = new StringBuilder();
		//    DbCommand command;
		//    IDataReader reader;

		//    // Monta o "OrderBy"
		//    if (ordemColunas != null)
		//    {
		//        for (int i = 0; i < ordemColunas.Length; i++)
		//        {
		//            if (sbOrder.Length > 0) { sbOrder.Append(", "); }
		//            sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
		//        }
		//        if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }
		//    }
		//    else
		//    {
		//        sbOrder.Append(" ORDER BY arquivoId");
		//    }


		//    if (registrosPagina > 0)
		//    {

		//        //sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Arquivo");
		//        //if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
		//        //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Arquivo WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
		//        //} else {
		//        //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Arquivo ORDER BY " + orderBy + ")");				
		//        //}	
		//        sbSQL.Append("SELECT * FROM ( ");
		//        sbSQL.Append("SELECT Arquivo.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Arquivo ");
		//        if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
		//        sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

		//    }
		//    else
		//    {
		//        sbSQL.Append("SELECT Arquivo.* FROM Arquivo ");
		//        if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
		//        if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
		//    }

		//    command = _db.GetSqlStringCommand(sbSQL.ToString());
		//    reader = _db.ExecuteReader(command);

		//    while (reader.Read())
		//    {
		//        Arquivo entidadeRetorno = new Arquivo();
		//        PopulaArquivo(reader, entidadeRetorno);
		//        entidadesRetorno.Add(entidadeRetorno);
		//    }
		//    reader.Close();

		//}

	}
}
