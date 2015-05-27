
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
using System.Text;

namespace Sabesp.FilterHelper
{
	public class SecaoFH : IFilterHelper
	{
		private string _secaoId;
		public string SecaoId
		{
			get { return _secaoId == null ? String.Empty : _secaoId; }
			set { _secaoId = value; }
		}

		private string _secaoIdPai;
		public string SecaoIdPai
		{
			get { return _secaoIdPai == null ? String.Empty : _secaoIdPai; }
			set { _secaoIdPai = value; }
		}

		private string _modeloId;
		public string ModeloId
		{
			get { return _modeloId == null ? String.Empty : _modeloId; }
			set { _modeloId = value; }
		}

		private string _ordem;
		public string Ordem
		{
			get { return _ordem == null ? String.Empty : _ordem; }
			set { _ordem = value; }
		}

		private string _avaliacaoSomaNotas;
		public string AvaliacaoSomaNotas
		{
			get { return _avaliacaoSomaNotas == null ? String.Empty : _avaliacaoSomaNotas; }
			set { _avaliacaoSomaNotas = value; }
		}

		private string _avaliacoes;
		public string Avaliacoes
		{
			get { return _avaliacoes == null ? String.Empty : _avaliacoes; }
			set { _avaliacoes = value; }
		}

		private string _acessoRapido;
		public string AcessoRapido
		{
			get { return _acessoRapido == null ? String.Empty : _acessoRapido; }
			set { _acessoRapido = value; }
		}

		private string _estadoPublicacao;
		public string EstadoPublicacao
		{
			get { return _estadoPublicacao == null ? String.Empty : _estadoPublicacao; }
			set { _estadoPublicacao = value; }
		}

		private string _redirecionaId;
		public string RedirecionaId
		{
			get { return _redirecionaId == null ? String.Empty : _redirecionaId; }
			set { _redirecionaId = value; }
		}

		private string _secaoAutenticada;
		public string SecaoAutenticada
		{
			get { return _secaoAutenticada == null ? String.Empty : _secaoAutenticada; }
			set { _secaoAutenticada = value; }
		}

		private string _habilitaBoxRSS;
		public string HabilitaBoxRSS
		{
			get { return _habilitaBoxRSS == null ? String.Empty : _habilitaBoxRSS; }
			set { _habilitaBoxRSS = value; }
		}

		private string _comentar;
		public string Comentar
		{
			get { return _comentar == null ? String.Empty : _comentar; }
			set { _comentar = value; }
		}

		private string _avaliar;
		public string Avaliar
		{
			get { return _avaliar == null ? String.Empty : _avaliar; }
			set { _avaliar = value; }
		}

		private string _compartilhar;
		public string Compartilhar
		{
			get { return _compartilhar == null ? String.Empty : _compartilhar; }
			set { _compartilhar = value; }
		}

		private string _exibeNoMenu;
		public string ExibeNoMenu
		{
			get { return _exibeNoMenu == null ? String.Empty : _exibeNoMenu; }
			set { _exibeNoMenu = value; }
		}

		private string _exibeNaHome;
		public string ExibeNaHome
		{
			get { return _exibeNaHome == null ? String.Empty : _exibeNaHome; }
			set { _exibeNaHome = value; }
		}

		private string _posicaoHome;
		public string PosicaoHome
		{
			get { return _posicaoHome == null ? String.Empty : _posicaoHome; }
			set { _posicaoHome = value; }
		}

		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!SecaoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (secaoId=" + SecaoId + ")");
			}

			if (!SecaoIdPai.Equals(String.Empty))
			{
				sbWhere.Append(" AND (secaoIdPai=" + SecaoIdPai + ")");
			}

			if (!ModeloId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (modeloId=" + ModeloId + ")");
			}

			if (!Ordem.Equals(String.Empty))
			{
				sbWhere.Append(" AND (ordem=" + Ordem + ")");
			}

			if (!AvaliacaoSomaNotas.Equals(String.Empty))
			{
				sbWhere.Append(" AND (avaliacaoSomaNotas=" + AvaliacaoSomaNotas + ")");
			}

			if (!Avaliacoes.Equals(String.Empty))
			{
				sbWhere.Append(" AND (avaliacoes=" + Avaliacoes + ")");
			}

			if (!AcessoRapido.Equals(String.Empty))
			{
				sbWhere.Append(" AND (acessoRapido LIKE '%" + AcessoRapido + "%')");
			}

			if (!EstadoPublicacao.Equals(String.Empty))
			{
				sbWhere.Append(" AND (estadoPublicacao LIKE '%" + EstadoPublicacao + "%')");
			}

			if (!RedirecionaId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (redirecionaId=" + RedirecionaId + ")");
			}

			if (!SecaoAutenticada.Equals(String.Empty))
			{
				sbWhere.Append(" AND (secaoAutenticada LIKE '%" + SecaoAutenticada + "%')");
			}

			if (!HabilitaBoxRSS.Equals(String.Empty))
			{
				sbWhere.Append(" AND (habilitaBoxRSS LIKE '%" + HabilitaBoxRSS + "%')");
			}

			if (!Comentar.Equals(String.Empty))
			{
				sbWhere.Append(" AND (comentar LIKE '%" + Comentar + "%')");
			}

			if (!Avaliar.Equals(String.Empty))
			{
				sbWhere.Append(" AND (avaliar LIKE '%" + Avaliar + "%')");
			}

			if (!Compartilhar.Equals(String.Empty))
			{
				sbWhere.Append(" AND (compartilhar LIKE '%" + Compartilhar + "%')");
			}

			if (!ExibeNoMenu.Equals(String.Empty))
			{
				sbWhere.Append(" AND (exibeNoMenu=" + ExibeNoMenu + ")");
			}

			if (!ExibeNaHome.Equals(String.Empty))
			{
				sbWhere.Append(" AND (exibeNaHome=" + ExibeNaHome + ")");
			}

			if (!PosicaoHome.Equals(String.Empty))
			{
				sbWhere.Append(" AND (posicao=" + PosicaoHome + ")");
			}

			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
