using Castle.DynamicProxy.Internal;
using EntityFrameworkUnitTestingWithAspNetWebApi;
using EntityFrameworkUnitTestingWithAspNetWebApi.Controllers;
using EntityFrameworkUnitTestingWithAspNetWebApi.Repository;
using Moq;
using System;
using Xunit;

namespace XUnitTestEntityFrameworkUnitTestingWithAspNetWebApi
{
    public class PersonControllerUnitTest
    {
        private readonly PersonController _personController = null;
        private Mock<IPersonRepository> _personRepository = null;

        public PersonControllerUnitTest()
        {
            _personController = new PersonController();
        }
        [Fact]
        public void CheckIfThePersonObjectIsValid()
        {
            //Arrange
            Person person = null;
            //Act
            try
            {
                _personController.PostPerson(person);
            }
            catch (Exception ex)
            {
                //Assert 
                //The thrown exception can be used for even more detailed assertions.
                Assert.Equal("The person object being created cannot be null", ex.Message);
            }
            
        }
    }
}
