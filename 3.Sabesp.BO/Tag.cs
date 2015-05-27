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
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sabesp.BO
{	
	
	[Serializable]
	public class Tag 
	{
		// Construtor
		public Tag() {}

		// Construtor com identificador
		public Tag(int tagId) {
			_tagId = tagId;
		}

		private int _tagId;
		private string _palavra;
		private int _hits;
		private List<Conteudo> _conteudos;
		private Idioma _idioma;

		public int TagId {
			get { return _tagId; }
			set { _tagId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Palavra {
			get { return _palavra; }
			set { _palavra = value; }
		}

		public int Hits {
			get { return _hits; }
			set { _hits = value; }
		}

		public List<Conteudo> Conteudos {
			get { return _conteudos; }
			set { _conteudos = value; }
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
            get { return Validation.Validate<Tag>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Tag>(this);
        }
	}
	
	public struct TagColunas
	{	
		public static string TagId = @"tagId";
		public static string Palavra = @"palavra";
		public static string Hits = @"hits";
		public static string IdiomaId = @"idiomaId";
	}
}
		