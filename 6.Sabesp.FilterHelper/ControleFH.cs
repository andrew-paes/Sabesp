
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
	public class ControleFH : IFilterHelper
	{
		private string _controleId;
		public string ControleId {
			get { return _controleId==null?String.Empty:_controleId; }
			set { _controleId=value; }
		}

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

		private string _ativo;
		public string Ativo {
			get { return _ativo==null?String.Empty:_ativo; }
			set { _ativo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ControleId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleId="+ControleId+")");
			}

			if (!ControleTipoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (controleTipoId="+ControleTipoId+")");
			}

			if (!Nome.Equals(String.Empty)) {
				sbWhere.Append(" AND (nome LIKE '%"+Nome+"%')");
			}

			if (!Ativo.Equals(String.Empty)) {
				sbWhere.Append(" AND (ativo LIKE '%"+Ativo+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
