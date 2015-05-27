
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
	public class ProjetoEspecialFH : IFilterHelper
	{
		private string _projetoEspecialId;
		public string ProjetoEspecialId
		{
			get { return _projetoEspecialId == null ? String.Empty : _projetoEspecialId; }
			set { _projetoEspecialId = value; }
		}

		private string _ativo;
		public string Ativo
		{
			get { return _ativo == null ? String.Empty : _ativo; }
			set { _ativo = value; }
		}

		private string _url;
		public string Url
		{
			get { return _url == null ? String.Empty : _url; }
			set { _url = value; }
		}

		private string _arquivoThumbId;
		public string ArquivoThumbId
		{
			get { return _arquivoThumbId == null ? String.Empty : _arquivoThumbId; }
			set { _arquivoThumbId = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!ProjetoEspecialId.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (projetoEspecialId=", ProjetoEspecialId, ")"));
			}

			if (!Ativo.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (ativo=", Ativo, ")"));
			}

			if (!Url.Equals(String.Empty))
			{
				sbWhere.Append(" AND (url LIKE '%" + Url + "%')");
			}

			if (!ArquivoThumbId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (arquivoThumbId=" + ArquivoThumbId + ")");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
