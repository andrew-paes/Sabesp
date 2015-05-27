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
using System.Text;

namespace Sabesp.FilterHelper
{
	public class ContatoFH : IFilterHelper
	{
		private string _contatoId;
		public string ContatoId
		{
			get { return _contatoId == null ? String.Empty : _contatoId; }
			set { _contatoId = value; }
		}

		private string _nomeContato;
		public string NomeContato
		{
			get { return _nomeContato == null ? String.Empty : _nomeContato; }
			set { _nomeContato = value; }
		}

		private string _emailContato;
		public string EmailContato
		{
			get { return _emailContato == null ? String.Empty : _emailContato; }
			set { _emailContato = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!ContatoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (contatoId=" + ContatoId + ")");
			}

			if (!NomeContato.Equals(String.Empty))
			{
				sbWhere.Append(" AND (nomeContato LIKE '%" + NomeContato + "%')");
			}

			if (!EmailContato.Equals(String.Empty))
			{
				sbWhere.Append(" AND (emailContato LIKE '%" + EmailContato + "%')");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
