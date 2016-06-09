namespace Hackerrank
{
    using log4net;
    using log4net.Config;

    using NUnit.Framework;

    class BaseTest
    {
        protected static readonly ILog Log = LogManager.GetLogger(typeof(BaseTest));

        [SetUp]
        public void Setup()
        {
            XmlConfigurator.Configure();
        }
    }
}
