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
	public class ConteudoHitsService
	{
		/// <summary>
		/// Interface used to get methods 
		/// </summary>
		private IConteudoHitsDAL _conteudoHitsDAL;

		/// <summary>
		/// Property to get interface
		/// </summary>
		public IConteudoHitsDAL ConteudoHitsDAL
		{
			get
			{
				if (this._conteudoHitsDAL == null)
				{
					_conteudoHitsDAL = new ConteudoHitsADO();
				}

				return _conteudoHitsDAL;
			}
			set
			{
				_conteudoHitsDAL = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public ConteudoHitsService()
		{

		}
        public ConteudoHits CarregarToSite(int conteudoId)
        {
            return ConteudoHitsDAL.CarregarToSite(conteudoId);
        }
		/// <summary>
		/// Adiciona um 
		/// </summary>
		/// <param name="conteudoId">Id do Conteudo</param>
		public void AddHits(int conteudoId)
		{
			//load object by key
			ConteudoHits conteudoHits = this.ConteudoHitsDAL.Carregar(new ConteudoHits() { ConteudoId = conteudoId });

			// Check if exists in table
			if (conteudoHits != null && conteudoHits.ConteudoId > 0)
			{
				conteudoHits.Hits++;
				// insert
				this.ConteudoHitsDAL.Atualizar(conteudoHits);

			}
			else // else set new register
			{
				conteudoHits = new ConteudoHits();
				conteudoHits.ConteudoId = conteudoId;
				conteudoHits.Hits = 1;
				// update
				this.ConteudoHitsDAL.Inserir(conteudoHits);
			}
		}
	}
}
