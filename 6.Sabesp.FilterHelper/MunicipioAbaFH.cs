
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
	public class MunicipioAbaFH : IFilterHelper
	{
		private string _municipioAbaId;
		public string MunicipioAbaId {
			get { return _municipioAbaId==null?String.Empty:_municipioAbaId; }
			set { _municipioAbaId=value; }
		}

		private string _municipioId;
		public string MunicipioId {
			get { return _municipioId==null?String.Empty:_municipioId; }
			set { _municipioId=value; }
		}

		private string _tituloAba;
		public string TituloAba {
			get { return _tituloAba==null?String.Empty:_tituloAba; }
			set { _tituloAba=value; }
		}

		private string _imagemAba;
		public string ImagemAba {
			get { return _imagemAba==null?String.Empty:_imagemAba; }
			set { _imagemAba=value; }
		}

		private string _textoAba;
		public string TextoAba {
			get { return _textoAba==null?String.Empty:_textoAba; }
			set { _textoAba=value; }
		}

        private string _ativo;
        public string Ativo
        {
            get { return _ativo == null ? String.Empty : _ativo; }
            set { _ativo = value; }
        }
	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!MunicipioAbaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (municipioAbaId="+MunicipioAbaId+")");
			}

			if (!MunicipioId.Equals(String.Empty)) {
				sbWhere.Append(" AND (municipioId="+MunicipioId+")");
			}

			if (!TituloAba.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloAba LIKE '%"+TituloAba+"%')");
			}

			if (!ImagemAba.Equals(String.Empty)) {
				sbWhere.Append(" AND (imagemAba LIKE '%"+ImagemAba+"%')");
			}

            if (!Ativo.Equals(String.Empty))
            {
                sbWhere.Append(" AND (ativo LIKE '%" + Ativo + "%')");
            }

			if (!TextoAba.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoAba LIKE '%"+TextoAba+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
