
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
	public class ArquivoFH : IFilterHelper
	{
		private string _arquivoId;
		public string ArquivoId {
			get { return _arquivoId==null?String.Empty:_arquivoId; }
			set { _arquivoId=value; }
		}

		private string _nomeArquivo;
		public string NomeArquivo {
			get { return _nomeArquivo==null?String.Empty:_nomeArquivo; }
			set { _nomeArquivo=value; }
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

			if (!ArquivoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoId="+ArquivoId+")");
			}

			if (!NomeArquivo.Equals(String.Empty)) {
				sbWhere.Append(" AND (nomeArquivo LIKE '%"+NomeArquivo+"%')");
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
