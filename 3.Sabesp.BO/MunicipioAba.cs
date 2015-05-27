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
	public class MunicipioAba 
	{
		// Construtor
		public MunicipioAba() {}

		// Construtor com identificador
		public MunicipioAba(int municipioAbaId) {
			_municipioAbaId = municipioAbaId;
		}
        private bool _ativo;
		private int _municipioAbaId;
		private string _tituloAba;
		private string _imagemAba;
		private string _textoAba;
		private Municipio _municipio;

        public bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }
		public int MunicipioAbaId {
			get { return _municipioAbaId; }
			set { _municipioAbaId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 256)]
		public string TituloAba {
			get { return _tituloAba; }
			set { _tituloAba = value; }
		}

		public string ImagemAba {
			get { return _imagemAba; }
			set { _imagemAba = value; }
		}

		public string TextoAba {
			get { return _textoAba; }
			set { _textoAba = value; }
		}

		[NotNullValidator]
		public Municipio Municipio {
			get { return _municipio; }
			set { _municipio = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<MunicipioAba>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<MunicipioAba>(this);
        }
	}
	
	public struct MunicipioAbaColunas
	{	
		public static string MunicipioAbaId = @"municipioAbaId";
		public static string MunicipioId = @"municipioId";
		public static string TituloAba = @"tituloAba";
		public static string ImagemAba = @"imagemAba";
		public static string TextoAba = @"textoAba";
        public static string Ativo = @"ativo";
	}
}
		