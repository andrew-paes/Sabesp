
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
	public class ControleSessaoFH : IFilterHelper
	{
		private string _controleSessaoId;
		public string ControleSessaoId
		{
			get { return _controleSessaoId == null ? String.Empty : _controleSessaoId; }
			set { _controleSessaoId = value; }
		}

		private string _secaoId;
		public string SecaoId
		{
			get { return _secaoId == null ? String.Empty : _secaoId; }
			set { _secaoId = value; }
		}

		private string _controleId;
		public string ControleId
		{
			get { return _controleId == null ? String.Empty : _controleId; }
			set { _controleId = value; }
		}

		private string _coluna;
		public string Coluna
		{
			get { return _coluna == null ? String.Empty : _coluna; }
			set { _coluna = value; }
		}

		private string _posicao;
		public string Posicao
		{
			get { return _posicao == null ? String.Empty : _posicao; }
			set { _posicao = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!ControleSessaoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (controleSessaoId=" + ControleSessaoId + ")");
			}

			if (!SecaoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (secaoId=" + SecaoId + ")");
			}

			if (!ControleId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (controleId=" + ControleId + ")");
			}

			if (!Coluna.Equals(String.Empty))
			{
				sbWhere.Append(" AND (coluna=" + Coluna + ")");
			}

			if (!Posicao.Equals(String.Empty))
			{
				sbWhere.Append(" AND (posicao=" + Posicao + ")");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
