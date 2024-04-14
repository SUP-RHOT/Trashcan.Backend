using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.Domain.Dto.TemplateDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.BaseRepository;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;


namespace Trashcan.Application.Services
{
    /// <inheritdoc />
    public class TemplateService : ITemplateService
    {
        private readonly IBaseRepository<Template> _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public TemplateService(IBaseRepository<Template> repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<BaseResult<TemplateDto>> CreateTemplateAsync(TemplateDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return new BaseResult<TemplateDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.CreateAsync(_mapper.Map<Template>(dto));

                return new BaseResult<TemplateDto>()
                {
                    Data = dto
                };

            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<TemplateDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<TemplateDto>> DeleteTemplateAsync(int id)
        {
            try
            {
                var eventToDelete = await _repository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToDelete == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<TemplateDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.RemoveAsync(eventToDelete);

                return new BaseResult<TemplateDto>()
                {
                    Data = _mapper.Map<TemplateDto>(eventToDelete)
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<TemplateDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<TemplateDto>> GetTemplateByIdAsync(int id)
        {
            try
            {
                var eventToGet = await _repository.GetAll()
                    .Select(x => _mapper.Map<TemplateDto>(x))
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToGet == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<TemplateDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new BaseResult<TemplateDto>()
                {
                    Data = eventToGet
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<TemplateDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<CollectionResult<TemplateDto>> GetTemplatesAsync()
        {
            try
            {
                var events = await _repository.GetAll()
                    .Select(x => _mapper.Map<TemplateDto>(x))
                    .ToArrayAsync();

                if (!events.Any())
                {
                    _logger.Warning(ErrorMessage.DataNotFount, events.Length);
                    return new CollectionResult<TemplateDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new CollectionResult<TemplateDto>()
                {
                    Data = events,
                    Count = events.Length
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new CollectionResult<TemplateDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<TemplateDto>> UpdateTemplateAsync(TemplateDto dto)
        {
            try
            {
                var eventToUpdate = await _repository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == dto.Id);

                if (eventToUpdate == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, dto.Id);
                    return new BaseResult<TemplateDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.UpdateAsync(_mapper.Map<Template>(dto));

                return new BaseResult<TemplateDto>()
                {
                    Data = dto
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<TemplateDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }
    }
}