using Moq;
using NUnit.Framework;
using Desafio.Services.Animal;
using Desafio.Controllers;
using Desafio.Contracts;
using System.Collections.Generic;
using System;

namespace Desafio.Web.Tests
{
    [TestFixture]
    public class AnimalsControllerTests
    {
        public Mock<IAnimalService> GetMockedAnimalService()
        {
            return new Mock<IAnimalService>();
        }
        private OperationResult<List<AnimalContract>> GetSuccessOperationResultList(Guid guid)
        {
            return new OperationResult<List<AnimalContract>>(true, "Success", new List<AnimalContract>() { new AnimalContract() { ID = guid } });
        }
        private OperationResult<List<AnimalContract>> GetFailOperationResultList()
        {
            return new OperationResult<List<AnimalContract>>(false, "Fail", null);
        }
        private OperationResult<AnimalContract> GetSuccessOperationResult(Guid guid)
        {
            return new OperationResult<AnimalContract>(true, "Success", new AnimalContract() { ID = guid });
        }
        private OperationResult<AnimalContract> GetFailOperationResult()
        {
            return new OperationResult<AnimalContract>(false, "Fail", null);
        }

        [Test]
        public void GetAll_Success()
        {
            var service = GetMockedAnimalService();
            service.Setup(x => x.GetAll()).Returns(GetSuccessOperationResultList(Guid.NewGuid()));
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult<List<AnimalContract>>)controller.GetAll().Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.Greater(result.Result.Count, 0);
        }

        [Test]
        public void GetAll_Fail()
        {
            var service = GetMockedAnimalService();
            service.Setup(x => x.GetAll()).Returns(GetFailOperationResultList());
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult<List<AnimalContract>>)controller.GetAll().Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.IsNull(result.Result);
        }

        [Test]
        public void Get_Success()
        {
            var guid = Guid.NewGuid();
            var service = GetMockedAnimalService();
            service.Setup(x => x.Get(guid)).Returns(GetSuccessOperationResult(guid));
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult<AnimalContract>)controller.Get(guid.ToString()).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.AreEqual(result.Result.ID, guid);
        }



        [Test]
        public void Get_Fail()
        {
            var guid = Guid.NewGuid();
            var service = GetMockedAnimalService();
            service.Setup(x => x.Get(guid)).Returns(GetFailOperationResult());
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult<AnimalContract>)controller.Get(guid.ToString()).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.IsNull(result.Result);
        }

        [Test]
        public void Add_Success()
        {
            var service = GetMockedAnimalService();
            service.Setup(x => x.Add(It.IsAny<AnimalContract>())).Returns(new OperationResult(true, "Success"));
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult)controller.Add(new AnimalContract()).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Add_Fail()
        {
            var service = GetMockedAnimalService();
            service.Setup(x => x.Add(It.IsAny<AnimalContract>())).Returns(new OperationResult(false, "Fail"));
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult)controller.Add(new AnimalContract()).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Edit_Success()
        {
            var service = GetMockedAnimalService();
            service.Setup(x => x.Edit(It.IsAny<AnimalContract>())).Returns(new OperationResult(true, "Success"));
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult)controller.Edit(new AnimalContract()).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Edit_Fail()
        {
            var service = GetMockedAnimalService();
            service.Setup(x => x.Edit(It.IsAny<AnimalContract>())).Returns(new OperationResult(false, "Fail"));
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult)controller.Edit(new AnimalContract()).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Remove_Success()
        {
            var service = GetMockedAnimalService();
            service.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(new OperationResult(true, "Success"));
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult)controller.Remove(Guid.NewGuid().ToString()).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Remove_Fail()
        {
            var service = GetMockedAnimalService();
            service.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(new OperationResult(false, "Fail"));
            var controller = new AnimalsController(service.Object);

            var result = (OperationResult)controller.Remove(Guid.NewGuid().ToString()).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

    }
}
