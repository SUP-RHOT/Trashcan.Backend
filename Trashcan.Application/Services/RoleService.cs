using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.DAL.Repositories;
using Trashcan.Domain.Dto.RoleDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;


namespace Trashcan.Application.Services
{
    /// <inheritdoc />
    public class RoleService : IRoleService
    {
        private readonly BaseRepository<Role> _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public RoleService(BaseRepository<Role> repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<BaseResult<RoleDto>> CreateRoleAsync(RoleDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return new BaseResult<RoleDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.CreateAsync(_mapper.Map<Role>(dto));

                return new BaseResult<RoleDto>()
                {
                    Data = dto
                };

            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<RoleDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<RoleDto>> DeleteRoleAsync(int id)
        {
            try
            {
                var eventToDelete = await _repository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToDelete == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<RoleDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.RemoveAsync(eventToDelete);

                return new BaseResult<RoleDto>()
                {
                    Data = _mapper.Map<RoleDto>(eventToDelete)
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<RoleDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<RoleDto>> GetRoleByIdAsync(int id)
        {
            try
            {
                var eventToGet = await _repository.GetAll()
                    .Select(x => _mapper.Map<RoleDto>(x))
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToGet == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<RoleDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new BaseResult<RoleDto>()
                {
                    Data = eventToGet
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<RoleDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<CollectionResult<RoleDto>> GetRolesAsync()
        {
            try
            {
                var events = await _repository.GetAll()
                    .Select(x => _mapper.Map<RoleDto>(x))
                    .ToArrayAsync();

                if (!events.Any())
                {
                    _logger.Warning(ErrorMessage.DataNotFount, events.Length);
                    return new CollectionResult<RoleDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new CollectionResult<RoleDto>()
                {
                    Data = events,
                    Count = events.Length
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new CollectionResult<RoleDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<RoleDto>> UpdateRoleAsync(RoleDto dto)
        {
            try
            {
                var eventToUpdate = await _repository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == dto.Id);

                if (eventToUpdate == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, dto.Id);
                    return new BaseResult<RoleDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _repository.UpdateAsync(_mapper.Map<Role>(dto));

                return new BaseResult<RoleDto>()
                {
                    Data = dto
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<RoleDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }
    }
}
