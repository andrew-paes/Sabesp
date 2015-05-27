using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Sabesp.Interfaces
{
	public interface IRedesSociais
	{
		#region Properties

		string Nome { get; set; }
		int Total { get; }
		string TipoConteudo { get; set; }
		string Icon { get; set; }

		#endregion

		IRedesSociais GetStatistics();
	}
}