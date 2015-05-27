using System.Collections.Generic;
using Sabesp.Interfaces;

namespace RedesSociais
{
    /// <summary>
    /// Summary description for Control
    /// </summary>
    public class Control
    {
        public Control() { }

        public List<IRedesSociais> GetStatistics()
        {
            List<IRedesSociais> listResults = new List<IRedesSociais>();
            IRedesSociais result = null;

            RedesSociais.YouTube youTube = new RedesSociais.YouTube();

            result = youTube.GetStatistics();
            if (result != null)
            {
                listResults.Add(result);
            }

            return null;
        }
    }
}