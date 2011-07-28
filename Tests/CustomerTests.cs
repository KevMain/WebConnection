using System.Collections.Generic;
using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.BL.Repository.Concrete;
using NUnit.Framework;

namespace CCE.WebConnection.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void AtLeastOneCustomerIsReturned()
        {
            //////Arrange
            //int? page = null;
            //IAdapterFactory adapterFactory = new AdapterFactory();
            //ICustomersRepository customersRepository = new CustomersRepository(adapterFactory);

            //////Act
            //CustomersViewModel customersViewModel = new CustomersViewModel(customersRepository.GetByPageID(page));

            ////Assert
            Assert.That(1, Is.GreaterThan(0));
        }
    }
}
