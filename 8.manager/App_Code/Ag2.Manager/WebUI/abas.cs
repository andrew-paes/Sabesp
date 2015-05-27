using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Reflection;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ag2.Manager.WebUI
{

    public class AbasClickEventArgs
    {
        public string strAbaId;
        public AbasClickEventArgs(string pstrAbaId) { strAbaId = pstrAbaId; }
    }
    public delegate void AbasClickEventHandler(object sender, AbasClickEventArgs e);

    [
        AspNetHostingPermission(SecurityAction.Demand,
            Level = AspNetHostingPermissionLevel.Minimal),
        AspNetHostingPermission(SecurityAction.InheritanceDemand,
            Level = AspNetHostingPermissionLevel.Minimal),
        DefaultProperty("Contacts"),
        ParseChildren(true, "Contacts"),
        ToolboxData("<{0}:QuickContacts runat=\"server\"> </{0}:QuickContacts>")
    ]
    public class Abas : WebControl, INamingContainer
    {
        public event AbasClickEventHandler Click;

        private ArrayList contactsList;
        
        private HiddenField _hddAbaSelecionada;
        private string _strIdHidden = "";

        [
        Category("Behavior"),
        Description("The contacts collection"),
        DesignerSerializationVisibility(
            DesignerSerializationVisibility.Content),
        Editor(typeof(ContactCollectionEditor), typeof(UITypeEditor)),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public ArrayList Contacts
        {
            get
            {
                if (contactsList == null)
                {
                    contactsList = new ArrayList();
                }
                return contactsList;
            }
        }

        public Abas()
        {
            
            _hddAbaSelecionada = new HiddenField();
            _hddAbaSelecionada.ID = "hddAbaSelecionada";
            _hddAbaSelecionada.Value = "";


        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (string.IsNullOrEmpty(AbaIdSelecionado)) _AbaIdSelecionado = ((AbaItem)Contacts[0]).ID ;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.RenderChildren(writer);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this.Controls.Add(_hddAbaSelecionada);
            _AbaIdSelecionado = HttpContext.Current.Request.Form[_hddAbaSelecionada.UniqueID];

            this.Controls.Add(CreateContactsTable());

            base.CreateChildControls();
            this.ChildControlsCreated = true;
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
        }

        private Table CreateContactsTable()
        {
            Table objTable = null;
            
            
            if (contactsList != null && contactsList.Count > 0)
            {
                objTable = new Table();
                objTable.CssClass = "Abas";
                objTable.CellSpacing = 0;
                objTable.Style["border-collapse"] = "separate";

                TableRow objLinha = new TableRow();

                TableCell c0 = new TableCell();
                c0.CssClass = "AbasItemPrimeiro";
                c0.Text = "&nbsp;";
                objLinha.Controls.Add(c0);

                foreach (AbaItem aContact in contactsList)
                {
                    
                    if (string.IsNullOrEmpty(AbaIdSelecionado)) _AbaIdSelecionado = aContact.ID;

                    if (aContact != null)
                    {
                        
                        TableCell c1 = new TableCell();
                        c1.CssClass = (aContact.ID == AbaIdSelecionado)?"AbasItemSelecionado":"AbasItem";
                        c1.Wrap = false;
                        LinkButton lnkAba = new LinkButton();
                        lnkAba.Click += new EventHandler(lnkAba_Click);
                        lnkAba.ID = aContact.ID;
                        lnkAba.Text = aContact.Texto;
                        lnkAba.OnClientClick = string.Format("{0}.value = '{1}';", _hddAbaSelecionada.ClientID, lnkAba.ID);

                        c1.Controls.Add(lnkAba);

                        objLinha.Controls.Add(c1);

                    }
                }
                TableCell c2 = new TableCell();
                c2.CssClass = "AbasItemUltimo";
                c2.Text = "&nbsp;";
                objLinha.Controls.Add(c2);

                objTable.Controls.Add(objLinha);
            }
            return objTable;
        }

        private string _AbaIdSelecionado = "";
        public String AbaIdSelecionado { get { return _AbaIdSelecionado; } }

        protected void lnkAba_Click(object sender, EventArgs e)
        {
            _AbaIdSelecionado = ((Control)(sender)).ID;
            if (Click != null)
                Click(this, new AbasClickEventArgs(((Control)(sender)).ID));
        }

        
        protected override void LoadViewState(object savedState)
        {
            List<object> totalState = null;
            if (savedState != null)
            {
                totalState = (List<object>)savedState;
                // Load base state.
                base.LoadViewState(totalState[0]);
                _strIdHidden = (string)totalState[1];
            }
        }

        protected override object SaveViewState()
        {
            List<object> totalState = new List<object>();

            totalState.Clear();
            totalState.Add(base.SaveViewState());
            totalState.Add(_strIdHidden);

            return totalState;
        }

    }


    [
       TypeConverter(typeof(ExpandableObjectConverter))
       ]
    public class AbaItem
    {
        private string nameValue;
        private string emailValue;
        private string phoneValue;


        public AbaItem()
            : this(String.Empty, String.Empty, String.Empty)
        {
        }

        public AbaItem(string name, string email, string phone)
        {
            nameValue = name;
            emailValue = email;
            phoneValue = phone;
        }

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("Name of contact"),
        NotifyParentProperty(true),
        ]
        public String Texto
        {
            get
            {
                return nameValue;
            }
            set
            {
                nameValue = value;
            }
        }

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("Email address of contact"),
        NotifyParentProperty(true)
        ]
        public String ID
        {
            get
            {
                return emailValue;
            }
            set
            {
                emailValue = value;
            }
        }

    }

    public class ContactCollectionEditor : CollectionEditor
    {
        public ContactCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(AbaItem);
        }
    }

}
