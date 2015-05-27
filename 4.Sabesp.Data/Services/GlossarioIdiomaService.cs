using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.Data.Services
{
	/// <summary>
	/// Class for Conteudo Hits Methods
	/// </summary>
	public class GlossarioIdiomaService
	{
		/// <summary>
		/// Interface used to get methods 
		/// </summary>
		private IGlossarioIdiomaDAL _glossarioIdiomaDAL;

		/// <summary>
		/// Property to get interface
		/// </summary>
		public IGlossarioIdiomaDAL GlossarioIdiomaDAL
		{
			get
			{
				if (this._glossarioIdiomaDAL == null)
				{
					_glossarioIdiomaDAL = new GlossarioIdiomaADO();
				}

				return _glossarioIdiomaDAL;
			}
			set
			{
				_glossarioIdiomaDAL = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public GlossarioIdiomaService()
		{

		}
        public IList<GlossarioIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return GlossarioIdiomaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }
	}
}
