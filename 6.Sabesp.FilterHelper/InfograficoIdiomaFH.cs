
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
	public class InfograficoIdiomaFH : IFilterHelper
	{
		private string _infograficoId;
		public string InfograficoId {
			get { return _infograficoId==null?String.Empty:_infograficoId; }
			set { _infograficoId=value; }
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

		private string _descricao;
		public string Descricao {
			get { return _descricao==null?String.Empty:_descricao; }
			set { _descricao=value; }
		}

		private string _arquivoIdAnimacao;
		public string ArquivoIdAnimacao {
			get { return _arquivoIdAnimacao==null?String.Empty:_arquivoIdAnimacao; }
			set { _arquivoIdAnimacao=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!InfograficoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (infograficoId="+InfograficoId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (IdiomaId="+IdiomaId+")");
			}

			if (!Titulo.Equals(String.Empty)) {
				sbWhere.Append(" AND (titulo LIKE '%"+Titulo+"%')");
			}

			if (!Descricao.Equals(String.Empty)) {
				sbWhere.Append(" AND (descricao LIKE '%"+Descricao+"%')");
			}

			if (!ArquivoIdAnimacao.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoIdAnimacao="+ArquivoIdAnimacao+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
