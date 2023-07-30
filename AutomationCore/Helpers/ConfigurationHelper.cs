using System.Configuration;

namespace AutomationCore.Helpers
{
    public class ConfigurationHelper
    {
        // A static method used to retrieve a value from the application configuration file
        public static T GetValue<T>(string key)
        {
            // Get the value for the specified key from the application configuration file
            var value = ConfigurationManager.AppSettings[key];

            // Check if the value exists
            if (value == null)
            {
                // If the value does not exist, return the default value for the specified data type
                return default(T);
            }

            // If the value exists, convert it to the specified data type
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
