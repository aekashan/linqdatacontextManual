using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Natz.BOL;

namespace Natz.DAL
{
    public class PrtrManageDAL
    {
        PrtrDataContext context = new PrtrDataContext(@"Data Source=PROGRAMMER27\SQLEXPRESS;Initial Catalog=PRTR;User ID=sa;Password=test1234;");

        public IEnumerable<FileDownload> GetData(FileDownload obj)
        {
            return context.FileDownloads
                          .Where(o => o.FileId == 111)
                          .AsEnumerable()
                          .Select(o => new FileDownload
                          {
                              FileId = o.FileId,
                              OpenDate = o.OpenDate,
                              FileName = o.FileName,
                              Description = o.Description,
                              Path = o.Path,
                              Flag = o.Flag,

                              PromoterCategoryId = o.PromoterCategory.PromoterCategoryId,
                              PromoterCategoryName = o.PromoterCategory.PromoterCategoryName,

                              SiteGroupId = o.SiteGroup.SiteGroupId,
                              SiteGroupName = o.SiteGroup.SiteGroupName
                          });
        }
    }
}
