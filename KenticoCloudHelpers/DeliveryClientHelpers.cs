using CMS.DataEngine;
using CMS.SiteProvider;
using KenticoCloud.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenticoCloudHelpers
{
    public class DeliveryClientHelpers
    {
        private const string KenticoCloudProjectIDSettingsKeyCodeName = "KenticoCloudProjectId";

        private static string GetDefaultProjectId()
        {
            return SettingsKeyInfoProvider.GetValue(KenticoCloudProjectIDSettingsKeyCodeName, SiteContext.CurrentSiteName);
        }

        public static DeliveryClient GetDeliveryClient(string projectId = null)
        {
            var selectedProjectId = !string.IsNullOrWhiteSpace(projectId) ? projectId : GetDefaultProjectId();
            return new DeliveryClient(selectedProjectId);
        }
    }
}
