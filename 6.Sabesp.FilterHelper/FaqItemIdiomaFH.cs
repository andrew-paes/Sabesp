
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
	public class FaqItemIdiomaFH : IFilterHelper
	{
		private string _faqItemId;
		public string FaqItemId {
			get { return _faqItemId==null?String.Empty:_faqItemId; }
			set { _faqItemId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _pergunta;
		public string Pergunta {
			get { return _pergunta==null?String.Empty:_pergunta; }
			set { _pergunta=value; }
		}

		private string _resposta;
		public string Resposta {
			get { return _resposta==null?String.Empty:_resposta; }
			set { _resposta=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!FaqItemId.Equals(String.Empty)) {
				sbWhere.Append(" AND (faqItemId="+FaqItemId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!Pergunta.Equals(String.Empty)) {
				sbWhere.Append(" AND (pergunta LIKE '%"+Pergunta+"%')");
			}

			if (!Resposta.Equals(String.Empty)) {
				sbWhere.Append(" AND (resposta LIKE '%"+Resposta+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
