using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;

public partial class AutoCompleteMunicpios : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadMunicipios();
	}

	protected void LoadMunicipios()
	{
		MunicipioService municipioService = new MunicipioService();
		List<Municipio> municipios = (List<Municipio>)municipioService.RetornaTodos();

		if (municipios != null)
		{
			foreach (var mun in municipios)
			{
				if (mun.Valido)
				{
					//Response.Write(String.Concat(mun.Nome, "-", mun.MunicipioId, Environment.NewLine));
					Response.Write(String.Concat(mun.Nome, Environment.NewLine));
				}
			}
		}
	}
}
