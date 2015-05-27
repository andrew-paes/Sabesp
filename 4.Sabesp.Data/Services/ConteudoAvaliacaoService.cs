using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using Sabesp.BO;

namespace Sabesp.Data.Services
{
	/// <summary>
	/// Class for Conteudo Hits Methods
	/// </summary>
	public class ConteudoAvaliacaoService
	{
		/// <summary>
		/// Interface used to get methods 
		/// </summary>
		private IConteudoAvaliacaoDAL _conteudoAvaliacaoDAL;

		/// <summary>
		/// Property to get interface
		/// </summary>
		public IConteudoAvaliacaoDAL ConteudoAvaliacaoDAL
		{
			get
			{
				if (this._conteudoAvaliacaoDAL == null)
				{
					_conteudoAvaliacaoDAL = new ConteudoAvaliacaoADO();
				}

				return _conteudoAvaliacaoDAL;
			}
			set
			{
				_conteudoAvaliacaoDAL = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public ConteudoAvaliacaoService()
		{

		}
        public ConteudoAvaliacao CarregarToSite(int conteudoId)
        {
            return ConteudoAvaliacaoDAL.CarregarToSite(conteudoId);
        }
		/// <summary>
		/// Adiciona Avaliacao Positiva
		/// </summary>
		/// <param name="conteudoId">Id do Conteudo</param>
		public int AddAvaliacaoPositivo(int conteudoId)
		{
			//load object by key
			ConteudoAvaliacao conteudoAvaliacao = this.ConteudoAvaliacaoDAL.Carregar(new ConteudoAvaliacao() { ConteudoId = conteudoId });

			// Check if exists in table
			if (conteudoAvaliacao != null && conteudoAvaliacao.ConteudoId > 0)
			{
                conteudoAvaliacao.TotalPositivo++;
				// insert
				this.ConteudoAvaliacaoDAL.Atualizar(conteudoAvaliacao);

			}
			else // else set new register
			{
				conteudoAvaliacao = new ConteudoAvaliacao();
				conteudoAvaliacao.ConteudoId = conteudoId;
                conteudoAvaliacao.TotalPositivo = 1;
				// update
				this.ConteudoAvaliacaoDAL.Inserir(conteudoAvaliacao);
			}

            return conteudoAvaliacao.TotalPositivo;
		}
        /// <summary>
        /// Adiciona Avaliacao Negativa
        /// </summary>
        /// <param name="conteudoId">Id do Conteudo</param>
        public int AddAvaliacaoNegativo(int conteudoId)
		{
			//load object by key
			ConteudoAvaliacao conteudoAvaliacao = this.ConteudoAvaliacaoDAL.Carregar(new ConteudoAvaliacao() { ConteudoId = conteudoId });

			// Check if exists in table
			if (conteudoAvaliacao != null && conteudoAvaliacao.ConteudoId > 0)
			{
                conteudoAvaliacao.TotalNegativo++;
				// insert
				this.ConteudoAvaliacaoDAL.Atualizar(conteudoAvaliacao);

			}
			else // else set new register
			{
				conteudoAvaliacao = new ConteudoAvaliacao();
				conteudoAvaliacao.ConteudoId = conteudoId;
                conteudoAvaliacao.TotalNegativo = 1;
				// update
				this.ConteudoAvaliacaoDAL.Inserir(conteudoAvaliacao);
			}

            return conteudoAvaliacao.TotalNegativo; 
		}
	}
}
