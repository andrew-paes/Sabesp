
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
	public class SolucaoAmbientalIdiomaFH : IFilterHelper
	{
		private string _arquivoIdFoto;
		public string ArquivoIdFoto {
			get { return _arquivoIdFoto==null?String.Empty:_arquivoIdFoto; }
			set { _arquivoIdFoto=value; }
		}

		private string _tituloPrincipal;
		public string TituloPrincipal {
			get { return _tituloPrincipal==null?String.Empty:_tituloPrincipal; }
			set { _tituloPrincipal=value; }
		}

		private string _tituloChamada1;
		public string TituloChamada1 {
			get { return _tituloChamada1==null?String.Empty:_tituloChamada1; }
			set { _tituloChamada1=value; }
		}

		private string _tituloChamada2;
		public string TituloChamada2 {
			get { return _tituloChamada2==null?String.Empty:_tituloChamada2; }
			set { _tituloChamada2=value; }
		}

		private string _tituloChamada3;
		public string TituloChamada3 {
			get { return _tituloChamada3==null?String.Empty:_tituloChamada3; }
			set { _tituloChamada3=value; }
		}

		private string _textoChamada1;
		public string TextoChamada1 {
			get { return _textoChamada1==null?String.Empty:_textoChamada1; }
			set { _textoChamada1=value; }
		}

		private string _textoChamada2;
		public string TextoChamada2 {
			get { return _textoChamada2==null?String.Empty:_textoChamada2; }
			set { _textoChamada2=value; }
		}

		private string _textoChamada3;
		public string TextoChamada3 {
			get { return _textoChamada3==null?String.Empty:_textoChamada3; }
			set { _textoChamada3=value; }
		}

		private string _link1;
		public string Link1 {
			get { return _link1==null?String.Empty:_link1; }
			set { _link1=value; }
		}

		private string _link2;
		public string Link2 {
			get { return _link2==null?String.Empty:_link2; }
			set { _link2=value; }
		}

		private string _link3;
		public string Link3 {
			get { return _link3==null?String.Empty:_link3; }
			set { _link3=value; }
		}

		private string _linkImagem;
		public string LinkImagem {
			get { return _linkImagem==null?String.Empty:_linkImagem; }
			set { _linkImagem=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ArquivoIdFoto.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoIdFoto="+ArquivoIdFoto+")");
			}

			if (!TituloPrincipal.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloPrincipal LIKE '%"+TituloPrincipal+"%')");
			}

			if (!TituloChamada1.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloChamada1 LIKE '%"+TituloChamada1+"%')");
			}

			if (!TituloChamada2.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloChamada2 LIKE '%"+TituloChamada2+"%')");
			}

			if (!TituloChamada3.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloChamada3 LIKE '%"+TituloChamada3+"%')");
			}

			if (!TextoChamada1.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoChamada1 LIKE '%"+TextoChamada1+"%')");
			}

			if (!TextoChamada2.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoChamada2 LIKE '%"+TextoChamada2+"%')");
			}

			if (!TextoChamada3.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoChamada3 LIKE '%"+TextoChamada3+"%')");
			}

			if (!Link1.Equals(String.Empty)) {
				sbWhere.Append(" AND (link1 LIKE '%"+Link1+"%')");
			}

			if (!Link2.Equals(String.Empty)) {
				sbWhere.Append(" AND (link2 LIKE '%"+Link2+"%')");
			}

			if (!Link3.Equals(String.Empty)) {
				sbWhere.Append(" AND (link3 LIKE '%"+Link3+"%')");
			}

			if (!LinkImagem.Equals(String.Empty)) {
				sbWhere.Append(" AND (linkImagem LIKE '%"+LinkImagem+"%')");
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
