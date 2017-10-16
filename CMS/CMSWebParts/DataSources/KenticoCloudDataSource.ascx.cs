using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.PortalEngine.Web.UI;
using CMS.Helpers;
using KenticoCloud.Delivery;
using CMS.DocumentEngine.Web.UI;

public partial class CMSWebParts_DataSources_KenticoCloudDataSource : CMSAbstractWebPart
{
    private string[] ElementsInternal = null;

    public string Codename
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("Codename"), string.Empty);
        }
    }

    public string ContentType
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("ContentType"), string.Empty);
        }
    }

    public string[] Elements
    {
        get
        {
            if (ElementsInternal == null)
            {
                ElementsInternal = ValidationHelper.GetString(this.GetValue("Elements"), string.Empty).Split(',');
            }

            return ElementsInternal;
        }
    }

    public string OrderAttribute
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("OrderAttribute"), string.Empty);
        }
    }

    public string OrderDirection
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("OrderDirection"), "").ToLower();
        }
    }

    public string ProjectId
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("ProjectId"), string.Empty);
        }
    }

    public int SelectTopN
    {
        get
        {
            return ValidationHelper.GetInteger(this.GetValue("Codename"), -1);
        }
    }

    public override void OnContentLoaded()
    {
        base.OnContentLoaded();
        SetupControl();
    }

    protected void SetupControl()
    {
        if (!this.StopProcessing)
        {
            // Sets the inner data source's name according to the web part's 'Web part control ID' property.
            // This allows listing web parts to connect to the inner control.
            // The identifier property is named 'FilterName' because data sources inherit the property from
            // a base class shared with filter objects.
            KenticoCloudDataSource.FilterName = (string)this.GetValue("WebPartControlID");

            // Set all other necessary properties.
            KenticoCloudDataSource.CacheItemName = CacheItemName;
            KenticoCloudDataSource.CacheMinutes = CacheMinutes;
            KenticoCloudDataSource.ContentType = ContentType;
            KenticoCloudDataSource.Elements = Elements;
            KenticoCloudDataSource.Codename = Codename;
            KenticoCloudDataSource.TopN = SelectTopN;
            KenticoCloudDataSource.OrderAttribute = OrderAttribute;
            KenticoCloudDataSource.OrderDirection = OrderDirection;
            KenticoCloudDataSource.KenticoCloudProjectId = ProjectId;
        }
    }
}