namespace Chimera.Extensions.Logging.Log4Net
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Represents an object that contains log4net configuration settings from an <see cref="IConfiguration"/> object.
    /// </summary>
    public class ConfigurationLog4NetSettings : ILog4NetSettings
    {
        private readonly IConfiguration _configuration;
        private readonly IDictionary<string, object> _contextProperties = new Dictionary<string, object>(Log4NetSettings.Default.GlobalContextProperties);

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
        /// Gets the configuration file path.
        /// </summary>
        /// <value>
        /// The configuration file path.
        /// </value>
        public string ConfigFilePath
        {
            get
            {
                var value = _configuration[nameof(ConfigFilePath)];
                if (string.IsNullOrEmpty(value))
                {
                    return Log4NetSettings.Default.ConfigFilePath;
                }

                return value;
            }
        }

        /// <summary>
        /// Gets the name of the root repository.
        /// </summary>
        /// <value>
        /// The name of the root repository.
        /// </value>
        public string RootRepositoryName
        {
            get
            {
                var value = _configuration[nameof(RootRepositoryName)];
                if (string.IsNullOrEmpty(value))
                {
                    return Log4NetSettings.Default.RootRepositoryName;
                }
                
                return value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether log4net watches for changes in the configuration file.
        /// </summary>
        /// <value>
        ///   <c>true</c> if configuration file is watched; otherwise, <c>false</c>.
        /// </value>
        public bool Watch
        {
            get
            {
                bool watch;
                var value = _configuration[nameof(Watch)];
                if (string.IsNullOrEmpty(value))
                {
                    return Log4NetSettings.Default.Watch;
                }
                else if (bool.TryParse(value, out watch))
                {
                    return watch;
                }

                var message = $"Configuration value '{value}' for setting '{nameof(Watch)}' is not supported.";
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationLog4NetSettings"/> class.
        /// </summary>
        /// <param name="configuration">The configuration container.</param>
        public ConfigurationLog4NetSettings(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _configuration = configuration;
            PopulateGlobalContextProperties();
        }

        private void PopulateGlobalContextProperties()
        {
            var properties = _configuration.GetSection(nameof(GlobalContextProperties));
            if (properties == null)
            {
                return;
            }

            foreach (var property in properties.GetChildren())
            {
                if (_contextProperties.ContainsKey(property.Key))
                {
                    _contextProperties.Remove(property.Key);
                }

                _contextProperties.Add(property.Key, property.Value);
            }
        }
    }
}
