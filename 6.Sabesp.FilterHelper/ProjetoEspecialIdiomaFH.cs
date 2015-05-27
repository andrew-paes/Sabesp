
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
	public class ProjetoEspecialIdiomaFH : IFilterHelper
	{
		private string _projetoEspecialId;
		public string ProjetoEspecialId {
			get { return _projetoEspecialId==null?String.Empty:_projetoEspecialId; }
			set { _projetoEspecialId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _tituloProjeto;
		public string TituloProjeto {
			get { return _tituloProjeto==null?String.Empty:_tituloProjeto; }
			set { _tituloProjeto=value; }
		}

		private string _chamadaProjeto;
		public string ChamadaProjeto {
			get { return _chamadaProjeto==null?String.Empty:_chamadaProjeto; }
			set { _chamadaProjeto=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ProjetoEspecialId.Equals(String.Empty)) {
				sbWhere.Append(" AND (projetoEspecialId="+ProjetoEspecialId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!TituloProjeto.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloProjeto LIKE '%"+TituloProjeto+"%')");
			}

			if (!ChamadaProjeto.Equals(String.Empty)) {
				sbWhere.Append(" AND (chamadaProjeto LIKE '%"+ChamadaProjeto+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
