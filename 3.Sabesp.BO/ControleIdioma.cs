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
	public class ControleIdioma 
	{
		// Construtor
		public ControleIdioma() {}

		// Construtor com identificador
		public ControleIdioma(int controleIdiomaId) {
			_controleIdiomaId = controleIdiomaId;
		}

		private int _controleIdiomaId;
		private string _titulo;
		private List<ControleIdiomaDado> _controleIdiomaDados;
		private Controle _controle;
		private Idioma _idioma;
		private Workflow _workflow;

		public int ControleIdiomaId {
			get { return _controleIdiomaId; }
			set { _controleIdiomaId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 256)]
		public string Titulo {
			get { return _titulo; }
			set { _titulo = value; }
		}

		public List<ControleIdiomaDado> ControleIdiomaDados {
			get { return _controleIdiomaDados; }
			set { _controleIdiomaDados = value; }
		}

		public Controle Controle {
			get { return _controle; }
			set { _controle = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		public Workflow Workflow {
			get { return _workflow; }
			set { _workflow = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ControleIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ControleIdioma>(this);
        }
	}
	
	public struct ControleIdiomaColunas
	{	
		public static string ControleIdiomaId = @"controleIdiomaId";
		public static string ControleId = @"controleId";
		public static string IdiomaId = @"idiomaId";
		public static string WorkflowId = @"workflowId";
		public static string Titulo = @"titulo";
	}
}
		