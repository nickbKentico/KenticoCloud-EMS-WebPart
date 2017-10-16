using System;
using System.Data;
using System.Runtime.Serialization;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using KenticoCloud;

[assembly: RegisterObjectType(typeof(IDsAndKeysInfo), IDsAndKeysInfo.OBJECT_TYPE)]
    
namespace KenticoCloud
{
    /// <summary>
    /// IDsAndKeysInfo data container class.
    /// </summary>
	[Serializable]
    public partial class IDsAndKeysInfo : AbstractInfo<IDsAndKeysInfo>
    {
        #region "Type information"

        /// <summary>
        /// Object type
        /// </summary>
        public const string OBJECT_TYPE = "kenticocloud.idsandkeys";


        /// <summary>
        /// Type information.
        /// </summary>
#warning "You will need to configure the type info."
        public static ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(IDsAndKeysInfoProvider), OBJECT_TYPE, "KenticoCloud.IDsAndKeys", "IDsAndKeysID", "IDsAndKeysLastModified", "IDsAndKeysGuid", null, null, null, null, null, null)
        {
			ModuleName = "KenticoCloud",
			TouchCacheDependencies = true,
        };

        #endregion


        #region "Properties"

        /// <summary>
        /// I ds and keys ID
        /// </summary>
        [DatabaseField]
        public virtual int IDsAndKeysID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("IDsAndKeysID"), 0);
            }
            set
            {
                SetValue("IDsAndKeysID", value);
            }
        }


        /// <summary>
        /// This can be found in the API Keys section of the Kentico Cloud interface and is called the Project ID.
        /// </summary>
        [DatabaseField]
        public virtual string Kentico_Cloud_Project_ID
        {
            get
            {
                return ValidationHelper.GetString(GetValue("Kentico_Cloud_Project_ID"), String.Empty);
            }
            set
            {
                SetValue("Kentico_Cloud_Project_ID", value);
            }
        }


        /// <summary>
        /// I ds and keys guid
        /// </summary>
        [DatabaseField]
        public virtual Guid IDsAndKeysGuid
        {
            get
            {
                return ValidationHelper.GetGuid(GetValue("IDsAndKeysGuid"), Guid.Empty);
            }
            set
            {
                SetValue("IDsAndKeysGuid", value);
            }
        }


        /// <summary>
        /// I ds and keys last modified
        /// </summary>
        [DatabaseField]
        public virtual DateTime IDsAndKeysLastModified
        {
            get
            {
                return ValidationHelper.GetDateTime(GetValue("IDsAndKeysLastModified"), DateTimeHelper.ZERO_TIME);
            }
            set
            {
                SetValue("IDsAndKeysLastModified", value);
            }
        }

        #endregion


        #region "Type based properties and methods"

        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            IDsAndKeysInfoProvider.DeleteIDsAndKeysInfo(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            IDsAndKeysInfoProvider.SetIDsAndKeysInfo(this);
        }

        #endregion


        #region "Constructors"

		/// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected IDsAndKeysInfo(SerializationInfo info, StreamingContext context)
            : base(info, context, TYPEINFO)
        {
        }


        /// <summary>
        /// Constructor - Creates an empty IDsAndKeysInfo object.
        /// </summary>
        public IDsAndKeysInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Constructor - Creates a new IDsAndKeysInfo object from the given DataRow.
        /// </summary>
        /// <param name="dr">DataRow with the object data</param>
        public IDsAndKeysInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }

        #endregion
    }
}