
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
	public class HorarioPreferenciaFH : IFilterHelper
	{
		private string _horarioPreferenciaId;
		public string HorarioPreferenciaId {
			get { return _horarioPreferenciaId==null?String.Empty:_horarioPreferenciaId; }
			set { _horarioPreferenciaId=value; }
		}

		private string _horario;
		public string Horario {
			get { return _horario==null?String.Empty:_horario; }
			set { _horario=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!HorarioPreferenciaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (horarioPreferenciaId="+HorarioPreferenciaId+")");
			}

			if (!Horario.Equals(String.Empty)) {
				sbWhere.Append(" AND (horario LIKE '%"+Horario+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
