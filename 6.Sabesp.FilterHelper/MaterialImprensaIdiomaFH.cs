
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
	public class MaterialImprensaIdiomaFH : IFilterHelper
	{
		private string _materialImprensaId;
		public string MaterialImprensaId {
			get { return _materialImprensaId==null?String.Empty:_materialImprensaId; }
			set { _materialImprensaId=value; }
		}

		private string _idiomaId;
		public string IdiomaId {
			get { return _idiomaId==null?String.Empty:_idiomaId; }
			set { _idiomaId=value; }
		}

		private string _arquivoId;
		public string ArquivoId {
			get { return _arquivoId==null?String.Empty:_arquivoId; }
			set { _arquivoId=value; }
		}

		private string _tituloMaterial;
		public string TituloMaterial {
			get { return _tituloMaterial==null?String.Empty:_tituloMaterial; }
			set { _tituloMaterial=value; }
		}

		private string _textoMaterial;
		public string TextoMaterial {
			get { return _textoMaterial==null?String.Empty:_textoMaterial; }
			set { _textoMaterial=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!MaterialImprensaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (materialImprensaId="+MaterialImprensaId+")");
			}

			if (!IdiomaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (idiomaId="+IdiomaId+")");
			}

			if (!ArquivoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (arquivoId="+ArquivoId+")");
			}

			if (!TituloMaterial.Equals(String.Empty)) {
				sbWhere.Append(" AND (tituloMaterial LIKE '%"+TituloMaterial+"%')");
			}

			if (!TextoMaterial.Equals(String.Empty)) {
				sbWhere.Append(" AND (textoMaterial LIKE '%"+TextoMaterial+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
