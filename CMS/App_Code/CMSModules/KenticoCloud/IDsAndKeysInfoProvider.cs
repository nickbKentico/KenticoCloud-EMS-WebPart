using System;
using System.Data;

using CMS.Base;
using CMS.DataEngine;
using CMS.Helpers;

namespace KenticoCloud
{    
    /// <summary>
    /// Class providing IDsAndKeysInfo management.
    /// </summary>
    public partial class IDsAndKeysInfoProvider : AbstractInfoProvider<IDsAndKeysInfo, IDsAndKeysInfoProvider>
    {
        #region "Constructors"

        /// <summary>
        /// Constructor
        /// </summary>
        public IDsAndKeysInfoProvider()
            : base(IDsAndKeysInfo.TYPEINFO)
        {
        }

        #endregion


        #region "Public methods - Basic"

        /// <summary>
        /// Returns a query for all the IDsAndKeysInfo objects.
        /// </summary>
        public static ObjectQuery<IDsAndKeysInfo> GetIDsAndKeys()
        {
            return ProviderObject.GetIDsAndKeysInternal();
        }


        /// <summary>
        /// Returns IDsAndKeysInfo with specified ID.
        /// </summary>
        /// <param name="id">IDsAndKeysInfo ID</param>
        public static IDsAndKeysInfo GetIDsAndKeysInfo(int id)
        {
            return ProviderObject.GetIDsAndKeysInfoInternal(id);
        }


        /// <summary>
        /// Returns IDsAndKeysInfo with specified GUID.
        /// </summary>
        /// <param name="guid">IDsAndKeysInfo GUID</param>                
        public static IDsAndKeysInfo GetIDsAndKeysInfo(Guid guid)
        {
            return ProviderObject.GetIDsAndKeysInfoInternal(guid);
        }


        /// <summary>
        /// Sets (updates or inserts) specified IDsAndKeysInfo.
        /// </summary>
        /// <param name="infoObj">IDsAndKeysInfo to be set</param>
        public static void SetIDsAndKeysInfo(IDsAndKeysInfo infoObj)
        {
            ProviderObject.SetIDsAndKeysInfoInternal(infoObj);
        }


        /// <summary>
        /// Deletes specified IDsAndKeysInfo.
        /// </summary>
        /// <param name="infoObj">IDsAndKeysInfo to be deleted</param>
        public static void DeleteIDsAndKeysInfo(IDsAndKeysInfo infoObj)
        {
            ProviderObject.DeleteIDsAndKeysInfoInternal(infoObj);
        }


        /// <summary>
        /// Deletes IDsAndKeysInfo with specified ID.
        /// </summary>
        /// <param name="id">IDsAndKeysInfo ID</param>
        public static void DeleteIDsAndKeysInfo(int id)
        {
            IDsAndKeysInfo infoObj = GetIDsAndKeysInfo(id);
            DeleteIDsAndKeysInfo(infoObj);
        }

        #endregion


        #region "Internal methods - Basic"
	
        /// <summary>
        /// Returns a query for all the IDsAndKeysInfo objects.
        /// </summary>
        protected virtual ObjectQuery<IDsAndKeysInfo> GetIDsAndKeysInternal()
        {
            return GetObjectQuery();
        }    


        /// <summary>
        /// Returns IDsAndKeysInfo with specified ID.
        /// </summary>
        /// <param name="id">IDsAndKeysInfo ID</param>        
        protected virtual IDsAndKeysInfo GetIDsAndKeysInfoInternal(int id)
        {	
            return GetInfoById(id);
        }


        /// <summary>
        /// Returns IDsAndKeysInfo with specified GUID.
        /// </summary>
        /// <param name="guid">IDsAndKeysInfo GUID</param>
        protected virtual IDsAndKeysInfo GetIDsAndKeysInfoInternal(Guid guid)
        {
            return GetInfoByGuid(guid);
        }


        /// <summary>
        /// Sets (updates or inserts) specified IDsAndKeysInfo.
        /// </summary>
        /// <param name="infoObj">IDsAndKeysInfo to be set</param>        
        protected virtual void SetIDsAndKeysInfoInternal(IDsAndKeysInfo infoObj)
        {
            SetInfo(infoObj);
        }


        /// <summary>
        /// Deletes specified IDsAndKeysInfo.
        /// </summary>
        /// <param name="infoObj">IDsAndKeysInfo to be deleted</param>        
        protected virtual void DeleteIDsAndKeysInfoInternal(IDsAndKeysInfo infoObj)
        {
            DeleteInfo(infoObj);
        }	

        #endregion
    }
}