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
	public class NoticiaTeste 
	{
		// Construtor
		public NoticiaTeste() {}

		// Construtor com identificador
		public NoticiaTeste(int noticiaTesteId) {
			_noticiaTesteId = noticiaTesteId;
		}

		private int _noticiaTesteId;
		private DateTime? _dataCadastro;
		private NoticiaTesteIdioma _noticiaTesteIdioma;
		private Workflow _workflow;

		public int NoticiaTesteId {
			get { return _noticiaTesteId; }
			set { _noticiaTesteId = value; }
		}

		public DateTime? DataCadastro {
			get { return _dataCadastro; }
			set { _dataCadastro = value; }
		}

		[NotNullValidator]
		public NoticiaTesteIdioma NoticiaTesteIdioma {
			get { return _noticiaTesteIdioma; }
			set { _noticiaTesteIdioma = value; }
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
            get { return Validation.Validate<NoticiaTeste>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<NoticiaTeste>(this);
        }
	}
	
	public struct NoticiaTesteColunas
	{	
		public static string NoticiaTesteId = @"noticiaTesteId";
		public static string DataCadastro = @"dataCadastro";
		public static string WorkflowId = @"workflowId";
	}
}
		