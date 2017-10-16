using KenticoCloud.Delivery;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace KenticoCloudHelpers
{
    public static class ContentItemHelper
    {
        public static string GetAssetDescription(object contentItemObject, string elementCodename, int assetIndex = 0)
        {
            var asset = GetAsset(contentItemObject, elementCodename, assetIndex);
            return asset?.Description;
        }

        public static string GetAssetName(object contentItemObject, string elementCodename, int assetIndex = 0)
        {
            var asset = GetAsset(contentItemObject, elementCodename, assetIndex);
            return asset?.Name;
        }

        public static string GetAssetUrl(object contentItemObject, string elementCodename, int assetIndex = 0)
        {
            var asset = GetAsset(contentItemObject, elementCodename, assetIndex);
            return asset?.Url;
        }

        public static string GetCodename(object contentItemObject)
        {
            var contentItem = GetContentItem(contentItemObject);
            return contentItem?.System.Codename;
        }

        public static DateTime? GetDateTime(object contentItemObject, string elementCodename)
        {
            var contentItem = GetContentItem(contentItemObject);
            return contentItem?.GetDateTime(elementCodename);
        }

        public static decimal? GetNumber(object contentItemObject, string elementCodename)
        {
            var contentItem = GetContentItem(contentItemObject);
            return contentItem?.GetNumber(elementCodename);
        }

        public static string GetString(object contentItemObject, string elementCodename)
        {
            var contentItem = GetContentItem(contentItemObject);
            return contentItem?.GetString(elementCodename);
        }

        private static Asset GetAsset(object contentItemObject, string elementCodename, int assetIndex)
        {
            Asset asset = null;
            var contentItem = GetContentItem(contentItemObject);

            if (contentItem != null)
            {
                asset = contentItem.GetAssets(elementCodename).ElementAt(assetIndex);
            }

            return asset;
        }

        private static ContentItem GetContentItem(object contentItemObject)
        {
            if (contentItemObject != null)
            {
                return (ContentItem)contentItemObject;
            }

            return null;
        }
    }
}