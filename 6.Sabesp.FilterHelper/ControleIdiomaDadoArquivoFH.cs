
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
	public class ControleIdiomaDadoArquivoFH : IFilterHelper
	{
		private string _controleIdiomaDadoArquivoId;
		public string ControleIdiomaDadoArquivoId {
			get { return _controleIdiomaDadoArquivoId==null?String.Empty:_controleIdiomaDadoArquivoId; }
			set { _controleIdiomaDadoArquivoId=value; }
		}

		private string _controleIdiomaDadoId;
		public string ControleIdiomaDadoId {
			get { return _controleIdiomaDadoId==null?String.Empty:_controleIdiomaDadoId; }
			set { _controleIdiomaDadoId=value; }
		}

		private string _nome;
		public string Nome {
			get { return _nome==null?String.Empty:_nome; }
			set { _nome=value; }
		}

		private string _tamanho;
		public string Tamanho {
			get { return _tamanho==null?String.Empty:_tamanho; }
			set { _tamanho=value; }
		}

		private string _extensao;
		public string Extensao {
			get { return _extensao==null?String.Empty:_extensao; }
			set { _extensao=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ControleIdiomaDadoArquivoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleIdiomaDadoArquivoId="+ControleIdiomaDadoArquivoId+")");
			}

			if (!ControleIdiomaDadoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleIdiomaDadoId="+ControleIdiomaDadoId+")");
			}

			if (!Nome.Equals(String.Empty)) {
				sbWhere.Append(" AND (nome LIKE '%"+Nome+"%')");
			}

			if (!Tamanho.Equals(String.Empty)) {
				sbWhere.Append(" AND (tamanho="+Tamanho+")");
			}

			if (!Extensao.Equals(String.Empty)) {
				sbWhere.Append(" AND (extensao LIKE '%"+Extensao+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
