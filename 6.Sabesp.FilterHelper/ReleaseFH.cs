
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
	public class ReleaseFH : IFilterHelper
	{
		private string _releaseId;
		public string ReleaseId {
			get { return _releaseId==null?String.Empty:_releaseId; }
			set { _releaseId=value; }
		}

        private string _idiomaId;
        public string IdiomaId
        {
            get { return _idiomaId == null ? String.Empty : _idiomaId; }
            set { _idiomaId = value; }
        }

		private string _ativa;
		public string Ativa {
			get { return _ativa==null?String.Empty:_ativa; }
			set { _ativa=value; }
		}

		private string _dataHoraPublicacaoPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraPublicacaoPeriodoInicial {
			get { return _dataHoraPublicacaoPeriodoInicial==null?String.Empty:_dataHoraPublicacaoPeriodoInicial; }
			set { _dataHoraPublicacaoPeriodoInicial=value; }
		}
		private string _dataHoraPublicacaoPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraPublicacaoPeriodoFinal {
			get { return _dataHoraPublicacaoPeriodoFinal==null?String.Empty:_dataHoraPublicacaoPeriodoFinal; }
			set { _dataHoraPublicacaoPeriodoFinal=value; }
		}

		private string _autor;
		public string Autor {
			get { return _autor==null?String.Empty:_autor; }
			set { _autor=value; }
		}

		private string _destaqueHome;
		public string DestaqueHome
		{
			get { return _destaqueHome == null ? String.Empty : _destaqueHome; }
			set { _destaqueHome = value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!ReleaseId.Equals(String.Empty)) {
				sbWhere.Append(" AND (releaseId="+ReleaseId+")");
			}

            if (!IdiomaId.Equals(String.Empty))
            {
                sbWhere.Append(" AND (idiomaId=" + IdiomaId + ")");
            }

			if (!Ativa.Equals(String.Empty)) {
				sbWhere.Append(" AND (ativa LIKE '%"+Ativa+"%')");
			}

			if( !DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) && !DataHoraPublicacaoPeriodoFinal.Equals(String.Empty)) {
				sbWhere.Append(" AND (dataHoraPublicacao >='"+DataHoraPublicacaoPeriodoInicial+"'");
				sbWhere.Append(" AND dataHoraPublicacao <='"+DataHoraPublicacaoPeriodoFinal+"')");
			} else if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraPublicacao >='"+DataHoraPublicacaoPeriodoInicial+"')");
			} else if (!DataHoraPublicacaoPeriodoFinal.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraPublicacao <='"+DataHoraPublicacaoPeriodoFinal+"')");
			}

			if (!Autor.Equals(String.Empty)) {
				sbWhere.Append(" AND (autor LIKE '%"+Autor+"%')");
			}

			if (!DestaqueHome.Equals(String.Empty))
			{
				sbWhere.Append(String.Concat(" AND (destaqueHome=", DestaqueHome, ")"));
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
