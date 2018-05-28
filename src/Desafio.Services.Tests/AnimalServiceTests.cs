using Moq;
using System;
using NUnit.Framework;
using Desafio.Contracts;
using Desafio.Services.Animal;
using Desafio.Repository.Animal;
using System.Collections.Generic;

namespace Desafio.Services.Tests
{
    [TestFixture]
    public class AnimalServiceTests
    {
        public Mock<IAnimalRepository> GetMockedAnimalRepository()
        {
            return new Mock<IAnimalRepository>();
        }

        [Test]
        public void Get_Success()
        {
            var repo = GetMockedAnimalRepository();

            var guid = Guid.NewGuid();
            repo.Setup(x => x.Get(guid)).Returns(new AnimalContract() { ID = guid });

            var service = new AnimalService(repo.Object);
            var result = service.Get(guid);

            Assert.AreEqual(result.Result.ID, guid);
            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Get_Fail()
        {
            var repo = GetMockedAnimalRepository();

            var failMessage = "fail";
            repo.Setup(x => x.Get(It.IsAny<Guid>())).Throws(new Exception(failMessage));

            var service = new AnimalService(repo.Object);
            var result = service.Get(Guid.Empty);

            Assert.IsNull(result.Result);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void GetAll_Success()
        {
            var repo = GetMockedAnimalRepository();

            repo.Setup(x => x.GetAll()).Returns(new List<AnimalContract>() {
                new AnimalContract()
                {
                    ID = Guid.NewGuid()
                }
            });

            var service = new AnimalService(repo.Object);
            var result = service.GetAll();

            Assert.Greater(result.Result.Count, 0);
            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void GetAll_Fail()
        {
            var repo = GetMockedAnimalRepository();

            var failMessage = "fail";
            repo.Setup(x => x.GetAll()).Throws(new Exception(failMessage));

            var service = new AnimalService(repo.Object);
            var result = service.GetAll();

            Assert.IsNull(result.Result);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Add_Success()
        {
            var repo = GetMockedAnimalRepository();
            repo.Setup(x => x.Add(It.IsAny<AnimalContract>()));

            var service = new AnimalService(repo.Object);
            var result = service.Add(new AnimalContract() { ID = Guid.NewGuid() });
            Assert.IsNotEmpty(result.Message);
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Add_Fail_RepositoryException()
        {
            var repo = GetMockedAnimalRepository();

            var failMessage = "fail";
            repo.Setup(x => x.Add(It.IsAny<AnimalContract>())).Throws(new Exception(failMessage));

            var service = new AnimalService(repo.Object);
            var result = service.Add(new AnimalContract() { ID = Guid.NewGuid() });

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }


        [Test]
        public void Add_Fail_NullContract()
        {
            var repo = GetMockedAnimalRepository();
            var failMessage = "Null contract.";
            var service = new AnimalService(null);
            var result = service.Add(null);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Delete_Success()
        {
            var repo = GetMockedAnimalRepository();
            repo.Setup(x => x.Delete(It.IsAny<Guid>()));

            var service = new AnimalService(repo.Object);
            var result = service.Delete(Guid.NewGuid());
            Assert.IsNotEmpty(result.Message);
            Assert.IsTrue(result.Success);

        }

        [Test]
        public void Delete_Fail_RepositoryException()
        {
            var repo = GetMockedAnimalRepository();
            string failMessage = "fail";
            repo.Setup(x => x.Delete(It.IsAny<Guid>())).Throws(new Exception(failMessage));

            var service = new AnimalService(repo.Object);
            var result = service.Delete(Guid.NewGuid());

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Delete_Fail_EmptyID()
        {
            var repo = GetMockedAnimalRepository();
            var failMessage = "Empty ID.";
            var service = new AnimalService(null);
            var result = service.Delete(Guid.Empty);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Edit_Success()
        {
            var repo = GetMockedAnimalRepository();
            repo.Setup(x => x.Edit(It.IsAny<AnimalContract>()));

            var service = new AnimalService(repo.Object);
            var result = service.Edit(new AnimalContract() { ID = Guid.NewGuid() });
            Assert.IsNotEmpty(result.Message);
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Edit_Fail_RepositoryException()
        {
            var repo = GetMockedAnimalRepository();

            var failMessage = "fail";
            repo.Setup(x => x.Edit(It.IsAny<AnimalContract>())).Throws(new Exception(failMessage));

            var service = new AnimalService(repo.Object);
            var result = service.Edit(new AnimalContract() { ID = Guid.NewGuid() });

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }


        [Test]
        public void Edit_Fail_NullContract()
        {
            var repo = GetMockedAnimalRepository();
            var failMessage = "Null contract.";
            var service = new AnimalService(null);
            var result = service.Edit(null);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }
    }
}
