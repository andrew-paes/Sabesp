
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
	public class NoticiaTesteIdiomaFH : IFilterHelper
	{
		private string _noticiaTesteId;
		public string NoticiaTesteId {
			get { return _noticiaTesteId==null?String.Empty:_noticiaTesteId; }
			set { _noticiaTesteId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _titulo;
		public string Titulo {
			get { return _titulo==null?String.Empty:_titulo; }
			set { _titulo=value; }
		}

		private string _conteudo;
		public string Conteudo {
			get { return _conteudo==null?String.Empty:_conteudo; }
			set { _conteudo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!NoticiaTesteId.Equals(String.Empty)) {
				sbWhere.Append(" AND (noticiaTesteId="+NoticiaTesteId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!Titulo.Equals(String.Empty)) {
				sbWhere.Append(" AND (titulo LIKE '%"+Titulo+"%')");
			}

			if (!Conteudo.Equals(String.Empty)) {
				sbWhere.Append(" AND (conteudo LIKE '%"+Conteudo+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
