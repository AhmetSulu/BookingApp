using BookingApp.Business.Operations.Feature.Dtos;
using BookingApp.Business.Types;
using BookingApp.Data.Entities;
using BookingApp.Data.Repositories;
using BookingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Business.Operations.Feature
{
    public class FeatureManager : IFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<FeatureEntity> _repository;
        public FeatureManager(IUnitOfWork unitOfWork, IRepository<FeatureEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ServiceMessage> AddFeature(AddFeatureDto feature)
        {
            var hasFeature = _repository.GetAll(x => x.Title.ToLower() == feature.Title.ToLower()).Any();

            if (hasFeature)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Özellik zaten bulunuyor."
                };
            }

            var featureEntity = new FeatureEntity
            {
                Title = feature.Title
            };
            _repository.Add(featureEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
              throw new Exception("Özellik eklenirken bir hata oluştu.");
            }
            return new ServiceMessage
            {
                IsSucceed = true
            };
        }
    }
}
 