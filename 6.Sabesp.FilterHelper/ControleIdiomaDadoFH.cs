
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
	public class ControleIdiomaDadoFH : IFilterHelper
	{
		private string _controleIdiomaDadoId;
		public string ControleIdiomaDadoId {
			get { return _controleIdiomaDadoId==null?String.Empty:_controleIdiomaDadoId; }
			set { _controleIdiomaDadoId=value; }
		}

		private string _controleIdiomaId;
		public string ControleIdiomaId {
			get { return _controleIdiomaId==null?String.Empty:_controleIdiomaId; }
			set { _controleIdiomaId=value; }
		}

		private string _subtitulo;
		public string Subtitulo {
			get { return _subtitulo==null?String.Empty:_subtitulo; }
			set { _subtitulo=value; }
		}

		private string _link;
		public string Link {
			get { return _link==null?String.Empty:_link; }
			set { _link=value; }
		}

		private string _target;
		public string Target {
			get { return _target==null?String.Empty:_target; }
			set { _target=value; }
		}

		private string _imagemNome;
		public string ImagemNome {
			get { return _imagemNome==null?String.Empty:_imagemNome; }
			set { _imagemNome=value; }
		}

		private string _imagemTexto;
		public string ImagemTexto {
			get { return _imagemTexto==null?String.Empty:_imagemTexto; }
			set { _imagemTexto=value; }
		}

		private string _textoChamada;
		public string TextoChamada {
			get { return _textoChamada==null?String.Empty:_textoChamada; }
			set { _textoChamada=value; }
		}

		private string _arquivoNome;
		public string ArquivoNome {
			get { return _arquivoNome==null?String.Empty:_arquivoNome; }
			set { _arquivoNome=value; }
		}

		private string _arquivoTamanho;
		public string ArquivoTamanho {
			get { return _arquivoTamanho==null?String.Empty:_arquivoTamanho; }
			set { _arquivoTamanho=value; }
		}

		private string _arquivoExtensao;
		public string ArquivoExtensao {
			get { return _arquivoExtensao==null?String.Empty:_arquivoExtensao; }
			set { _arquivoExtensao=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ControleIdiomaDadoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleIdiomaDadoId="+ControleIdiomaDadoId+")");
			}

			if (!ControleIdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleIdiomaId="+ControleIdiomaId+")");
			}

			if (!Subtitulo.Equals(String.Empty)) {
				sbWhere.Append(" AND (subtitulo LIKE '%"+Subtitulo+"%')");
			}

			if (!Link.Equals(String.Empty)) {
				sbWhere.Append(" AND (link LIKE '%"+Link+"%')");
			}

			if (!Target.Equals(String.Empty)) {
				sbWhere.Append(" AND (target LIKE '%"+Target+"%')");
			}

			if (!ImagemNome.Equals(String.Empty)) {
				sbWhere.Append(" AND (imagemNome LIKE '%"+ImagemNome+"%')");
			}

			if (!ImagemTexto.Equals(String.Empty)) {
				sbWhere.Append(" AND (imagemTexto LIKE '%"+ImagemTexto+"%')");
			}

			if (!TextoChamada.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoChamada LIKE '%"+TextoChamada+"%')");
			}

			if (!ArquivoNome.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoNome LIKE '%"+ArquivoNome+"%')");
			}

			if (!ArquivoTamanho.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoTamanho="+ArquivoTamanho+")");
			}

			if (!ArquivoExtensao.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoExtensao="+ArquivoExtensao+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
