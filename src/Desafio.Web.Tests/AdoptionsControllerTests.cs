using Moq;
using System;
using System.Linq;
using NUnit.Framework;
using Desafio.Contracts;
using Desafio.Controllers;
using Desafio.Services.Adoption;
using System.Collections.Generic;

namespace Desafio.Web.Tests
{
    [TestFixture]
    public class AdoptionsControllerTests
    {
        public Mock<IAdoptionService> GetMockedAdoptionService()
        {
            return new Mock<IAdoptionService>();
        }
        private OperationResult<List<AnimalContract>> GetSuccessAnimalOperationResultList(Guid guid)
        {
            return new OperationResult<List<AnimalContract>>(true, "Success", new List<AnimalContract>() { new AnimalContract() { ID = guid } });
        }
        private OperationResult<List<AnimalContract>> GetFailAnimalOperationResultList()
        {
            return new OperationResult<List<AnimalContract>>(false, "Fail", null);
        }
        private OperationResult GetSuccessOperationResult()
        {
            return new OperationResult(true, "Success");
        }
        private OperationResult GetFailOperationResult()
        {
            return new OperationResult(false, "Fail");
        }
        private  OperationResult<List<AdoptionContract>> GetSucessOperationResultList(Guid guid1, Guid guid2)
        {
            return new OperationResult<List<AdoptionContract>>(
                true,
                "Success",
                new List<AdoptionContract>()
                {
                    new AdoptionContract()
                    {
                        Adopter = new AdopterContract()
                        {
                            ID = guid1
                        },
                        Animal = new AnimalContract()
                        {
                            ID = guid2
                        }
                    }
                });
        }
        private OperationResult<List<AdoptionContract>> GetFailOperationResultList()
        {
            return new OperationResult<List<AdoptionContract>>(false, "Fail", null);
        }

        [Test]
        public void GetFreeAnimals_Success()
        {
            var service = GetMockedAdoptionService();
            var guid = Guid.NewGuid();
            service.Setup(x => x.GetFreeAnimals()).Returns(GetSuccessAnimalOperationResultList(guid));

            var controller = new AdoptionsController(service.Object);
            var result = (OperationResult<List<AnimalContract>>)controller.GetFreeAnimals().Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.Greater(result.Result.Count, 0);
            Assert.AreEqual(result.Result.FirstOrDefault().ID, guid);
        }


        [Test]
        public void GetFreeAnimals_Fail()
        {
            var service = GetMockedAdoptionService();
            var guid = Guid.NewGuid();
            service.Setup(x => x.GetFreeAnimals()).Returns(GetFailAnimalOperationResultList());

            var controller = new AdoptionsController(service.Object);
            var result = (OperationResult<List<AnimalContract>>)controller.GetFreeAnimals().Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.IsNull(result.Result);

        }

        [Test]
        public void GetAll_Success()
        {
            var service = GetMockedAdoptionService();
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            service.Setup(x => x.GetAll()).Returns(GetSucessOperationResultList(guid1, guid2));

            var controller = new AdoptionsController(service.Object);
            var result = (OperationResult<List<AdoptionContract>>)controller.GetAll().Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.Greater(result.Result.Count, 0);
            Assert.IsNotNull(result.Result.FirstOrDefault(x => x.Adopter.ID == guid1));
            Assert.IsNotNull(result.Result.FirstOrDefault(x=>x.Animal.ID == guid2));
        }



        [Test]
        public void GetAll_Fail()
        {
            var service = GetMockedAdoptionService();
            service.Setup(x => x.GetAll()).Returns(GetFailOperationResultList());

            var controller = new AdoptionsController(service.Object);
            var result = (OperationResult<List<AdoptionContract>>)controller.GetAll().Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
            Assert.IsNull(result.Result);
        }


        [Test]
        public void Adopt_Success()
        {
            var service = GetMockedAdoptionService();
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            service.Setup(x => x.Adopt(guid1,guid2)).Returns(GetSuccessOperationResult());

            var controller = new AdoptionsController(service.Object);
            var result = (OperationResult)controller.Adopt(guid1,guid2).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Adopt_Fail()
        {
            var service = GetMockedAdoptionService();
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            service.Setup(x => x.Adopt(guid1,guid2)).Returns(GetFailOperationResult());

            var controller = new AdoptionsController(service.Object);
            var result = (OperationResult)controller.Adopt(guid1,guid2).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
        }
        [Test]
        public void RemoveAdoption_Success()
        {
            var service = GetMockedAdoptionService();
            var guid1 = Guid.NewGuid();
            service.Setup(x => x.CancelAdoption(guid1)).Returns(GetSuccessOperationResult());

            var controller = new AdoptionsController(service.Object);
            var result = (OperationResult)controller.RemoveAdoption(guid1).Data;

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);

        }

        [Test]
        public void RemoveAdoption_Fail()
        {
            var service = GetMockedAdoptionService();
            var guid1 = Guid.NewGuid();
            service.Setup(x => x.CancelAdoption(guid1)).Returns(GetFailOperationResult());

            var controller = new AdoptionsController(service.Object);
            var result = (OperationResult)controller.RemoveAdoption(guid1).Data;

            Assert.IsFalse(result.Success);
            Assert.IsNotEmpty(result.Message);
        }
    }
}
