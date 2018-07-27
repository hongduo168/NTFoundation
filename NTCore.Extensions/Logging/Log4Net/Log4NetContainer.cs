namespace Chimera.Extensions.Logging.Log4Net
{
    using System;
    using System.IO;
    using log4net;
    using log4net.Config;
    using log4net.Core;
    using log4net.Repository;

    /// <summary>
    /// Definition of a container for log4net repository initialization and creation.
    /// </summary>
    /// <seealso cref="Chimera.Extensions.Logging.Log4Net.ILog4NetContainer" />
    public class Log4NetContainer : ILog4NetContainer
    {
        private readonly ILog4NetSettings _settings;
        private ILoggerRepository _loggerRepository;

        /// <summary>
        /// Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitialized
        {
            get { return _loggerRepository != null; }
        }

        /// <summary>
        /// Gets the logger repository.
        /// </summary>
        /// <value>
        /// The logger repository.
        /// </value>
        public ILoggerRepository LoggerRepository
        {
            get { return _loggerRepository; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetContainer"/> class.
        /// </summary>
        /// <param name="settings">The log4net settings.</param>
        /// <exception cref="ArgumentNullException">settings</exception>
        public Log4NetContainer(ILog4NetSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            _settings = settings;
        }

        /// <summary>
        /// Gets the log interface used by applications to log messages into the log4net framework.
        /// </summary>
        /// <param name="name">The name of the logger.</param>
        /// <returns>
        /// The logging interface.
        /// </returns>
        public ILog GetLog(string name)
        {
            var logger = LoggerRepository.GetLogger(name);
            return new LogImpl(logger);
        }

        /// <summary>
        /// Initializes this instance of log4net.
        /// </summary>
        public void Initialize()
        {
            if (IsInitialized) return;

            foreach (var item in _settings.GlobalContextProperties)
            {
                GlobalContext.Properties[item.Key] = item.Value;
            }
            
            _loggerRepository = CreateRootRepository();
        }

        private ILoggerRepository CreateRootRepository()
        {
            var loggerRepository = LogManager.CreateRepository(_settings.RootRepositoryName);

            var fileInfo = new FileInfo(Path.GetFullPath(_settings.ConfigFilePath));
            if (_settings.Watch)
            {
                XmlConfigurator.ConfigureAndWatch(loggerRepository, fileInfo);
            }
            else
            {
                XmlConfigurator.Configure(loggerRepository, fileInfo);
            }

            return loggerRepository;
        }
    }
}