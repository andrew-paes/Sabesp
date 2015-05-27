using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;

public partial class CtlguiaEducacao : SmartUserControl, IDinamicControl
{
	#region Properties

	public int ControleId { get; set; }

	#endregion

	#region Constructors

	public CtlguiaEducacao() { }

	public CtlguiaEducacao(int controleId)
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

	#endregion
}