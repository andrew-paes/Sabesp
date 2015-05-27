
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
	public class ReleaseIdiomaFH : IFilterHelper
	{
		private string _releaseId;
		public string ReleaseId {
			get { return _releaseId==null?String.Empty:_releaseId; }
			set { _releaseId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _tituloRelease;
		public string TituloRelease {
			get { return _tituloRelease==null?String.Empty:_tituloRelease; }
			set { _tituloRelease=value; }
		}

		private string _chamadaRelease;
		public string ChamadaRelease {
			get { return _chamadaRelease==null?String.Empty:_chamadaRelease; }
			set { _chamadaRelease=value; }
		}

		private string _textoRelease;
		public string TextoRelease {
			get { return _textoRelease==null?String.Empty:_textoRelease; }
			set { _textoRelease=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ReleaseId.Equals(String.Empty)) {
				sbWhere.Append(" AND (releaseId="+ReleaseId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!TituloRelease.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloRelease LIKE '%"+TituloRelease+"%')");
			}

			if (!ChamadaRelease.Equals(String.Empty)) {
				sbWhere.Append(" AND (chamadaRelease LIKE '%"+ChamadaRelease+"%')");
			}

			if (!TextoRelease.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoRelease LIKE '%"+TextoRelease+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
