
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
	public class RegiaoFH : IFilterHelper
	{
		private string _regiaoId;
		public string RegiaoId {
			get { return _regiaoId==null?String.Empty:_regiaoId; }
			set { _regiaoId=value; }
		}

		private string _nomeRegiao;
		public string NomeRegiao {
			get { return _nomeRegiao==null?String.Empty:_nomeRegiao; }
			set { _nomeRegiao=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!RegiaoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (regiaoId="+RegiaoId+")");
			}

			if (!NomeRegiao.Equals(String.Empty)) {
				sbWhere.Append(" AND (nomeRegiao LIKE '%"+NomeRegiao+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
