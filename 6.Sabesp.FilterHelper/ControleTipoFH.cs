
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
	public class ControleTipoFH : IFilterHelper
	{
		private string _controleTipoId;
		public string ControleTipoId {
			get { return _controleTipoId==null?String.Empty:_controleTipoId; }
			set { _controleTipoId=value; }
		}

		private string _nome;
		public string Nome {
			get { return _nome==null?String.Empty:_nome; }
			set { _nome=value; }
		}

		private string _hardcode;
		public string Hardcode {
			get { return _hardcode==null?String.Empty:_hardcode; }
			set { _hardcode=value; }
		}

		private string _arquivoControle;
		public string ArquivoControle {
			get { return _arquivoControle==null?String.Empty:_arquivoControle; }
			set { _arquivoControle=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ControleTipoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleTipoId="+ControleTipoId+")");
			}

			if (!Nome.Equals(String.Empty)) {
				sbWhere.Append(" AND (nome LIKE '%"+Nome+"%')");
			}

			if (!Hardcode.Equals(String.Empty)) {
				sbWhere.Append(" AND (hardcode LIKE '%"+Hardcode+"%')");
			}

			if (!ArquivoControle.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoControle LIKE '%"+ArquivoControle+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
