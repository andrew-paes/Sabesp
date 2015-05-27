
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
	public class TagFH : IFilterHelper
	{
		private string _tagId;
		public string TagId {
			get { return _tagId==null?String.Empty:_tagId; }
			set { _tagId=value; }
		}

		private string _palavra;
		public string Palavra {
			get { return _palavra==null?String.Empty:_palavra; }
			set { _palavra=value; }
		}

		private string _hits;
		public string Hits {
			get { return _hits==null?String.Empty:_hits; }
			set { _hits=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!TagId.Equals(String.Empty)) {
				sbWhere.Append(" AND (tagId="+TagId+")");
			}

			if (!Palavra.Equals(String.Empty)) {
				sbWhere.Append(" AND (palavra LIKE '%"+Palavra+"%')");
			}

			if (!Hits.Equals(String.Empty)) {
				sbWhere.Append(" AND (hits="+Hits+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
