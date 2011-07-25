using NUnit.Framework;

namespace CCE.WebConnection.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void AtLeastOneCustomerIsReturned()
        {
            const int counter = 1;
            Assert.That(counter, Is.GreaterThan(1));
        }
    }
}
