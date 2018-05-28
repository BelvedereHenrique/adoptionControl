using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Desafio.Contracts;
using Desafio.Controllers;
using Desafio.Repository.Adopter;
using Desafio.Services.Adopter;
using Moq;
using NUnit.Framework;

namespace Desafio.Web.Tests
{
    [TestFixture]
    public class AdoptersControllerTests
    {
        private Mock<IAdopterService> GetMockedAdopterService()
        {
            return new Mock<IAdopterService>();
        }
        private OperationResult<List<AdopterContract>> GetFailOperationResultList()
        {
            return new OperationResult<List<AdopterContract>>(false, "Fail", new List<AdopterContract>() { });
        }
        private OperationResult<List<AdopterContract>> GetSuccessOperationResultList(Guid guid)
        {
            return new OperationResult<List<AdopterContract>>(true, "Success", new List<AdopterContract>() { new AdopterContract() { ID = guid } });
        }
        private OperationResult<AdopterContract> GetSuccessOperationResult(Guid guid)
        {
            return new OperationResult<AdopterContract>(true, "Success", new AdopterContract() { ID = guid });
        }
        private OperationResult<AdopterContract> GetFailOperationResult(Guid guid)
        {
            return new OperationResult<AdopterContract>(false, "Fail", null);
        }

        [Test]
        public void GetAll_Success()
        {
            var service = GetMockedAdopterService();
            service.Setup(x => x.GetAll()).Returns(GetSuccessOperationResultList(Guid.NewGuid()));

            var controller = new AdoptersController(service.Object);
            var result = (OperationResult<List<AdopterContract>>)controller.GetAll().Data;
            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.Greater(result.Result.Count, 0);
        }

        [Test]
        public void GetAll_Fail()
        {
            var service = GetMockedAdopterService();
            service.Setup(x => x.GetAll()).Returns(GetFailOperationResultList());

            var controller = new AdoptersController(service.Object);
            var result = (OperationResult<List<AdopterContract>>)controller.GetAll().Data;
            Assert.IsTrue(!result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.AreEqual(result.Result.Count, 0);
        }

        [Test]
        public void Get_Success()
        {
            var guid = Guid.NewGuid();
            var service = GetMockedAdopterService();
            service.Setup(x => x.Get(guid)).Returns(GetSuccessOperationResult(guid));

            var controller = new AdoptersController(service.Object);
            var result = (OperationResult<AdopterContract>)controller.Get(guid.ToString()).Data;
            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.AreEqual(guid, result.Result.ID);
        }

        [Test]
        public void Get_Fail()
        {
            var guid = Guid.NewGuid();
            var service = GetMockedAdopterService();
            service.Setup(x => x.Get(guid)).Returns(GetFailOperationResult(guid));

            var controller = new AdoptersController(service.Object);
            var result = (OperationResult<AdopterContract>)controller.Get(guid.ToString()).Data;
            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.IsNull(result.Result);
        }

        [Test]
        public void Add_Success()
        {
            var service = GetMockedAdopterService();
            service.Setup(x => x.Add(It.IsAny<AdopterContract>())).Returns(new OperationResult(true, "Success"));
            var controller = new AdoptersController(service.Object);

            var result = (OperationResult)controller.Add(new AdopterContract()).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Add_Fail()
        {
            var service = GetMockedAdopterService();
            service.Setup(x => x.Add(It.IsAny<AdopterContract>())).Returns(new OperationResult(false, "Fail"));
            var controller = new AdoptersController(service.Object);

            var result = (OperationResult)controller.Add(new AdopterContract()).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Edit_Success()
        {
            var service = GetMockedAdopterService();
            service.Setup(x => x.Edit(It.IsAny<AdopterContract>())).Returns(new OperationResult(true, "Success"));
            var controller = new AdoptersController(service.Object);

            var result = (OperationResult)controller.Edit(new AdopterContract()).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Edit_Fail()
        {
            var service = GetMockedAdopterService();
            service.Setup(x => x.Edit(It.IsAny<AdopterContract>())).Returns(new OperationResult(false, "Fail"));
            var controller = new AdoptersController(service.Object);

            var result = (OperationResult)controller.Edit(new AdopterContract()).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
        }
        [Test]
        public void Remove_Success()
        {
            var service = GetMockedAdopterService();
            service.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(new OperationResult(true, "Fail"));
            var controller = new AdoptersController(service.Object);

            var result = (OperationResult)controller.Remove(Guid.NewGuid().ToString()).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Remove_Fail()
        {
            var service = GetMockedAdopterService();
            service.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(new OperationResult(false, "Fail"));
            var controller = new AdoptersController(service.Object);

            var result = (OperationResult)controller.Remove(Guid.NewGuid().ToString()).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

    }
}
