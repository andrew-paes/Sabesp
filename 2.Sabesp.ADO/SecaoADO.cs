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
    public class SecaoADO : ADOSuper, ISecaoDAL
    {
        /// <summary>
        /// Método que persiste um Secao.
        /// </summary>
        /// <param name="entidade">Secao contendo os dados a serem persistidos.</param>	
        public void Inserir(Secao entidade)
        {
            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            // Monta a string de insert.
            sbSQL.Append(" INSERT INTO Secao ");
            sbSQL.Append(" (secaoIdPai, modeloId, ordem, avaliacaoSomaNotas, avaliacoes, acessoRapido, estadoPublicacao, redirecionaId, secaoAutenticada, habilitaBoxRSS, comentar, avaliar, compartilhar, exibeNoMenu, exibeNaHome, posicaoHome) ");
            sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@secaoIdPai, @modeloId, @ordem, @avaliacaoSomaNotas, @avaliacoes, @acessoRapido, @estadoPublicacao, @redirecionaId, @secaoAutenticada, @habilitaBoxRSS, @comentar, @avaliar, @compartilhar, @exibeNoMenu, @exibeNaHome, @posicaoHome) ");

            sbSQL.Append(" ; SET @secaoId = SCOPE_IDENTITY(); ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddOutParameter(command, "@secaoId", DbType.Int32, 8);

            if (entidade.SecaoPai != null)
                _db.AddInParameter(command, "@secaoIdPai", DbType.Int32, entidade.SecaoPai.SecaoId);
            else
                _db.AddInParameter(command, "@secaoIdPai", DbType.Int32, null);

            if (entidade.Modelo != null && entidade.Modelo.ModeloId > 0)
                _db.AddInParameter(command, "@modeloId", DbType.Int32, entidade.Modelo.ModeloId);
            else
                _db.AddInParameter(command, "@modeloId", DbType.Int32, null);

            if (entidade.Ordem != null)
                _db.AddInParameter(command, "@ordem", DbType.Int32, entidade.Ordem);
            else
                _db.AddInParameter(command, "@ordem", DbType.Int32, null);

            if (entidade.AvaliacaoSomaNotas != null)
                _db.AddInParameter(command, "@avaliacaoSomaNotas", DbType.Int32, entidade.AvaliacaoSomaNotas);
            else
                _db.AddInParameter(command, "@avaliacaoSomaNotas", DbType.Int32, null);

            if (entidade.Avaliacoes != null)
                _db.AddInParameter(command, "@avaliacoes", DbType.Int32, entidade.Avaliacoes);
            else
                _db.AddInParameter(command, "@avaliacoes", DbType.Int32, null);

            if (entidade.AcessoRapido != null)
                _db.AddInParameter(command, "@acessoRapido", DbType.Int32, entidade.AcessoRapido);
            else
                _db.AddInParameter(command, "@acessoRapido", DbType.Int32, null);

            if (entidade.EstadoPublicacao != null)
                _db.AddInParameter(command, "@estadoPublicacao", DbType.String, entidade.EstadoPublicacao);
            else
                _db.AddInParameter(command, "@estadoPublicacao", DbType.String, null);

            if (entidade.RedirecionaId != null)
                _db.AddInParameter(command, "@redirecionaId", DbType.Int32, entidade.RedirecionaId);
            else
                _db.AddInParameter(command, "@redirecionaId", DbType.Int32, null);

            if (entidade.SecaoAutenticada != null)
                _db.AddInParameter(command, "@secaoAutenticada", DbType.Int32, entidade.SecaoAutenticada);
            else
                _db.AddInParameter(command, "@secaoAutenticada", DbType.Int32, null);

            if (entidade.HabilitaBoxRSS != null)
                _db.AddInParameter(command, "@habilitaBoxRSS", DbType.Int32, entidade.HabilitaBoxRSS);
            else
                _db.AddInParameter(command, "@habilitaBoxRSS", DbType.Int32, null);

            if (entidade.Comentar != null)
                _db.AddInParameter(command, "@comentar", DbType.Int32, entidade.Comentar);
            else
                _db.AddInParameter(command, "@comentar", DbType.Int32, null);

            if (entidade.Avaliar != null)
                _db.AddInParameter(command, "@avaliar", DbType.Int32, entidade.Avaliar);
            else
                _db.AddInParameter(command, "@avaliar", DbType.Int32, null);

            if (entidade.Compartilhar != null)
                _db.AddInParameter(command, "@compartilhar", DbType.Int32, entidade.Compartilhar);
            else
                _db.AddInParameter(command, "@compartilhar", DbType.Int32, null);

            if (entidade.ExibeNoMenu != null)
                _db.AddInParameter(command, "@exibeNoMenu", DbType.Int32, entidade.ExibeNoMenu);
            else
                _db.AddInParameter(command, "@exibeNoMenu", DbType.Int32, null);

			if (entidade.ExibeNaHome != null)
				_db.AddInParameter(command, "@exibeNaHome", DbType.Int32, entidade.ExibeNaHome);
			else
				_db.AddInParameter(command, "@exibeNaHome", DbType.Int32, null);

			if (entidade.PosicaoHome != null)
				_db.AddInParameter(command, "@posicaoHome", DbType.Int32, entidade.PosicaoHome);
			else
				_db.AddInParameter(command, "@posicaoHome", DbType.Int32, null);

            // Executa a query.
            _db.ExecuteNonQuery(command);

            entidade.SecaoId = Convert.ToInt32(_db.GetParameterValue(command, "@secaoId"));

        }

        /// <summary>
        /// Método que atualiza os dados de um Secao.
        /// </summary>
        /// <param name="entidade">Secao contendo os dados a serem atualizados.</param>
        public void Atualizar(Secao entidade)
        {

            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            // Monta a string de atualização.
            sbSQL.Append(" UPDATE Secao SET ");
			sbSQL.Append(" secaoId=@secaoId, secaoIdPai=@secaoIdPai, modeloId=@modeloId, ordem=@ordem, avaliacaoSomaNotas=@avaliacaoSomaNotas, avaliacoes=@avaliacoes, acessoRapido=@acessoRapido, estadoPublicacao=@estadoPublicacao, redirecionaId=@redirecionaId, secaoAutenticada=@secaoAutenticada, habilitaBoxRSS=@habilitaBoxRSS, comentar=@comentar, avaliar=@avaliar, compartilhar=@compartilhar, exibeNoMenu=@exibeNoMenu, exibeNaHome=@exibeNaHome, posicaoHome=@posicaoHome ");
            sbSQL.Append(" WHERE  ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Parâmetros
            _db.AddInParameter(command, "@secaoId", DbType.Int32, entidade.SecaoId);
            if (entidade.SecaoPai != null)
                _db.AddInParameter(command, "@secaoIdPai", DbType.Int32, entidade.SecaoPai.SecaoId);
            else
                _db.AddInParameter(command, "@secaoIdPai", DbType.Int32, null);
            if (entidade.Modelo != null)
                _db.AddInParameter(command, "@modeloId", DbType.Int32, entidade.Modelo.ModeloId);
            else
                _db.AddInParameter(command, "@modeloId", DbType.Int32, null);
            if (entidade.Ordem != null)
                _db.AddInParameter(command, "@ordem", DbType.Int32, entidade.Ordem);
            else
                _db.AddInParameter(command, "@ordem", DbType.Int32, null);
            if (entidade.AvaliacaoSomaNotas != null)
                _db.AddInParameter(command, "@avaliacaoSomaNotas", DbType.Int32, entidade.AvaliacaoSomaNotas);
            else
                _db.AddInParameter(command, "@avaliacaoSomaNotas", DbType.Int32, null);
            if (entidade.Avaliacoes != null)
                _db.AddInParameter(command, "@avaliacoes", DbType.Int32, entidade.Avaliacoes);
            else
                _db.AddInParameter(command, "@avaliacoes", DbType.Int32, null);
            if (entidade.AcessoRapido != null)
                _db.AddInParameter(command, "@acessoRapido", DbType.Int32, entidade.AcessoRapido);
            else
                _db.AddInParameter(command, "@acessoRapido", DbType.Int32, null);
            if (entidade.EstadoPublicacao != null)
                _db.AddInParameter(command, "@estadoPublicacao", DbType.String, entidade.EstadoPublicacao);
            else
                _db.AddInParameter(command, "@estadoPublicacao", DbType.String, null);
            if (entidade.RedirecionaId != null)
                _db.AddInParameter(command, "@redirecionaId", DbType.Int32, entidade.RedirecionaId);
            else
                _db.AddInParameter(command, "@redirecionaId", DbType.Int32, null);
            if (entidade.SecaoAutenticada != null)
                _db.AddInParameter(command, "@secaoAutenticada", DbType.Int32, entidade.SecaoAutenticada);
            else
                _db.AddInParameter(command, "@secaoAutenticada", DbType.Int32, null);
            if (entidade.HabilitaBoxRSS != null)
                _db.AddInParameter(command, "@habilitaBoxRSS", DbType.Int32, entidade.HabilitaBoxRSS);
            else
                _db.AddInParameter(command, "@habilitaBoxRSS", DbType.Int32, null);
            if (entidade.Comentar != null)
                _db.AddInParameter(command, "@comentar", DbType.Int32, entidade.Comentar);
            else
                _db.AddInParameter(command, "@comentar", DbType.Int32, null);
            if (entidade.Avaliar != null)
                _db.AddInParameter(command, "@avaliar", DbType.Int32, entidade.Avaliar);
            else
                _db.AddInParameter(command, "@avaliar", DbType.Int32, null);
            if (entidade.Compartilhar != null)
                _db.AddInParameter(command, "@compartilhar", DbType.Int32, entidade.Compartilhar);
            else
                _db.AddInParameter(command, "@compartilhar", DbType.Int32, null);
            if (entidade.ExibeNoMenu != null)
                _db.AddInParameter(command, "@exibeNoMenu", DbType.Int32, entidade.ExibeNoMenu);
            else
                _db.AddInParameter(command, "@exibeNoMenu", DbType.Int32, null);

			if (entidade.ExibeNaHome != null)
				_db.AddInParameter(command, "@exibeNaHome", DbType.Int32, entidade.ExibeNaHome);
			else
				_db.AddInParameter(command, "@exibeNaHome", DbType.Int32, null);

			if (entidade.PosicaoHome != null)
				_db.AddInParameter(command, "@posicaoHome", DbType.Int32, entidade.PosicaoHome);
			else
				_db.AddInParameter(command, "@posicaoHome", DbType.Int32, null);

            // Executa a query.
            _db.ExecuteNonQuery(command);

        }

        /// <summary>
        /// Método que remove um Secao da base de dados.
        /// </summary>
        /// <param name="entidade">Secao a ser excluído (somente o identificador é necessário).</param>		
        public void Excluir(Secao entidade)
        {
            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            sbSQL.Append("DELETE FROM Secao ");
            sbSQL.Append("WHERE  ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());



            _db.ExecuteNonQuery(command);
        }


        /// <summary>
        /// Método que carrega um Secao.
        /// </summary>
        /// <param name="entidade">Secao a ser carregado (somente o identificador é necessário).</param>
        /// <returns>Secao</returns>
        public Secao Carregar(Secao entidade)
        {

            Secao entidadeRetorno = null;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM Secao WHERE secaoId=@secaoId");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
            _db.AddInParameter(command, "@secaoId", DbType.Int32, entidade.SecaoId);

            IDataReader reader = _db.ExecuteReader(command);

            if (reader.Read())
            {
                entidadeRetorno = new Secao();
                PopulaSecao(reader, entidadeRetorno);
            }
            reader.Close();

            return entidadeRetorno;
        }


		public List<Secao> CarregarFilhos(int secaoIdPai)
		{
			return this.CarregarFilhos(secaoIdPai, true);
		}

		public List<Secao> CarregarFilhos(int secaoIdPai, bool exibeNoMenu)
		{
			return this.CarregarFilhos(secaoIdPai, (bool?)exibeNoMenu);
		}

		private List<Secao> CarregarFilhos(int secaoIdPai, bool? exibeNoMenu)
        {
            List<Secao> retorno = new List<Secao>();
            Secao entidadeRetorno = null;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM Secao WHERE secaoIdPai=@secaoIdPai ");

			if (exibeNoMenu != null)
			{
				sbSQL.Append(String.Concat("AND exibeNoMenu=", exibeNoMenu.Value ? "1 " : "0 "));
			}

			sbSQL.Append("ORDER BY ordem");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
            _db.AddInParameter(command, "@secaoIdPai", DbType.Int32, secaoIdPai);

            IDataReader reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                entidadeRetorno = new Secao();
                PopulaSecao(reader, entidadeRetorno);

                retorno.Add(entidadeRetorno);
            }
            reader.Close();

            return retorno;
        }


        /// <summary>
        /// Método que retorna uma coleção de Secao.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
        ///  <returns>Retorna um List contendos Secao.</returns>
        public List<Secao> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {

            List<Secao> entidadesRetorno = new List<Secao>();

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
                sbOrder.Append(" ORDER BY ");
            }


            if (registrosPagina > 0)
            {

                //sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Secao");
                //if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
                //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Secao WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
                //} else {
                //	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Secao ORDER BY " + orderBy + ")");				
                //}	
                sbSQL.Append("SELECT * FROM ( ");
                sbSQL.Append("SELECT Secao.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Secao ");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
                sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

            }
            else
            {
                sbSQL.Append("SELECT Secao.* FROM Secao ");
                if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
                if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
            }

            command = _db.GetSqlStringCommand(sbSQL.ToString());
            reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                Secao entidadeRetorno = new Secao();
                PopulaSecao(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;

        }

        /// <summary>
        /// Método que retorna todas os Secao existentes na base de dados.
        /// </summary>
        public List<Secao> CarregarTodos()
        {
            return CarregarTodos(0, 0, null, null, null);
        }

        /// <summary>
        /// Método que retorna o total de Secao na base de dados.
        /// </summary>
        /// <returns></returns>
        public int TotalRegistros()
        {
            return TotalRegistros(null);
        }

        /// <summary>
        /// Método que retorna o total de Secao na base de dados, aceita filtro.
        /// </summary>
        /// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
        /// <returns></returns>
        public int TotalRegistros(IFilterHelper filtro)
        {
            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT COUNT(*) AS Total FROM Secao");

            if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
                sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            // Executa a query.

            int resultado = (int)_db.ExecuteScalar(command);


            return resultado;
        }

        /// <summary>
        /// Método que retorna popula um Secao baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">Secao a ser populado(.</param>
        public static void PopulaSecao(IDataReader reader, Secao entidade)
        {
            if (reader["secaoId"] != DBNull.Value)
                entidade.SecaoId = Convert.ToInt32(reader["secaoId"].ToString());

            if (reader["secaoIdPai"] != DBNull.Value)
            {
                entidade.SecaoPai = new Secao();
                entidade.SecaoPai.SecaoId = Convert.ToInt32(reader["secaoIdPai"].ToString());
            }

            if (reader["modeloId"] != DBNull.Value)
            {
                entidade.Modelo = new Modelo();
                entidade.Modelo.ModeloId = Convert.ToInt32(reader["modeloId"].ToString());
            }

            if (reader["ordem"] != DBNull.Value)
                entidade.Ordem = Convert.ToInt32(reader["ordem"].ToString());

            if (reader["avaliacaoSomaNotas"] != DBNull.Value)
                entidade.AvaliacaoSomaNotas = Convert.ToInt32(reader["avaliacaoSomaNotas"].ToString());

            if (reader["avaliacoes"] != DBNull.Value)
                entidade.Avaliacoes = Convert.ToInt32(reader["avaliacoes"].ToString());

            if (reader["acessoRapido"] != DBNull.Value)
                entidade.AcessoRapido = Convert.ToBoolean(reader["acessoRapido"].ToString());

            if (reader["estadoPublicacao"] != DBNull.Value)
                entidade.EstadoPublicacao = reader["estadoPublicacao"].ToString();

            if (reader["redirecionaId"] != DBNull.Value)
                entidade.RedirecionaId = Convert.ToInt32(reader["redirecionaId"].ToString());

            if (reader["secaoAutenticada"] != DBNull.Value)
                entidade.SecaoAutenticada = Convert.ToBoolean(reader["secaoAutenticada"].ToString());

            if (reader["habilitaBoxRSS"] != DBNull.Value)
                entidade.HabilitaBoxRSS = Convert.ToBoolean(reader["habilitaBoxRSS"].ToString());

            if (reader["comentar"] != DBNull.Value)
                entidade.Comentar = Convert.ToBoolean(reader["comentar"].ToString());

            if (reader["avaliar"] != DBNull.Value)
                entidade.Avaliar = Convert.ToBoolean(reader["avaliar"].ToString());

            if (reader["compartilhar"] != DBNull.Value)
                entidade.Compartilhar = Convert.ToBoolean(reader["compartilhar"].ToString());

            if (reader["exibeNoMenu"] != DBNull.Value)
                entidade.ExibeNoMenu = Convert.ToBoolean(reader["exibeNoMenu"].ToString());

			if (reader["exibeNaHome"] != DBNull.Value)
				entidade.ExibeNaHome = Convert.ToBoolean(reader["exibeNaHome"].ToString());

			if (reader["posicaoHome"] != DBNull.Value)
				entidade.PosicaoHome = Convert.ToInt32(reader["posicaoHome"].ToString());
        }

    }
}
