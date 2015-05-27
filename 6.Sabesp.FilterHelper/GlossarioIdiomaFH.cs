
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
	public class GlossarioIdiomaFH : IFilterHelper
	{
		private string _glossarioId;
		public string GlossarioId {
			get { return _glossarioId==null?String.Empty:_glossarioId; }
			set { _glossarioId=value; }
		}

		private string _palavra;
		public string Palavra {
			get { return _palavra==null?String.Empty:_palavra; }
			set { _palavra=value; }
		}

		private string _descricao;
		public string Descricao {
			get { return _descricao==null?String.Empty:_descricao; }
			set { _descricao=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!GlossarioId.Equals(String.Empty)) {
				sbWhere.Append(" AND (glossarioId="+GlossarioId+")");
			}

			if (!Palavra.Equals(String.Empty)) {
				sbWhere.Append(" AND (palavra LIKE '"+Palavra+"%')");
			}

			if (!Descricao.Equals(String.Empty)) {
				sbWhere.Append(" AND (descricao LIKE '%"+Descricao+"%')");
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
