
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
	public class NoticiaIdiomaFH : IFilterHelper
	{
		private string _noticiaId;
		public string NoticiaId {
			get { return _noticiaId==null?String.Empty:_noticiaId; }
			set { _noticiaId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _tituloNoticia;
		public string TituloNoticia {
			get { return _tituloNoticia==null?String.Empty:_tituloNoticia; }
			set { _tituloNoticia=value; }
		}

		private string _chamadaNoticia;
		public string ChamadaNoticia {
			get { return _chamadaNoticia==null?String.Empty:_chamadaNoticia; }
			set { _chamadaNoticia=value; }
		}

		private string _textoNoticia;
		public string TextoNoticia {
			get { return _textoNoticia==null?String.Empty:_textoNoticia; }
			set { _textoNoticia=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!NoticiaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (noticiaId="+NoticiaId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!TituloNoticia.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloNoticia LIKE '%"+TituloNoticia+"%')");
			}

			if (!ChamadaNoticia.Equals(String.Empty)) {
				sbWhere.Append(" AND (chamadaNoticia LIKE '%"+ChamadaNoticia+"%')");
			}

			if (!TextoNoticia.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoNoticia LIKE '%"+TextoNoticia+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
