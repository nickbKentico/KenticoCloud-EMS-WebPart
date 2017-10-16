using CMS.DocumentEngine.Web.UI;
using KenticoCloudHelpers;

namespace CMSApp.CMSWebParts.DataSources
{
    public partial class KenticoCloudDataSource : CMSBaseDataSource
    {
        public string Codename { get; set; }

        public string ContentType { get; set; }

        public string[] Elements { get; set; }

        public string KenticoCloudProjectId { get; set; }

        public string OrderAttribute { get; set; }

        public string OrderDirection { get; set; }

        protected override object GetDataSourceFromDB()
        {
            if (string.IsNullOrWhiteSpace(Codename))
            {
                return DataSourceHelper.GetContentItems(KenticoCloudProjectId, ContentType, TopN, Elements, OrderAttribute, OrderDirection);
            }
            else
            {
                return DataSourceHelper.GetContentItemAsList(KenticoCloudProjectId, Codename, ContentType, Elements);
            }
        }
    }
}