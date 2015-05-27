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
	public class Release 
	{
		private bool _ativa;
		private DateTime _dataHoraPublicacao;
		private string _autor;
		private List<ReleaseIdioma> _releaseIdiomas;
		private List<ReleaseImagem> _releaseImagens;
		private Conteudo _conteudo;
		private bool _destaqueHome;

		public bool Ativa {
			get { return _ativa; }
			set { _ativa = value; }
		}

		[NotNullValidator]
		public DateTime DataHoraPublicacao {
			get { return _dataHoraPublicacao; }
			set { _dataHoraPublicacao = value; }
		}

		public string Autor {
			get { return _autor; }
			set { _autor = value; }
		}

		public List<ReleaseIdioma> ReleaseIdiomas {
			get { return _releaseIdiomas; }
			set { _releaseIdiomas = value; }
		}

		public List<ReleaseImagem> ReleaseImagens {
			get { return _releaseImagens; }
			set { _releaseImagens = value; }
		}

		[NotNullValidator]
		public Conteudo Conteudo {
			get { return _conteudo; }
			set { _conteudo = value; }
		}

		public bool DestaqueHome
		{
			get { return _destaqueHome; }
			set { _destaqueHome = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Release>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Release>(this);
        }
	}
	
	public struct ReleaseColunas
	{	
		public static string ReleaseId = @"releaseId";
		public static string Ativa = @"ativa";
		public static string DataHoraPublicacao = @"dataHoraPublicacao";
		public static string Autor = @"autor";
		public static string DestaqueHome = @"destaqueHome";
	}
}