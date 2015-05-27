
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
	public class EventoFotoFH : IFilterHelper
	{
		private string _eventoFotoId;
		public string EventoFotoId
		{
			get { return _eventoFotoId == null ? String.Empty : _eventoFotoId; }
			set { _eventoFotoId = value; }
		}

		private string _arquivoId;
		public string ArquivoId
		{
			get { return _arquivoId == null ? String.Empty : _arquivoId; }
			set { _arquivoId = value; }
		}

		private string _eventoId;
		public string EventoId
		{
			get { return _eventoId == null ? String.Empty : _eventoId; }
			set { _eventoId = value; }
		}

		private string _ordem;
		public string Ordem
		{
			get { return _ordem == null ? String.Empty : _ordem; }
			set { _ordem = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!EventoFotoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (eventoFotoId=" + EventoFotoId + ")");
			}

			if (!ArquivoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (arquivoId=" + ArquivoId + ")");
			}

			if (!EventoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (eventoId=" + EventoId + ")");
			}

			if (!Ordem.Equals(String.Empty))
			{
				sbWhere.Append(" AND (ordem=" + Ordem + ")");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
