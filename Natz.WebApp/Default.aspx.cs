using System;
using System.Web.Services;
using Natz.BAL;

namespace Natz.WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object GetData()
        {
            PrtrManageBAL oPrtrManageBAL = new PrtrManageBAL();
            return oPrtrManageBAL.GetData();
        }
    }
}