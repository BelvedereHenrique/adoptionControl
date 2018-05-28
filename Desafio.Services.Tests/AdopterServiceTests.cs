using Moq;
using System;
using NUnit.Framework;
using Desafio.Contracts;
using Desafio.Services.Adopter;
using Desafio.Repository.Adopter;
using System.Collections.Generic;

namespace Desafio.Services.Tests
{
    [TestFixture]
    public class AdopterServiceTests
    {
        public Mock<IAdopterRepository> GetMockedAdopterRepository()
        {
            return new Mock<IAdopterRepository>();
        }

        [Test]
        public void Get_Success()
        {
            var repo = GetMockedAdopterRepository();

            var guid = Guid.NewGuid();
            repo.Setup(x => x.Get(guid)).Returns(new AdopterContract() { ID = guid });

            var service = new AdopterService(repo.Object);
            var result = service.Get(guid);

            Assert.AreEqual(result.Result.ID, guid);
            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Get_Fail()
        {
            var repo = GetMockedAdopterRepository();

            var failMessage = "fail";
            repo.Setup(x => x.Get(It.IsAny<Guid>())).Throws(new Exception(failMessage));

            var service = new AdopterService(repo.Object);
            var result = service.Get(Guid.Empty);

            Assert.IsNull(result.Result);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void GetAll_Success()
        {
            var repo = GetMockedAdopterRepository();

            repo.Setup(x => x.GetAll()).Returns(new List<AdopterContract>() {
                new AdopterContract()
                {
                    ID = Guid.NewGuid()
                }
            });

            var service = new AdopterService(repo.Object);
            var result = service.GetAll();

            Assert.Greater(result.Result.Count, 0);
            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void GetAll_Fail()
        {
            var repo = GetMockedAdopterRepository();

            var failMessage = "fail";
            repo.Setup(x => x.GetAll()).Throws(new Exception(failMessage));

            var service = new AdopterService(repo.Object);
            var result = service.GetAll();

            Assert.IsNull(result.Result);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Add_Success()
        {
            var repo = GetMockedAdopterRepository();
            repo.Setup(x => x.Add(It.IsAny<AdopterContract>()));

            var service = new AdopterService(repo.Object);
            var result = service.Add(new AdopterContract() { ID = Guid.NewGuid() });
            Assert.IsNotEmpty(result.Message);
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Add_Fail_RepositoryException()
        {
            var repo = GetMockedAdopterRepository();

            var failMessage = "fail";
            repo.Setup(x => x.Add(It.IsAny<AdopterContract>())).Throws(new Exception(failMessage));

            var service = new AdopterService(repo.Object);
            var result = service.Add(new AdopterContract() { ID = Guid.NewGuid() });

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }


        [Test]
        public void Add_Fail_NullContract()
        {
            var repo = GetMockedAdopterRepository();
            var failMessage = "Null contract.";
            var service = new AdopterService(null);
            var result = service.Add(null);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Delete_Success()
        {
            var repo = GetMockedAdopterRepository();
            repo.Setup(x => x.Delete(It.IsAny<Guid>()));

            var service = new AdopterService(repo.Object);
            var result = service.Delete(Guid.NewGuid());
            Assert.IsNotEmpty(result.Message);
            Assert.IsTrue(result.Success);

        }

        [Test]
        public void Delete_Fail_RepositoryException()
        {
            var repo = GetMockedAdopterRepository();
            string failMessage = "fail";
            repo.Setup(x=>x.Delete(It.IsAny<Guid>())).Throws(new Exception(failMessage));

            var service = new AdopterService(repo.Object);
            var result = service.Delete(Guid.NewGuid());

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Delete_Fail_EmptyID()
        {
            var repo = GetMockedAdopterRepository();
            var failMessage = "Empty ID.";
            var service = new AdopterService(null);
            var result = service.Delete(Guid.Empty);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Edit_Success()
        {
            var repo = GetMockedAdopterRepository();
            repo.Setup(x => x.Edit(It.IsAny<AdopterContract>()));

            var service = new AdopterService(repo.Object);
            var result = service.Edit(new AdopterContract() { ID = Guid.NewGuid() });
            Assert.IsNotEmpty(result.Message);
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Edit_Fail_RepositoryException()
        {
            var repo = GetMockedAdopterRepository();

            var failMessage = "fail";
            repo.Setup(x => x.Edit(It.IsAny<AdopterContract>())).Throws(new Exception(failMessage));

            var service = new AdopterService(repo.Object);
            var result = service.Edit(new AdopterContract() { ID = Guid.NewGuid() });

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }


        [Test]
        public void Edit_Fail_NullContract()
        {
            var repo = GetMockedAdopterRepository();
            var failMessage = "Null contract.";
            var service = new AdopterService(null);
            var result = service.Edit(null);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }
    }
}
