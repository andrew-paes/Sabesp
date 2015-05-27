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
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Sabesp.BO
{	
	
	[Serializable]
	public class MaterialImprensaIdioma 
	{
		private string _tituloMaterial;
		private string _textoMaterial;
		private Arquivo _arquivo;
		private Idioma _idioma;
		private MaterialImprensa _materialImprensa;

		public string TituloMaterial {
			get { return _tituloMaterial; }
			set { _tituloMaterial = value; }
		}

		public string TextoMaterial {
			get { return _textoMaterial; }
			set { _textoMaterial = value; }
		}

		[NotNullValidator]
		public Arquivo Arquivo {
			get { return _arquivo; }
			set { _arquivo = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public MaterialImprensa MaterialImprensa {
			get { return _materialImprensa; }
			set { _materialImprensa = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<MaterialImprensaIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<MaterialImprensaIdioma>(this);
        }
	}
	
	public struct MaterialImprensaIdiomaColunas
	{	
		public static string MaterialImprensaId = @"materialImprensaId";
		public static string IdiomaId = @"idiomaId";
		public static string ArquivoId = @"arquivoId";
		public static string TituloMaterial = @"tituloMaterial";
		public static string TextoMaterial = @"textoMaterial";
	}
}
		