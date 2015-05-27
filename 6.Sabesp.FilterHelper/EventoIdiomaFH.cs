
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
	public class EventoIdiomaFH : IFilterHelper
	{
		private string _eventoId;
		public string EventoId {
			get { return _eventoId==null?String.Empty:_eventoId; }
			set { _eventoId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _nomeEvento;
		public string NomeEvento {
			get { return _nomeEvento==null?String.Empty:_nomeEvento; }
			set { _nomeEvento=value; }
		}

		private string _descricaoEvento;
		public string DescricaoEvento {
			get { return _descricaoEvento==null?String.Empty:_descricaoEvento; }
			set { _descricaoEvento=value; }
		}

		private string _chamadaEvento;
		public string ChamadaEvento {
			get { return _chamadaEvento==null?String.Empty:_chamadaEvento; }
			set { _chamadaEvento=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!EventoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (eventoId="+EventoId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!NomeEvento.Equals(String.Empty)) {
				sbWhere.Append(" AND (nomeEvento LIKE '%"+NomeEvento+"%')");
			}

			if (!DescricaoEvento.Equals(String.Empty)) {
				sbWhere.Append(" AND (descricaoEvento LIKE '%"+DescricaoEvento+"%')");
			}

			if (!ChamadaEvento.Equals(String.Empty)) {
				sbWhere.Append(" AND (chamadaEvento LIKE '%"+ChamadaEvento+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
