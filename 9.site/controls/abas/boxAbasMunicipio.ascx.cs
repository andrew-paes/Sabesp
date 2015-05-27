using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using System.Web.UI.HtmlControls;
using AG2.Sabesp.HotWords;
using Sabesp.FilterHelper;

public partial class controls_abas_boxAbasMunicipio : SmartUserControl
{

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public override void DataBind()
	{
		base.DataBind();

		List<MunicipioAba> municipioAba = this.GetMunicipioAba(RegistroId);

		if (municipioAba != null && municipioAba.Count > 0)
		{
			rptAbas.DataSource = municipioAba;
			rptAbas.DataBind();

			rptTituloAbas.DataSource = municipioAba;
			rptTituloAbas.DataBind();
		}
		else
		{
			this.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="secaoid"></param>
	/// <returns></returns>
	protected List<MunicipioAba> GetMunicipioAba(int municipioId)
	{
		List<MunicipioAba> municipioAbaList = new List<MunicipioAba>();
		IList<MunicipioAba> municipioAbaIList = new List<MunicipioAba>();
		MunicipioAbaFH municipioAbaFH = new MunicipioAbaFH();
		municipioAbaFH.MunicipioId = municipioId.ToString();
        municipioAbaFH.Ativo = "1";
		municipioAbaIList = new MunicipioAbaService().RetornaTodos(0, 0, "", "", municipioAbaFH);

		if (municipioAbaIList != null && municipioAbaIList.Count > 0)
		{
			foreach (MunicipioAba municipioAbaBOTemp in municipioAbaIList)
			{
				municipioAbaList.Add(municipioAbaBOTemp);
			}
		}

		return municipioAbaList;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptTituloAbas_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var liTitulo = (HtmlGenericControl)e.Item.FindControl("liTitulo");
			var ltrAba = (Literal)e.Item.FindControl("ltrAba");

			MunicipioAba municipioAba = (MunicipioAba)e.Item.DataItem;
			ltrAba.Text = String.Concat("<strong><a href=\"", "#", ((Panel)rptAbas.Items[e.Item.ItemIndex].FindControl("pnlAba")).ClientID, "\">", municipioAba.TituloAba, "</a><span><!-- --></span></strong>");

			if (e.Item.ItemIndex == 0)
			{
				liTitulo.Attributes.Add("class", "on");
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptAbas_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var ltrTexto = (Literal)e.Item.FindControl("ltrTexto");
			var pnlAba = (Panel)e.Item.FindControl("pnlAba");
			var pnlDivAba = (Panel)e.Item.FindControl("pnlDivAba");

			MunicipioAba municipioAba = (MunicipioAba)e.Item.DataItem;
			ltrTexto.Text = WordsInjector.Hotword(municipioAba.TextoAba).ReplaceHtml();

			if (e.Item.ItemIndex == 0)
			{
				pnlAba.CssClass = String.Concat(pnlAba.CssClass, " ", "on");
			}
			int height = this.GetHeigthDivAba();
			pnlDivAba.Attributes.Add("style", String.Concat("min-height:", height, "px; _height:", height, "px;"));
		}
	}

	private int GetHeigthDivAba()
	{
		List<MunicipioAba> abas = (List<MunicipioAba>)rptAbas.DataSource;

		return (abas.Count * 47) - 11;
	}
}
