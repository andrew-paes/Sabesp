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
	public class Municipio 
	{
		// Construtor
		public Municipio() {}

		// Construtor com identificador
		public Municipio(int municipioId) {
			_municipioId = municipioId;
		}

		private int _municipioId;
		private string _nome;
		private string _imagem;
		private string _texto;
		private List<MunicipioAba> _municipioAbas;
		private List<Regiao> _regioes;

		public int MunicipioId {
			get { return _municipioId; }
			set { _municipioId = value; }
		}

		public string Nome {
			get { return _nome; }
			set { _nome = value; }
		}

		public string Imagem {
			get { return _imagem; }
			set { _imagem = value; }
		}

		public string Texto {
			get { return _texto; }
			set { _texto = value; }
		}

		public List<MunicipioAba> MunicipioAbas
		{
			get { return _municipioAbas; }
			set { _municipioAbas = value; }
		}

		public List<Regiao> Regioes
		{
			get { return _regioes; }
			set { _regioes = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Municipio>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Municipio>(this);
        }
	}
	
	public struct MunicipioColunas
	{	
		public static string MunicipioId = @"municipioId";
		public static string Nome = @"nome";
		public static string Imagem = @"imagem";
		public static string Texto = @"texto";
	}
}
		