
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
	public class ModeloFH : IFilterHelper
	{
		private string _modeloId;
		public string ModeloId {
			get { return _modeloId==null?String.Empty:_modeloId; }
			set { _modeloId=value; }
		}

		private string _nome;
		public string Nome {
			get { return _nome==null?String.Empty:_nome; }
			set { _nome=value; }
		}

		private string _arquivo;
		public string Arquivo {
			get { return _arquivo==null?String.Empty:_arquivo; }
			set { _arquivo=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ModeloId.Equals(String.Empty)) {
				sbWhere.Append(" AND (modeloId="+ModeloId+")");
			}

			if (!Nome.Equals(String.Empty)) {
				sbWhere.Append(" AND (nome LIKE '%"+Nome+"%')");
			}

			if (!Arquivo.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivo LIKE '%"+Arquivo+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
