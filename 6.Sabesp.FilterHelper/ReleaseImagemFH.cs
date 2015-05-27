
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
	public class ReleaseImagemFH : IFilterHelper
	{
		private string _releaseImagemID;
		public string ReleaseImagemID {
			get { return _releaseImagemID==null?String.Empty:_releaseImagemID; }
			set { _releaseImagemID=value; }
		}

		private string _arquivoId;
		public string ArquivoId {
			get { return _arquivoId==null?String.Empty:_arquivoId; }
			set { _arquivoId=value; }
		}

		private string _ordem;
		public string Ordem {
			get { return _ordem==null?String.Empty:_ordem; }
			set { _ordem=value; }
		}

		private string _releaseId;
		public string ReleaseId {
			get { return _releaseId==null?String.Empty:_releaseId; }
			set { _releaseId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ReleaseImagemID.Equals(String.Empty)) {
				sbWhere.Append(" AND (releaseImagemID="+ReleaseImagemID+")");
			}

			if (!ArquivoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoId="+ArquivoId+")");
			}

			if (!Ordem.Equals(String.Empty)) {
				sbWhere.Append(" AND (ordem="+Ordem+")");
			}

			if (!ReleaseId.Equals(String.Empty)) {
				sbWhere.Append(" AND (releaseId="+ReleaseId+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
