using AutoMapper;
using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Request;
using HisabPro.Entities.IEntities;
using HisabPro.Repository.Interfaces;

namespace HisabPro.Repository
{
    public class UpdateRepository<T, TDto> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public UpdateRepository(IRepository<T> repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<TDto> SaveAsync(T entity, string name, int? id = null, bool useFallback = false)
        {
            // Check if Name already exists
            if (await _repository.ExistsAsync(name, id))
            {
                throw new CustomValidationException(SharedResource.LabelApiDataWithSameName);
                //throw new ValidationException(AppConst.ApiMessage.DataWithSameName);
            }
            else if (id.HasValue)
            {
                // Update entity
                var updatedEntity = await _repository.UpdateAsync(entity);
                var dto = _mapper.Map<TDto>(updatedEntity);
                SetAuditProperties(dto, DBOperationEnum.Update);
                return dto;
            }
            else
            {
                // Add new entity
                var addedEntity = await _repository.AddAsync(entity, useFallback);
                var dto = _mapper.Map<TDto>(addedEntity);
                SetAuditProperties(dto, DBOperationEnum.Add);
                return dto;
            }
        }

        private void SetAuditProperties(TDto dto, DBOperationEnum dbOperation)
        {
            var currentTime = DateTime.UtcNow;
            // Get the logged-in user's name
            var currentUser = _userContext.GetCurrentUserName();

            string auditProperty = dbOperation == DBOperationEnum.Add ? "Created" : "Modified";
            typeof(TDto).GetProperty($"{auditProperty}On")?.SetValue(dto, currentTime);
            typeof(TDto).GetProperty($"{auditProperty}By")?.SetValue(dto, currentUser);
        }
    }
}
