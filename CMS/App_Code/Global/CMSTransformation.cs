using KenticoCloudHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DocumentEngine.Web.UI
{
    public partial class CMSTransformation
    {
        public string GetContentItemAssetDescription(object contentItemObject, string elementCodeName, int assetIndex = 0)
        {
            return ContentItemHelper.GetAssetDescription(contentItemObject, elementCodeName, assetIndex);
        }

        public string GetContentItemAssetName(object contentItemObject, string elementCodeName, int assetIndex = 0)
        {
            return ContentItemHelper.GetAssetName(contentItemObject, elementCodeName, assetIndex);
        }

        public string GetContentItemAssetUrl(object contentItemObject, string elementCodeName, int assetIndex = 0)
        {
            return ContentItemHelper.GetAssetUrl(contentItemObject, elementCodeName, assetIndex);
        }

        public string GetContentItemCodename(object contentItemObject)
        {
            return ContentItemHelper.GetCodename(contentItemObject);
        }

        public DateTime? GetContentItemDateTimeValue(object contentItemObject, string elementCodeName)
        {
            return ContentItemHelper.GetDateTime(contentItemObject, elementCodeName);
        }
        
        public decimal? GetContentItemNumberValue(object contentItemObject, string elementCodeName)
        {
            return ContentItemHelper.GetNumber(contentItemObject, elementCodeName);
        }

        public string GetContentItemStringValue(object contentItemObject, string elementCodeName)
        {
            return ContentItemHelper.GetString(contentItemObject, elementCodeName);
        }
    }
}
