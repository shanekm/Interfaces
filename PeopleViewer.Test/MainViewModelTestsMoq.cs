namespace PeopleViewer.Test
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Moq;
    using PersonRepository.Interfaces;
    using ViewModel;
    
    [TestClass]
    public class MainViewModelTestsMoq
    {
        private Mock<IPersonRepository> mockRepository = new Mock<IPersonRepository>();

        [TestInitialize]
        public void Setup()
        {
            var people = new List<Person>
                        {
                            new Person() { FirstName = "JohnMoq", LastName = "Benish" },
                            new Person() { FirstName = "StewMoq", LastName = "Billing" }
                        };

            mockRepository.Setup(x => x.GetPeople()).Returns(people);
        }

        [TestMethod]
        // Naming -> event -> expected
        public void People_OnFetchData_IsPopulated()
        {
            // Arrange
            var viewModel = new MainViewModel(mockRepository.Object);
            
            // Act
            viewModel.FetchDataForUi();

            //Assert
            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(2, viewModel.People.Count());
        }

        //[TestMethod]
        //public void RepositoryType_OnCreation_ReturnsFakeRepository()
        //{
        //    // Arrange/Act
        //    var viewModel = new MainViewModel();
        //    var expectedString = "PersonRepository.Fake.FakeRepository, PersonRepository.Fake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        //    // Assert
        //    Assert.AreEqual(expectedString, viewModel.RepositoryType);
        //}
    }
}
