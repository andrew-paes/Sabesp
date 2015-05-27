
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
	public class PodcastCategoriaIdiomaFH : IFilterHelper
	{
		private string _podcastCategoriaId;
		public string PodcastCategoriaId
		{
			get { return _podcastCategoriaId == null ? String.Empty : _podcastCategoriaId; }
			set { _podcastCategoriaId = value; }
		}

		private string _idiomaId;
		public string IdiomaId
		{
			get { return _idiomaId == null ? String.Empty : _idiomaId; }
			set { _idiomaId = value; }
		}

		private string _descricao;
		public string Descricao
		{
			get { return _descricao == null ? String.Empty : _descricao; }
			set { _descricao = value; }
		}


		public string GetWhereString()
		{
			StringBuilder sbWhere = new StringBuilder();

			if (!PodcastCategoriaId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (podcastCategoriaId=" + PodcastCategoriaId + ")");
			}

			if (!IdiomaId.Equals(String.Empty))
			{
				sbWhere.Append(" AND (idiomaId=" + IdiomaId + ")");
			}

			if (!Descricao.Equals(String.Empty))
			{
				sbWhere.Append(" AND (descricao LIKE '%" + Descricao + "%')");
			}


			if (sbWhere.Length > 0) // Remove o primeiro "AND "
				sbWhere.Remove(0, 4);
			return sbWhere.ToString();
		}
	}
}
