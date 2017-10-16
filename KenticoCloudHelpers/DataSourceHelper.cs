using CMS.DataEngine;
using CMS.SiteProvider;
using KenticoCloud.Delivery;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KenticoCloudHelpers
{
    public static class DataSourceHelper
    {
        public static ContentItem GetContentItem(string projectId, string codename, string contentType, string[] elements = null)
        {
            if (string.IsNullOrWhiteSpace(codename) || string.IsNullOrWhiteSpace(contentType))
            {
                throw new Exception("Codename and content type are both required.");
            }

            var parameters = new List<IQueryParameter>();
            AddContentTypeParameterIfValid(parameters, contentType);
            AddElementsParameterIfValid(parameters, elements);

            return Task.Run(() => GetCloudItemAsync(projectId, codename, parameters)).Result;
        }

        public static List<object> GetContentItemAsList(string projectId, string codename, string contentType, string[] elements = null)
        {
            return new List<object>() { GetContentItem(projectId, codename, contentType, elements) };
        }

        public static List<object> GetContentItems(string projectId, string contentType, int? topN, string[] elements = null, string orderBy = null, string orderDirection = null)
        {
            if (string.IsNullOrWhiteSpace(contentType))
            {
                throw new Exception("Content type is required.");
            }

            var parameters = new List<IQueryParameter>();
            AddContentTypeParameterIfValid(parameters, contentType);
            AddLimitParameterIfValid(parameters, topN);
            AddElementsParameterIfValid(parameters, elements);
            AddOrderParameterIfValid(parameters, orderBy, orderDirection);

            var results = Task.Run(() => GetCloudItemsAsync(projectId, parameters)).Result;

            return results.Cast<object>().ToList();
        }

        private static void AddContentTypeParameterIfValid(List<IQueryParameter> parameters, string contentType)
        {
            if (!string.IsNullOrWhiteSpace(contentType))
            {
                parameters.Add(new EqualsFilter("system.type", contentType));
            }
        }

        private static void AddElementsParameterIfValid(List<IQueryParameter> parameters, string[] elements)
        {
            if (elements != null)
            {
                parameters.Add(new ElementsParameter(elements));
            }
        }

        private static void AddLimitParameterIfValid(List<IQueryParameter> parameters, int? limit)
        {
            if (limit.HasValue && limit > 0)
            {
                parameters.Add(new LimitParameter(limit.Value));
            }
        }

        private static void AddOrderParameterIfValid(List<IQueryParameter> parameters, string orderBy, string orderDirection)
        {
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var sortOrder = GetSortOrder(orderDirection);
                parameters.Add(new OrderParameter(orderBy, sortOrder));
            }
        }

        private static async Task<ContentItem> GetCloudItemAsync(string projectId, string codename, IEnumerable<IQueryParameter> parameters)
        {
            var deliveryClient = DeliveryClientHelpers.GetDeliveryClient(projectId);
            DeliveryItemResponse response = await deliveryClient.GetItemAsync(codename, parameters);
            return response?.Item;
        }

        private static async Task<List<ContentItem>> GetCloudItemsAsync(string projectId, IEnumerable<IQueryParameter> parameters)
        {
            var deliveryClient = DeliveryClientHelpers.GetDeliveryClient(projectId);
            DeliveryItemListingResponse response = await deliveryClient.GetItemsAsync(parameters);
            return response?.Items.ToList();
        }

        private static SortOrder GetSortOrder(string value)
        {
            return value.ToLower() == "descending" ? SortOrder.Descending : SortOrder.Ascending;
        }
    }
}