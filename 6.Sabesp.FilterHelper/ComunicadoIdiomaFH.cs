
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
	public class ComunicadoIdiomaFH : IFilterHelper
	{
		private string _comunicadoId;
		public string ComunicadoId {
			get { return _comunicadoId==null?String.Empty:_comunicadoId; }
			set { _comunicadoId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _tituloComunicado;
		public string TituloComunicado {
			get { return _tituloComunicado==null?String.Empty:_tituloComunicado; }
			set { _tituloComunicado=value; }
		}

		private string _textoComunicado;
		public string TextoComunicado {
			get { return _textoComunicado==null?String.Empty:_textoComunicado; }
			set { _textoComunicado=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ComunicadoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (comunicadoId="+ComunicadoId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!TituloComunicado.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloComunicado LIKE '%"+TituloComunicado+"%')");
			}

			if (!TextoComunicado.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoComunicado LIKE '%"+TextoComunicado+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
