using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

/// <summary>
/// Summary description for Cookie
/// </summary>
public class Cookie
{
    #region Properties

    private HttpCookie cookie;

    private string CookieName = "SABESP";

    public List<int> Avaliados
    {
        get
        {
            
            if (this.GetValue("avaliados") != null)
            {
                List<int> aval = new List<int>();
                if (!string.IsNullOrEmpty(this.GetValue("avaliados").ToString()))
                {
                    string[] strAvaliados = this.GetValue("avaliados").Trim().Split(',');
                    foreach (string str in strAvaliados)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            aval.Add(Convert.ToInt32(str));
                        }
                    }
                }
                return aval;
            }
            else
            {
                return new List<int>();
            }
        }
    }
    public DateTime LastVisit
    {
        get
        {
            return Convert.ToDateTime(this.GetValue("lastVisit"));
        }
    }

    public Int32 RegiaoId
    {
        get
        {
            return Convert.ToInt32(this.GetValue("regiaoId"));
        }
        set
        {
            this.SetValue("regiaoId", value.ToString());
        }
    }

    public Int32 MunicipioId
    {
        get
        {
            return Convert.ToInt32(this.GetValue("municipioId"));
        }
        set
        {
            this.SetValue("municipioId", value.ToString());
        }
    }

    public Int32 IdiomaId
    {
        get
        {
            return Convert.ToInt32(this.GetValue("idiomaId"));
        }
        set
        {
            this.SetValue("idiomaId", value.ToString());
        }
    }

    public String UserId
    {
        get
        {
            return Convert.ToString(this.GetValue("userId"));
        }
    }

    #endregion


    #region Constructor

    public Cookie()
    {
        CreateCookie();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Create a cookie if not exist
    /// </summary>
    private void CreateCookie()
    {
        if (HttpContext.Current.Request.Cookies[CookieName] == null)
        {
            cookie = new HttpCookie(CookieName);
            cookie.Values["lastVisit"] = DateTime.Now.ToString();
            cookie.Values["userId"] = HttpContext.Current.Session.SessionID.ToString();
            cookie.Values["idiomaId"] = Convert.ToString(1);
            cookie.Values["avaliados"] = string.Empty;
            cookie.Expires = DateTime.Now.AddDays(20);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
    /// <summary>
    /// Adiciona conteudo avaliado ao cookies, para validar quais conteudos foram avaliados pelo usuario
    /// </summary>
    /// <param name="conteudoId"></param>
    public void AddAvaliado(int conteudoId)
    { 
        if (!this.Avaliados.Contains(conteudoId))
        {
            this.SetValue("avaliados",string.Concat(this.GetValue("avaliados"), ",", conteudoId));
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Returns a collection of a properties values registered in the cookie</returns>
    public string GetValue(string key)
    {
        CreateCookie();
        cookie = HttpContext.Current.Request.Cookies[CookieName];

        //Read a subkey value by using the .Values collection.
        NameValueCollection cookieCollection = cookie.Values;
        return cookieCollection[key];
    }

    /// <summary>
    /// Get the name of propertie and the correspondent value to set in the cookie
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetValue(string key, string value)
    {
        CreateCookie();
        cookie = HttpContext.Current.Request.Cookies[CookieName];
        cookie.Values[key] = value;

        if (!key.ToUpper().Equals("LASTVISIT"))
        {
            this.SetValue("lastVisit", DateTime.Now.ToString());
        }

        HttpContext.Current.Response.Cookies.Add(cookie);
    }

    #endregion

}