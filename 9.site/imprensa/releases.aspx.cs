using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;

public partial class imprensa : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
		body.Attributes.Add("class", "interna");
        //this.BindUltimosReleases();
    }
    //protected void BindUltimosReleases()
    //{
    //    ReleaseService releaseService = new ReleaseService();
    //    string[] dataExibicaoInicio = { "dataHoraPublicacao" };
    //    string[] orderBy = { "ASC" };

    //    List<Release> releases = (List<Release>)releaseService.CarregarTodos(0, 0, dataExibicaoInicio, orderBy, new ReleaseFH());

    //    if (releases != null && releases.Count > 0)
    //    {
    //        this.imprensaUltimosReleases.Releases = releases;
    //        this.imprensaUltimosReleases.DataBind();
    //    }
    //    else
    //    {
    //        this.imprensaUltimosReleases.Visible = false;
    //    }
    //}
}