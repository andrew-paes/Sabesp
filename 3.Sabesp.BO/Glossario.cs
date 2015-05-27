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
	public class Glossario 
	{
		private bool _ativo;
		private List<GlossarioIdioma> _glossarioIdiomas;
		private Conteudo _conteudo;

		public bool Ativo {
			get { return _ativo; }
			set { _ativo = value; }
		}

		public List<GlossarioIdioma> GlossarioIdiomas {
			get { return _glossarioIdiomas; }
			set { _glossarioIdiomas = value; }
		}

		[NotNullValidator]
		public Conteudo Conteudo {
			get { return _conteudo; }
			set { _conteudo = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Glossario>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Glossario>(this);
        }
	}
	
	public struct GlossarioColunas
	{	
		public static string GlossarioId = @"glossarioId";
		public static string Ativo = @"ativo";
	}
}
		