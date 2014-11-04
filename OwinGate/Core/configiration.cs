namespace OwinGate.Core
{
    public class configiration
    {
        /// <summary>
        /// Application Config Read Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)        
        {
            string result = null;
            if (System.Web.Configuration.WebConfigurationManager.AppSettings.Count > 0)
            {
                string customSetting = System.Web.Configuration.WebConfigurationManager.AppSettings.Get(key);
                if (customSetting != null)
                    result = customSetting;
                else
                    result = "";
            }
            return result;
        }
    }
}