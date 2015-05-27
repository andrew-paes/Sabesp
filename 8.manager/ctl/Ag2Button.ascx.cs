using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ctl_Ag2Button : System.Web.UI.UserControl
{
    public event EventHandler Click;
    private Dictionary<string, string> _attributes = new Dictionary<string, string>();
    private string _text = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnAcao.Click += new EventHandler(btnAcao_Click);

        foreach (KeyValuePair<string, string> item in _attributes)
        {
            btnAcao.Attributes.Add(item.Key, item.Value);
        }

        Panel pnlContent = new Panel();
        Panel pnlLeft = new Panel();
        Panel pnlCenter = new Panel();
        Panel pnlRigth = new Panel();

        pnlContent.Attributes.Add("style", "border: 0px solid #ccc; float: left;");
        pnlLeft.Attributes.Add("style", "border: 0px solid red; background-image: url(../img/btnLeftBorder.gif);width: 23px; height: 22px; float: left;");
        pnlCenter.Attributes.Add("style", "border: 0px solid blue; float: left; background-image: url(../img/btnBgCenter.gif);background-repeat: repeat-x; height: 22px; padding-top: 3px;");
        pnlCenter.Controls.Add(new LiteralControl(_text));
        pnlRigth.Attributes.Add("style", "border: 0px solid black; background-image: url(../img/btnRightBorder.gif);width: 10px; height: 22px; float: left;");

        pnlContent.Controls.Add(pnlLeft);
        pnlContent.Controls.Add(pnlCenter);
        pnlContent.Controls.Add(pnlRigth);

        btnAcao.Controls.Add(pnlContent);
    }

    void btnAcao_Click(object sender, EventArgs e)
    {
        if (Click != null)
        {
            Click(sender, e);
        }
    }

    public string Text
    {
        get { return _text; }
        set { _text = value; }
    }

    public Dictionary<string, string> Attributes
    {
        get { return _attributes; }
        set { _attributes = value; }
    }

}
