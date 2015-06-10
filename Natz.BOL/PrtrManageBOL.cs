using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Natz.BOL
{
    [Database(Name = "PRTR")]
    public class PrtrDataContext : DataContext
    {
        public PrtrDataContext() : base(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString()) { }
        public PrtrDataContext(string connectionString) : base(connectionString) { }

        public Table<Company> Companys;
        public Table<FileDownload> FileDownloads;
        public Table<PromoterCategory> PromoterCategorys;
        public Table<SiteGroup> SiteGroups;
    }

    [Table(Name = "dbo.Company")]
    public partial class Company
    {
        //Entity
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int CompanyId { get; set; }
        [Column]
        public string CompanyName { get; set; }
        [Column]
        public string Flag { get; set; }
    }

    [Table(Name = "dbo.FileDownload")]
    public partial class FileDownload
    {
        //Entity
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int FileId { get; set; }
        [Column]
        public int PromoterCategoryId { get; set; }
        [Column]
        public int? SiteGroupId { get; set; }
        [Column]
        public DateTime? OpenDate { get; set; }
        [Column]
        public string FileName { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public string Path { get; set; }
        [Column]
        public string Flag { get; set; }

        //EntityRef
        private EntityRef<PromoterCategory> _PromoterCategory = new EntityRef<PromoterCategory>();
        [Association(Name = "FK_FileDownload_PromoterCategory", IsForeignKey = true, Storage = "_PromoterCategory", OtherKey = "PromoterCategoryId", ThisKey = "PromoterCategoryId")]
        public PromoterCategory PromoterCategory
        {
            get { return _PromoterCategory.Entity; }
            set { _PromoterCategory.Entity = value; }
        }

        private EntityRef<SiteGroup> _SiteGroup = new EntityRef<SiteGroup>();
        [Association(Name = "FK_FileDownload_SiteGroup", IsForeignKey = true, Storage = "_SiteGroup", OtherKey = "SiteGroupId", ThisKey = "SiteGroupId")]
        public SiteGroup SiteGroup
        {
            get { return _SiteGroup.Entity; }
            set { _SiteGroup.Entity = value; }
        }

        //EntityRef Column
        public string PromoterCategoryName { get; set; }
        public string SiteGroupName { get; set; }
    }

    [Table(Name = "dbo.PromoterCategory")]
    public partial class PromoterCategory
    {
        //Entity
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int PromoterCategoryId { get; set; }
        [Column]
        public int CompanyId { get; set; }
        [Column]
        public string PromoterCategoryName { get; set; }
        [Column]
        public string Flag { get; set; }

        //EntityRef
        private EntityRef<Company> _Company = new EntityRef<Company>();
        [Association(Name = "FK_FileDownload_Company", IsForeignKey = true, Storage = "_Company", OtherKey = "CompanyId", ThisKey = "CompanyId")]
        public Company Company
        {
            get { return _Company.Entity; }
            set { _Company.Entity = value; }
        }
    }

    [Table(Name = "dbo.SiteGroup")]
    public partial class SiteGroup
    {
        //Entity
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int SiteGroupId { get; set; }
        [Column]
        public string SiteGroupName { get; set; }
        [Column]
        public string Flag { get; set; }
    }
}
