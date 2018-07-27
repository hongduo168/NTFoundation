namespace Chimera.Extensions.Logging.Log4Net
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an object that contains log4net configuration settings.
    /// </summary>
    public interface ILog4NetSettings
    {
        /// <summary>
        /// Gets the global context properties.
        /// </summary>
        /// <value>
        /// The global context properties.
        /// </value>
        IDictionary<string, object> GlobalContextProperties { get; }

        /// <summary>
        /// Gets the configuration file path.
        /// </summary>
        /// <value>
        /// The configuration file path.
        /// </value>
        string ConfigFilePath { get; }

        /// <summary>
        /// Gets the name of the root repository.
        /// </summary>
        /// <value>
        /// The name of the root repository.
        /// </value>
        string RootRepositoryName { get; }

        /// <summary>
        /// Gets a value indicating whether log4net watches for changes in the configuration file.
        /// </summary>
        /// <value>
        ///   <c>true</c> if configuration file is watched; otherwise, <c>false</c>.
        /// </value>
        bool Watch { get; }
    }
}
