using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using Sabesp.Enumerators;

public partial class CltSuaRegiao : SmartUserControl, IDinamicControl
{
	#region Properties

	public int ControleId { get; set; }

	#endregion

	#region Constructors

	public CltSuaRegiao() { }

	public CltSuaRegiao(int controleId)
	{
		this.ControleId = controleId;
	}

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public override void DataBind()
	{
		base.DataBind();

		//code goes here
	}

	protected void imgBtnIr_Click(object sender, ImageClickEventArgs e)
	{
		int municipioId = 0;
		if (!String.IsNullOrEmpty(txtMunicipio.Text.Trim()))
		{
			MunicipioService municipioService = new MunicipioService();

			municipioId = municipioService.BuscarMunicipioId(txtMunicipio.Text.Trim());
		}

		if (municipioId > 0)
		{
			Response.Redirect(String.Concat("~/interna/Municipio.aspx?secaoId=", MenuPrincipal.Municipio.GetHashCode(), "&id=", municipioId));
		}
	}

	#endregion

}
