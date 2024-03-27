using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.DAL.Repositories;
using Trashcan.Domain.Dto.RubricDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.BaseRepository;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;


namespace Trashcan.Application.Services
{
    /// <inheritdoc />
    public class RubricService : IRubricService
    {
        private readonly IBaseRepository<Rubric> _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public RubricService(IBaseRepository<Rubric> repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<BaseResult<RubricDto>> CreateRubricAsync(RubricDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return new BaseResult<RubricDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.CreateAsync(_mapper.Map<Rubric>(dto));

                return new BaseResult<RubricDto>()
                {
                    Data = dto
                };

            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<RubricDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<RubricDto>> DeleteRubricAsync(int id)
        {
            try
            {
                var eventToDelete = await _repository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToDelete == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<RubricDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.RemoveAsync(eventToDelete);

                return new BaseResult<RubricDto>()
                {
                    Data = _mapper.Map<RubricDto>(eventToDelete)
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<RubricDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<RubricDto>> GetRubricByIdAsync(int id)
        {
            try
            {
                var eventToGet = await _repository.GetAll()
                    .Select(x => _mapper.Map<RubricDto>(x))
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToGet == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<RubricDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new BaseResult<RubricDto>()
                {
                    Data = eventToGet
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<RubricDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<CollectionResult<RubricDto>> GetRubricsAsync()
        {
            try
            {
                var events = await _repository.GetAll()
                    .Select(x => _mapper.Map<RubricDto>(x))
                    .ToArrayAsync();

                if (!events.Any())
                {
                    _logger.Warning(ErrorMessage.DataNotFount, events.Length);
                    return new CollectionResult<RubricDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new CollectionResult<RubricDto>()
                {
                    Data = events,
                    Count = events.Length
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new CollectionResult<RubricDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<RubricDto>> UpdateRubricAsync(RubricDto dto)
        {
            try
            {
                var eventToUpdate = await _repository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == dto.Id);

                if (eventToUpdate == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, dto.Id);
                    return new BaseResult<RubricDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.UpdateAsync(_mapper.Map<Rubric>(dto));

                return new BaseResult<RubricDto>()
                {
                    Data = dto
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<RubricDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }
    }
}
