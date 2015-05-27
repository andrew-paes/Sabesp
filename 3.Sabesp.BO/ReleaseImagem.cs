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
	public class ReleaseImagem 
	{
		// Construtor
		public ReleaseImagem() {}

		// Construtor com identificador
		public ReleaseImagem(int releaseImagemID) {
			_releaseImagemID = releaseImagemID;
		}

		private int _releaseImagemID;
		private int _ordem;
		private List<ReleaseImagemComentario> _releaseImagemComentarios;
		private Arquivo _arquivo;
		private Release _release;

		public int ReleaseImagemID {
			get { return _releaseImagemID; }
			set { _releaseImagemID = value; }
		}

		public int Ordem {
			get { return _ordem; }
			set { _ordem = value; }
		}

		public List<ReleaseImagemComentario> ReleaseImagemComentarios {
			get { return _releaseImagemComentarios; }
			set { _releaseImagemComentarios = value; }
		}

		[NotNullValidator]
		public Arquivo Arquivo {
			get { return _arquivo; }
			set { _arquivo = value; }
		}

		[NotNullValidator]
		public Release Release {
			get { return _release; }
			set { _release = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ReleaseImagem>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ReleaseImagem>(this);
        }
	}
	
	public struct ReleaseImagemColunas
	{	
		public static string ReleaseImagemID = @"releaseImagemID";
		public static string ArquivoId = @"arquivoId";
		public static string Ordem = @"ordem";
		public static string ReleaseId = @"releaseId";
	}
}
		