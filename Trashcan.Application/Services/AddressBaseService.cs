using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.Domain.Dto.AddressBaseDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.BaseRepository;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Application.Services;

/// <inheritdoc />
internal class AddressBaseService : IAddressBaseService
{
    private readonly IBaseRepository<AddressBase> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public AddressBaseService(IBaseRepository<AddressBase> repository, ILogger logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<BaseResult<AddressBaseDto>> CreateBaseAddressAsync(AddressBaseDto dto)
    {
        try
        {
            if (dto == null)
            {
                return new BaseResult<AddressBaseDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            await _repository.CreateAsync(_mapper.Map<AddressBase>(dto));

            return new BaseResult<AddressBaseDto>()
            {
                Data = dto
            };

        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<AddressBaseDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<AddressBaseDto>> DeleteBaseAddressAsync(int id)
    {
        try
        {
            var addressBase = await _repository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (addressBase == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, id);
                return new BaseResult<AddressBaseDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            await _repository.RemoveAsync(addressBase);

            return new BaseResult<AddressBaseDto>()
            {
                Data = _mapper.Map<AddressBaseDto>(addressBase)
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<AddressBaseDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<AddressBaseDto>> GetBaseAddressByIdAsync(int id)
    {
        try
        {
            var addressBase = await _repository.GetAll()
                .Select(x => _mapper.Map<AddressBaseDto>(x))
                .FirstOrDefaultAsync(x => x.Id == id);

            if (addressBase == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, id);
                return new BaseResult<AddressBaseDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            return new BaseResult<AddressBaseDto>()
            {
                Data = addressBase
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<AddressBaseDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<CollectionResult<AddressBaseDto>> GetBaseAddressesAsync()
    {
        try
        {
            var addressesBase = await _repository.GetAll()
                .Select(x => _mapper.Map<AddressBaseDto>(x))
                .ToArrayAsync();

            if (!addressesBase.Any())
            {
                _logger.Warning(ErrorMessage.DataNotFount, addressesBase.Length);
                return new CollectionResult<AddressBaseDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            return new CollectionResult<AddressBaseDto>()
            {
                Data = addressesBase,
                Count = addressesBase.Length
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new CollectionResult<AddressBaseDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<AddressBaseDto>> UpdateBaseAddressAsync(AddressBaseDto dto)
    {
        try
        {
            var addressBase = await _repository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (addressBase == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, dto.Id);
                return new BaseResult<AddressBaseDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            await _repository.UpdateAsync(_mapper.Map<AddressBase>(dto));

            return new BaseResult<AddressBaseDto>()
            {
                Data = dto
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<AddressBaseDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }
}