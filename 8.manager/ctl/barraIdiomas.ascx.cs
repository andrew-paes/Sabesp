﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ag2.Manager.Module;
using Ag2.Collections;
using Ag2.Manager.BusinessObject;

public partial class ctl_barraIdiomas : System.Web.UI.UserControl
{
    Ag2.Manager.Helper.CurrentSessions cs = new Ag2.Manager.Helper.CurrentSessions();
    ManagerModule manager = new ManagerModule();
    Ag2.Manager.Helper.Util util = new Ag2.Manager.Helper.Util();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Ag2.Manager.Helper.ConfigurationManager.EnableMultiLanguage)
        {
            rptIdiomas.ItemDataBound += new RepeaterItemEventHandler(rptIdiomas_ItemDataBound);

            rptIdiomas.DataSource = manager.GetActiveIdiomas();
            rptIdiomas.DataBind();
        }
        else
        {
            this.Visible = false;
        }
    }

    void rptIdiomas_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Idioma idioma = (Idioma)e.Item.DataItem;
        Panel pnlFlags = (Panel)e.Item.FindControl("pnlFlags");
        ImageButton imgIdioma = (ImageButton)e.Item.FindControl("imgIdioma");

        imgIdioma.ImageUrl = idioma.Flag;
        imgIdioma.ToolTip = idioma.Name;
        imgIdioma.Attributes.Add("rel", idioma.IdiomaId.ToString());
        imgIdioma.CommandArgument = idioma.IdiomaId.ToString();

        imgIdioma.CssClass = "barraflags";

        if (util.CurrentIdioma.Equals(idioma.IdiomaId.ToString()))
        {
            pnlFlags.CssClass = "ActiveIdioma";
        }
    }

    protected void imgIdioma_Click(object sender, ImageClickEventArgs e)
    {
        ///content/edit.aspx
        string redirect = string.Empty;

        if (Request.Url.ToString().IndexOf("content/edit.aspx") > -1)
        {
            ColecaoNomeValor colQuery = new ColecaoNomeValor(Request.QueryString);

            //colQuery.QueryString());
            colQuery["lg"] = cs.CurrentIdioma.IdiomaId.ToString();

            redirect = string.Format("~/content/edit.aspx?{0}", colQuery.QueryString());
            
            Response.Redirect(redirect);
        }
    }
}
