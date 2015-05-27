
using System;
using System.Text;

namespace Sabesp.FilterHelper
{
	public class ConteudoTagFH : IFilterHelper
	{
	
		private string _conteudoId;
		public string ConteudoId {
			get { return _conteudoId==null?String.Empty:_conteudoId; }
			set { _conteudoId=value; }
		}

		private string _tagId;
		public string TagId {
			get { return _tagId==null?String.Empty:_tagId; }
			set { _tagId=value; }
		}


		public string GetWhereString() {
		
			StringBuilder sbWhere = new StringBuilder();		
			
			if (!ConteudoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (conteudoId = "+ConteudoId+ ")");
			}

			if (!TagId.Equals(String.Empty)) {
				sbWhere.Append(" AND (tagId="+TagId.ToString()+")");
			}

				
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
