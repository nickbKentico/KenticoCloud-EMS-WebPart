using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.FormEngine.Web.UI;
using CMS.Helpers;
using KenticoCloud.Delivery;
using CMS.DataEngine;
using CMS.SiteProvider;
using System.Threading.Tasks;

namespace CMSApp.CMSFormControls.KenticoCloud
{
    public partial class KenticoCloudContentTypeSelector : FormEngineUserControl
    {

        /// <summary>
        /// Gets or sets the value entered into the field, a hexadecimal color code in this case.
        /// </summary>
        public override object Value
        {
            get
            {
                return drpContentTypes.SelectedValue;
            }
            set
            {
                // Selects the matching value in the drop-down
                EnsureItems();
                drpContentTypes.SelectedValue = System.Convert.ToString(value);
            }
        }

        /// <summary>
        /// Property used to access the Width parameter of the form control.
        /// </summary>
        public int SelectorWidth
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("SelectorWidth"), 0);
            }
            set
            {
                SetValue("SelectorWidth", value);
            }
        }

        /// <summary>
        /// Returns an array of values of any other fields returned by the control.
        /// </summary>
        /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>
        public override object[,] GetOtherValues()
        {
            object[,] array = new object[1, 2];
            array[0, 0] = "ContentTypeSelected";
            array[0, 1] = drpContentTypes.SelectedItem.Value;
            return array;
        }

        /// <summary>
        /// Returns true if a Content Type is selected. Otherwise, it returns false and displays an error message.
        /// </summary>
        public override bool IsValid()
        {
            if ((string)Value != "")
            {
                return true;
            }
            else
            {
                // Sets the form control validation error message
                this.ValidationError = "Please choose a Content Type.";
                return false;
            }
        }


        /// <summary>
        /// Sets up the internal DropDownList control.
        /// </summary>
        protected void EnsureItems()
        {
            // Applies the width specified through the parameter of the form control if it is valid
            if (SelectorWidth > 0)
            {
                drpContentTypes.Width = SelectorWidth;
            }
            //Get ContentTypes from Kentico Cloud
            
            var ContentTypeList = Task.Run(getCloudContentTypes).Result;

            // Generates the options in the drop-down list
            if (drpContentTypes.Items.Count == 0)
            {
                drpContentTypes.Items.Add(new ListItem("(Select content type)", ""));
                foreach (ContentType cT in ContentTypeList)
                {
                    if(this.Value.ToString() == cT.System.Codename)
                    {
                       ListItem li = new ListItem(cT.System.Name, cT.System.Codename);
                        li.Selected = true;
                        drpContentTypes.Items.Add(li);

                    }
                    else
                    {
                        drpContentTypes.Items.Add(new ListItem(cT.System.Name, cT.System.Codename));
                    }
                   
                }
            }
        }
        protected async Task<List<ContentType>> getCloudContentTypes()
        {
            string KenticoCloudProjectID = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + ".KenticoCloudProjectId");

            DeliveryClient client = new DeliveryClient(KenticoCloudProjectID);

            DeliveryTypeListingResponse response = await client.GetTypesAsync();
            var types = response.Types;
            return types.ToList();
        }

        /// <summary>
        /// Handler for the Load event of the control.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure drop-down list options
            EnsureItems();
        }
    }
}