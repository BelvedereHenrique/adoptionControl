using Moq;
using System;
using System.Linq;
using NUnit.Framework;
using Desafio.Contracts;
using Desafio.Services.Animal;
using Desafio.Services.Adopter;
using Desafio.Services.Adoption;
using System.Collections.Generic;
using Desafio.Repository.Adoption;

namespace Desafio.Services.Tests
{
    [TestFixture]
    public class AdoptionRepositoryTests
    {
        public Mock<IAdoptionRepository> GetMockedAdoptionRepository()
        {
            return new Mock<IAdoptionRepository>();
        }
        public Mock<IAnimalService> GetMockedAnimalService()
        {
            return new Mock<IAnimalService>();
        }
        public Mock<IAdopterService> GetMockedAdopterService()
        {
            return new Mock<IAdopterService>();
        }
        private static OperationResult<List<AnimalContract>> GetAnimalOperationResultList(Guid adopterID, Guid animalGuid)
        {
            return new OperationResult<List<AnimalContract>>(
                true,
                "Success",
                new List<AnimalContract>()
                {
                    new AnimalContract()
                    {
                        ID = animalGuid,
                        AdoptedBy = adopterID
                    }
                });
        }

        [Test]
        public void GetAll_Success()
        {
            var animalServ = GetMockedAnimalService();
            var adopterServ = GetMockedAdopterService();

            var animalGuid = Guid.NewGuid();
            var adopterGuid = Guid.NewGuid();

            animalServ.Setup(x => x.GetAll()).Returns(GetAnimalOperationResultList(adopterGuid, animalGuid));
            adopterServ.Setup(x => x.Get(adopterGuid)).Returns(new OperationResult<AdopterContract>(true, "Success", new AdopterContract() { ID = adopterGuid }));

            var service = new AdoptionService(null, animalServ.Object, adopterServ.Object);
            var result = service.GetAll();
            Assert.Greater(result.Result.Count, 0);
            var adoption = result.Result.First();
            Assert.AreEqual(adoption.Animal.AdoptedBy, adoption.Adopter.ID);
            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void GetAll_Success_NoResults()
        {
            var animalServ = GetMockedAnimalService();

            animalServ.Setup(x => x.GetAll()).Returns(new OperationResult<List<AnimalContract>>(true,"Success", new List<AnimalContract>()));

            var service = new AdoptionService(null, animalServ.Object,null);
            var result = service.GetAll();
            Assert.AreEqual(result.Result.Count,0);
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetAll_Fail_AnimalServiceException()
        {
            var animalServ = GetMockedAnimalService();

            string failMessage = "fail";
            animalServ.Setup(x => x.GetAll()).Throws(new Exception(failMessage));

            var service = new AdoptionService(null, animalServ.Object, null);
            var result = service.GetAll();

            Assert.IsNull(result.Result);
            Assert.False(result.Success);
            Assert.AreEqual(result.Message,failMessage);
        }

        [Test]
        public void GetAll_Fail_AdopterServiceException()
        {
            var animalServ = GetMockedAnimalService();
            var adopterServ = GetMockedAdopterService();

            var animalGuid = Guid.NewGuid();
            var adopterGuid = Guid.NewGuid();

            string failMessage = "fail";
            animalServ.Setup(x => x.GetAll()).Returns(GetAnimalOperationResultList(adopterGuid, animalGuid));

            adopterServ.Setup(x => x.Get(It.IsAny<Guid>())).Throws(new Exception(failMessage));

            var service = new AdoptionService(null, animalServ.Object, adopterServ.Object);
            var result = service.GetAll();

            Assert.IsNull(result.Result);
            Assert.False(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Adopt_Success()
        {
            var repo = GetMockedAdoptionRepository();
            repo.Setup(x => x.Adopt(It.IsAny<Guid>(), It.IsAny<Guid>()));

            var service = new AdoptionService(repo.Object, null, null);
            var result = service.Adopt(Guid.NewGuid(), Guid.NewGuid());

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void Adopt_Fail_InvalidID()
        {
            var repo = GetMockedAdoptionRepository();
            repo.Setup(x => x.Adopt(It.IsAny<Guid>(), It.IsAny<Guid>()));

            string failMessage = "Invalid ID.";

            var service = new AdoptionService(repo.Object, null, null);
            var result = service.Adopt(Guid.Empty, Guid.Empty);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void Adopt_Fail_AdoptRepositoryException()
        {
            var repo = GetMockedAdoptionRepository();

            string failMessage = "Invalid ID.";
            repo.Setup(x => x.Adopt(It.IsAny<Guid>(), It.IsAny<Guid>())).Throws(new Exception(failMessage));
            var service = new AdoptionService(repo.Object, null, null);
            var result = service.Adopt(Guid.NewGuid(), Guid.NewGuid());

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void CancelAdoption_Success()
        {
            var animalService = GetMockedAnimalService();
            animalService.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new OperationResult<AnimalContract>(true,"Success",new AnimalContract() { }));

            var service = new AdoptionService(null, animalService.Object, null);
            var result = service.CancelAdoption(Guid.NewGuid());

            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void CancelAdoption_Fail_InvalidID()
        {
            var animalService = GetMockedAnimalService();

            string failMessage = "InvalidID.";

            var service = new AdoptionService(null, null, null);
            var result = service.CancelAdoption(Guid.Empty);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void CancelAdoption_Fail_AdoptRepositoryException()
        {
            var animalService = GetMockedAnimalService();

            string failMessage = "Invalid ID.";
            animalService.Setup(x => x.Get(It.IsAny<Guid>())).Throws(new Exception(failMessage));
            var service = new AdoptionService(null,animalService.Object, null);
            var result = service.CancelAdoption(Guid.NewGuid());

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

        [Test]
        public void GetFreeAnimals_Success()
        {
            var animalService = GetMockedAnimalService();

            var animalGuid = Guid.NewGuid();
            var adopterGuid = Guid.NewGuid();
            
            animalService.Setup(x => x.GetAll()).Returns(new OperationResult<List<AnimalContract>>(true,"Success", new List<AnimalContract>() { new AnimalContract() {ID = animalGuid } }));

            var service = new AdoptionService(null, animalService.Object, null);
            var result = service.GetFreeAnimals();

            Assert.IsNull(result.Result.First().AdoptedBy);
            Assert.Greater(result.Result.Count,0);
            Assert.IsTrue(result.Success);
            Assert.IsNotEmpty(result.Message);
        }


        [Test]
        public void GetFreeAnimals_Fail_AnimalRepositoryException()
        {
            var animalService = GetMockedAnimalService();

            string failMessage = "fail";
            animalService.Setup(x => x.GetAll()).Throws(new Exception(failMessage));
            var service = new AdoptionService(null, animalService.Object, null);
            var result = service.GetAll();

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, failMessage);
        }

    }
}
