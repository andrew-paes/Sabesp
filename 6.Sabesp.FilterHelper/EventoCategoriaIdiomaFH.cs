
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
	public class EventoCategoriaIdiomaFH : IFilterHelper
	{
		private string _eventoCategoriaId;
		public string EventoCategoriaId {
			get { return _eventoCategoriaId==null?String.Empty:_eventoCategoriaId; }
			set { _eventoCategoriaId=value; }
		}

		private string _categoriaEvento;
		public string CategoriaEvento {
			get { return _categoriaEvento==null?String.Empty:_categoriaEvento; }
			set { _categoriaEvento=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!EventoCategoriaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (eventoCategoriaId="+EventoCategoriaId+")");
			}

			if (!CategoriaEvento.Equals(String.Empty)) {
				sbWhere.Append(" AND (categoriaEvento LIKE '%"+CategoriaEvento+"%')");
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
