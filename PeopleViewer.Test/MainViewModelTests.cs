using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace PeopleViewer.Test
{
    using System.Linq;

    using PersonRepository.Fake;

    // Only reference to FakeRepository needed

    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        // Naming -> event -> expected
        public void People_OnFetchData_IsPopulated()
        {
            // Arrange
            var viewModel = new MainViewModel(new FakeRepository());

            // Act
            viewModel.FetchDataForUi();

            //Assert
            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(2, viewModel.People.Count());
        }

        [TestMethod]
        public void RepositoryType_OnCreation_ReturnsFakeRepository()
        {
            // Arrange/Act
            var viewModel = new MainViewModel(new FakeRepository());
            var expectedString = "PersonRepository.Fake.FakeRepository, PersonRepository.Fake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

            // Assert
            Assert.AreEqual(expectedString, viewModel.RepositoryType);
        }
    }
}
