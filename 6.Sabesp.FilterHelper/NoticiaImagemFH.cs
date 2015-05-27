
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
	public class NoticiaImagemFH : IFilterHelper
	{
		private string _noticiaImagemId;
		public string NoticiaImagemId
		{
			get { return _noticiaImagemId == null ? String.Empty : _noticiaImagemId; }
			set { _noticiaImagemId = value; }
		}

		private string _noticiaId;
		public string NoticiaId
		{
			get { return _noticiaId == null ? String.Empty : _noticiaId; }
			set { _noticiaId = value; }
		}

		private string _arquivoId;
		public string ArquivoId
		{
			get { return _arquivoId == null ? String.Empty : _arquivoId; }
			set { _arquivoId = value; }
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

			if (!NoticiaImagemId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (noticiaImagemId=" + NoticiaImagemId + ")");
			}

			if (!NoticiaId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (noticiaId=" + NoticiaId + ")");
			}

			if (!ArquivoId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (arquivoId=" + ArquivoId + ")");
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
