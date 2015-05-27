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
	public class GlossarioIdioma 
	{
		private int _glossarioId;
		private string _palavra;
		private string _descricao;
		private Glossario _glossario;
		private Idioma _idioma;

		public int GlossarioId {
			get { return _glossarioId; }
			set { _glossarioId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Palavra {
			get { return _palavra; }
			set { _palavra = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 1073741823)]
		public string Descricao {
			get { return _descricao; }
			set { _descricao = value; }
		}

		[NotNullValidator]
		public Glossario Glossario {
			get { return _glossario; }
			set { _glossario = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<GlossarioIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<GlossarioIdioma>(this);
        }
	}
	
	public struct GlossarioIdiomaColunas
	{	
		public static string GlossarioId = @"glossarioId";
		public static string Palavra = @"palavra";
		public static string Descricao = @"descricao";
		public static string IdiomaId = @"idiomaId";
	}
}
		