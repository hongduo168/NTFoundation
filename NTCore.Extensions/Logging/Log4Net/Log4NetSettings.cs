namespace Chimera.Extensions.Logging.Log4Net
{
    using System.IO;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an object that contains log4net configuration settings.
    /// </summary>
    public class Log4NetSettings : ILog4NetSettings
    {
        /// <summary>
        /// The default log4net configuration settings.
        /// </summary>
        public static ILog4NetSettings Default = new Log4NetSettings();
        
        private readonly IDictionary<string, object> _contextProperties = new Dictionary<string, object>();

        /// <summary>
        /// Gets the global context properties.
        /// </summary>
        /// <value>
        /// The global context properties.
        /// </value>
        public IDictionary<string, object> GlobalContextProperties
        {
            get { return _contextProperties; }
        }

        /// <summary>
        /// Gets or sets the configuration file path.
        /// </summary>
        /// <value>
        /// The configuration file path.
        /// </value>
        public string ConfigFilePath { get; set; }

        /// <summary>
        /// Gets or sets the name of the root repository.
        /// </summary>
        /// <value>
        /// The name of the root repository.
        /// </value>
        public string RootRepositoryName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log4net watches for changes in the configuration file.
        /// </summary>
        /// <value>
        ///   <c>true</c> if configuration file is watched; otherwise, <c>false</c>.
        /// </value>
        public bool Watch { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetSettings"/> class.
        /// </summary>
        public Log4NetSettings()
        {
            GlobalContextProperties.Add("appRoot", Directory.GetCurrentDirectory());
            ConfigFilePath = "log4net.config";
            RootRepositoryName = GetDefaultRepositoryName();
        }

        private static string GetDefaultRepositoryName()
        {
#if NETSTANDARD1_3
            return "Root";
#else
            return System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
#endif
        }
    }
}
