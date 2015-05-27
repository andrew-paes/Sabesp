
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
	public class SecaoIdiomaFH : IFilterHelper
	{
		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _secaoId;
		public string SecaoId {
			get { return _secaoId==null?String.Empty:_secaoId; }
			set { _secaoId=value; }
		}

		private string _titulo;
		public string Titulo {
			get { return _titulo==null?String.Empty:_titulo; }
			set { _titulo=value; }
		}

		private string _tituloMenu;
		public string TituloMenu {
			get { return _tituloMenu==null?String.Empty:_tituloMenu; }
			set { _tituloMenu=value; }
		}

		private string _ativo;
		public string Ativo {
			get { return _ativo==null?String.Empty:_ativo; }
			set { _ativo=value; }
		}

		private string _palavraChave;
		public string PalavraChave {
			get { return _palavraChave==null?String.Empty:_palavraChave; }
			set { _palavraChave=value; }
		}

		private string _texto;
		public string Texto {
			get { return _texto==null?String.Empty:_texto; }
			set { _texto=value; }
		}

		private string _tituloArquivos;
		public string TituloArquivos {
			get { return _tituloArquivos==null?String.Empty:_tituloArquivos; }
			set { _tituloArquivos=value; }
		}

		private string _textoArquivos;
		public string TextoArquivos {
			get { return _textoArquivos==null?String.Empty:_textoArquivos; }
			set { _textoArquivos=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!SecaoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (secaoId="+SecaoId+")");
			}

			if (!Titulo.Equals(String.Empty)) {
				sbWhere.Append(" AND (titulo LIKE '%"+Titulo+"%')");
			}

			if (!TituloMenu.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloMenu LIKE '%"+TituloMenu+"%')");
			}

			if (!Ativo.Equals(String.Empty)) {
				sbWhere.Append(" AND (ativo LIKE '%"+Ativo+"%')");
			}

			if (!PalavraChave.Equals(String.Empty)) {
				sbWhere.Append(" AND (palavraChave LIKE '%"+PalavraChave+"%')");
			}

			if (!Texto.Equals(String.Empty)) {
				sbWhere.Append(" AND (texto LIKE '%"+Texto+"%')");
			}

			if (!TituloArquivos.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloArquivos LIKE '%"+TituloArquivos+"%')");
			}

			if (!TextoArquivos.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoArquivos LIKE '%"+TextoArquivos+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
