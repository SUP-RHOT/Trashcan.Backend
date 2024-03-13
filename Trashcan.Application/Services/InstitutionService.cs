using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.DAL.Repositories;
using Trashcan.Domain.Dto.InstitutionDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;


namespace Trashcan.Application.Services
{
    /// <inheritdoc />
    public class InstitutionService : IInstitutionService
    {
        private readonly BaseRepository<Institution> _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public InstitutionService(BaseRepository<Institution> repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<BaseResult<InstitutionDto>> CreateInstitutionAsync(InstitutionDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return new BaseResult<InstitutionDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.CreateAsync(_mapper.Map<Institution>(dto));

                return new BaseResult<InstitutionDto>()
                {
                    Data = dto
                };

            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<InstitutionDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<InstitutionDto>> DeleteInstitutionAsync(int id)
        {
            try
            {
                var eventToDelete = await _repository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToDelete == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<InstitutionDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.RemoveAsync(eventToDelete);

                return new BaseResult<InstitutionDto>()
                {
                    Data = _mapper.Map<InstitutionDto>(eventToDelete)
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<InstitutionDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<InstitutionDto>> GetInstitutionByIdAsync(int id)
        {
            try
            {
                var eventToGet = await _repository.GetAll()
                    .Select(x => _mapper.Map<InstitutionDto>(x))
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToGet == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<InstitutionDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new BaseResult<InstitutionDto>()
                {
                    Data = eventToGet
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<InstitutionDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<CollectionResult<InstitutionDto>> GetInstitutionsAsync()
        {
            try
            {
                var events = await _repository.GetAll()
                    .Select(x => _mapper.Map<InstitutionDto>(x))
                    .ToArrayAsync();

                if (!events.Any())
                {
                    _logger.Warning(ErrorMessage.DataNotFount, events.Length);
                    return new CollectionResult<InstitutionDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new CollectionResult<InstitutionDto>()
                {
                    Data = events,
                    Count = events.Length
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new CollectionResult<InstitutionDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<InstitutionDto>> UpdateInstitutionAsync(InstitutionDto dto)
        {
            try
            {
                var eventToUpdate = await _repository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == dto.Id);

                if (eventToUpdate == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, dto.Id);
                    return new BaseResult<InstitutionDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.UpdateAsync(_mapper.Map<Institution>(dto));

                return new BaseResult<InstitutionDto>()
                {
                    Data = dto
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<InstitutionDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }
    }
}
