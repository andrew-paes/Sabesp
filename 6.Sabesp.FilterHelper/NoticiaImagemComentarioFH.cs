
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
	public class NoticiaImagemComentarioFH : IFilterHelper
	{
		private string _noticiaImagemId;
		public string NoticiaImagemId {
			get { return _noticiaImagemId==null?String.Empty:_noticiaImagemId; }
			set { _noticiaImagemId=value; }
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

			if (!NoticiaImagemId.Equals(String.Empty)) {
				sbWhere.Append(" AND (noticiaImagemId="+NoticiaImagemId+")");
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
