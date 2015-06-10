using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Natz.BOL;
using Natz.DAL;

namespace Natz.BAL
{
    public class PrtrManageBAL
    {
        public object GetData()
        {
            FileDownload oFileDownload = new FileDownload();
            PrtrManageDAL oPrtrManageDAL = new PrtrManageDAL();
            IEnumerable<FileDownload> res = oPrtrManageDAL.GetData(oFileDownload);
            return res.AsEnumerable()
                      .Select(o => new
                      {
                          FileId = o.FileId,
                          OpenDate = o.OpenDate.Value.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                          FileName = o.FileName,
                          Description = o.Description,
                          Path = o.Path,
                          Flag = o.Flag,
                      
                          PromoterCategoryId = o.PromoterCategoryId,
                          PromoterCategoryName = o.PromoterCategoryName,
                      
                          SiteGroupId = o.SiteGroupId,
                          SiteGroupIdName = o.SiteGroupName
                      });
        }
    }
}