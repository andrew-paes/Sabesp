using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

/// <summary>
/// Summary description for AG2
/// </summary>
namespace Ag2.Collections
{

    public class ColecaoNomeValor: NameValueCollection 
    {
        public ColecaoNomeValor(NameValueCollection col)
            : base(col)
        {
            
        }
        public string QueryString()
        {
            string strQuery = "";
            for(int i = 0; i < Count; i++){
                if(strQuery != "")strQuery += "&";
                strQuery += string.Format("{0}={1}", GetKey(i), GetValues(i)[0]);
            }
            return strQuery;
        }
    }
}