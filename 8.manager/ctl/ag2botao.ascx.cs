using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ctl_ag2Botao : System.Web.UI.UserControl
{
    public event EventHandler Click;
    private string strOnClientClick;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(OnClientClick))
        {
            tbTabela.Attributes.Add("onclick", "__doPostBack('" + this.UniqueID + "$lnkBotao','')");
        }
        else
        {
            tbTabela.Attributes.Add("onclick", OnClientClick);
        }
    }

    public string Text { get { return txtTexto.Text; } set { txtTexto.Text = value; } }
    public string OnClientClick { get { return strOnClientClick; } set { strOnClientClick = value; } }

    protected void lnkBotao_Click(object sender, EventArgs e)
    {
        if (Click != null) Click(this, e);
    }

    #region " ViewState"

    protected override void LoadViewState(object savedState)
    {
        List<object> totalState = null;
        if (savedState != null)
        {
            totalState = (List<object>)savedState;
            // Load base state.
            base.LoadViewState(totalState[0]);
            // Load extra information specific to this control.
            strOnClientClick = (string)totalState[1];

        }
    }

    protected override object SaveViewState()
    {
        List<object> totalState = new List<object>();

        totalState.Clear();
        totalState.Add(base.SaveViewState());
        totalState.Add(strOnClientClick);
        
        return totalState;
    }

    #endregion

}
