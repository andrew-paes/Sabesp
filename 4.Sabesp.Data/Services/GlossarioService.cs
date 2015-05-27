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
	public class GlossarioService
	{
		/// <summary>
		/// Interface used to get methods 
		/// </summary>
		private IGlossarioDAL _glossarioDAL;

		/// <summary>
		/// Property to get interface
		/// </summary>
		public IGlossarioDAL GlossarioDAL
		{
			get
			{
				if (this._glossarioDAL == null)
				{
					_glossarioDAL = new GlossarioADO();
				}

				return _glossarioDAL;
			}
			set
			{
				_glossarioDAL = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public GlossarioService()
		{

		}
        public IList<Glossario> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            return GlossarioDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }
	}
}
