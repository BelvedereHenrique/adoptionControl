﻿using System;
using System.Linq;
using Desafio.Contracts;
using System.Collections.Generic;
using Desafio.Repository.Adopter;

namespace Desafio.Services.Adopter
{
    public class AdopterService : IAdopterService
    {
        private readonly IAdopterRepository _adopterRepository;

        public AdopterService(IAdopterRepository adopterRepository)
        {
            _adopterRepository = adopterRepository;
        }

        public OperationResult<AdopterContract> Get(Guid adopter)
        {
            try
            {
                var result = _adopterRepository.Get(adopter);
                return new OperationResult<AdopterContract>(true, "Success.", result);
            }
            catch (Exception e)
            {
                return new OperationResult<AdopterContract>(false, e.Message, null);
            }
        }

        public OperationResult<List<AdopterContract>> GetAll()
        {
            try
            {
                var result = _adopterRepository.GetAll();
                return new OperationResult<List<AdopterContract>>(true, "Success.", result);
            }
            catch (Exception e)
            {
                return new OperationResult<List<AdopterContract>>(false, e.Message, null);
            }
        }

        public OperationResult Add(AdopterContract adopter)
        {
            try
            {
                if (adopter == null)
                    return new OperationResult(false, "Null contract.");

                adopter.ID = Guid.NewGuid();
                adopter.CreatedOn = DateTime.Now;
                _adopterRepository.Add(adopter);
                return new OperationResult(true, "Adopter added.");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }

        public OperationResult Delete(Guid adopterID)
        {
            try
            {
                if (adopterID == Guid.Empty)
                    return new OperationResult(false, "Empty ID.");

                _adopterRepository.Delete(adopterID);
                return new OperationResult(true, "Adopter removed.");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }

        public OperationResult Edit(AdopterContract adopter)
        {
            try
            {
                if (adopter == null)
                    return new OperationResult(false, "Null contract.");

                _adopterRepository.Edit(adopter);
                return new OperationResult(true, "Adopter edited.");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }

    }
}
