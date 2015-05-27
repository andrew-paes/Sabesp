
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
	public class PodcastCategoriaFH : IFilterHelper
	{
		private string _podcastCategoriaId;
		public string PodcastCategoriaId
		{
			get { return _podcastCategoriaId == null ? String.Empty : _podcastCategoriaId; }
			set { _podcastCategoriaId = value; }
		}

		private string _ativo;
		public string Ativo
		{
			get { return _ativo == null ? String.Empty : _ativo; }
			set { _ativo = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!PodcastCategoriaId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (podcastCategoriaId=" + PodcastCategoriaId + ")");
			}

			if (!Ativo.Equals(String.Empty))
			{
				sbWhere.Append(" AND (ativo LIKE '%" + Ativo + "%')");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
