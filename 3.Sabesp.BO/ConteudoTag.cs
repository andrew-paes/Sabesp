/*
'===============================================================================
'
'  Template: Gerador C�digo C#.csgen
'  Script vers�o: 0.93
'  Script criado por: Leonardo Alves Lindermann (lindermannla@ag2.com.br)
'  Gerado pelo MyGeneration vers�o # (???)
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
    public class ConteudoTag
    {
        private Tag _tag;
        private Conteudo _conteudo;

        [NotNullValidator]
        public Tag Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        [NotNullValidator]
        public Conteudo Conteudo
        {
            get { return _conteudo; }
            set { _conteudo = value; }
        }

        /// <summary>
        /// Propriedade que informa se a entidade � v�lida para persist�ncia.
        /// </summary>
        /// <returns>booleano informando se � a entidade � v�lida ou n�o.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ConteudoTag>(this).IsValid; }
        }

        /// <summary>
        /// M�todo que valida e retorna os dados de valida��o da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informa��es da valida��o.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ConteudoTag>(this);
        }
    }

    public struct ConteudoTagColunas
    {
        public static string TagId = @"tagId";
        public static string ConteudoId = @"conteudoId";
    }
}
