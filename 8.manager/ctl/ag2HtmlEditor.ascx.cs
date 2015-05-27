using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FredCK.FCKeditorV2;


//System.Web.UI.WebControls.TextBox
public partial class ctl_ag2HtmlEditor : Ag2.Manager.DAL.IHtmlTextBox
{
    #region Atributos

    private string _text;
    private int _maxLength;

    #endregion

    #region Propriedates

    public override string Text
    {
        set
        {
            _text = value;
            FCKeditor1.Value = HttpUtility.HtmlDecode(_text);
        }
        get
        {
            _text = HttpUtility.HtmlEncode(FCKeditor1.Value);
            if (_text.Equals(string.Empty))
                _text = " ";
            return _text;
        }
    }

    public int MaxLength
    {
        set
        {
            _maxLength = value;
        }
    }

    #endregion

    #region Métodos

    protected void Page_Load(object sender, EventArgs e)
    {
        FCKeditor1.ToolbarSet = "Default";
        //FCKeditor1.EditorAreaCSS = "~/FCKeditor/hmv.css";
		//FCKeditor1.EditorAreaCSS = "../hmv.css";
    }
    #endregion
}
