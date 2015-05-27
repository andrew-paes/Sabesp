
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
	public class IdiomaFH : IFilterHelper
	{
		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _name;
		public string Name {
			get { return _name==null?String.Empty:_name; }
			set { _name=value; }
		}

		private string _active;
		public string Active {
			get { return _active==null?String.Empty:_active; }
			set { _active=value; }
		}

		private string _default;
		public string Default {
			get { return _default==null?String.Empty:_default; }
			set { _default=value; }
		}

		private string _flag;
		public string Flag {
			get { return _flag==null?String.Empty:_flag; }
			set { _flag=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!Name.Equals(String.Empty)) {
				sbWhere.Append(" AND (name LIKE '%"+Name+"%')");
			}

			if (!Active.Equals(String.Empty)) {
				sbWhere.Append(" AND (active LIKE '%"+Active+"%')");
			}

			if (!Default.Equals(String.Empty)) {
				sbWhere.Append(" AND (default LIKE '%"+Default+"%')");
			}

			if (!Flag.Equals(String.Empty)) {
				sbWhere.Append(" AND (flag LIKE '%"+Flag+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
