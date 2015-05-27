
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
	public class ReleaseImagemComentarioFH : IFilterHelper
	{
		private string _releaseImagemId;
		public string ReleaseImagemId {
			get { return _releaseImagemId==null?String.Empty:_releaseImagemId; }
			set { _releaseImagemId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _comentarioImagem;
		public string ComentarioImagem {
			get { return _comentarioImagem==null?String.Empty:_comentarioImagem; }
			set { _comentarioImagem=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ReleaseImagemId.Equals(String.Empty)) {
				sbWhere.Append(" AND (releaseImagemId="+ReleaseImagemId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!ComentarioImagem.Equals(String.Empty)) {
				sbWhere.Append(" AND (comentarioImagem LIKE '%"+ComentarioImagem+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
