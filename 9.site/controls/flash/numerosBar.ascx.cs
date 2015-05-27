using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;

public partial class CtlNumerosBar : SmartUserControl, IDinamicControl
{
	#region Properties

	public int ControleId { get; set; }

	public string urlFlash { get; set; }

	public string tempoFlash { get; set; }

	#endregion

	#region Constructors

	public CtlNumerosBar() { }

	public CtlNumerosBar(int controleId)
	{
		this.ControleId = controleId;
	}

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		tempoFlash = this.CalcDifDate();
		urlFlash = ResolveUrl(String.Concat("~/contents/swf/numerosBar.swf?tempo=", tempoFlash));
	}

	public override void DataBind()
	{
		base.DataBind();
	}

	private string CalcDifDate()
	{
		int totalSecond = 0;

		TimeSpan tempoNavegacao = DateTime.Now.Subtract(Convert.ToDateTime(Session["dataAcesso"].ToString()));

		totalSecond = Convert.ToInt32(tempoNavegacao.TotalSeconds);

		return Convert.ToString(totalSecond);
	}

	#endregion
}