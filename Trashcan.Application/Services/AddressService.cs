using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.DAL.Repositories;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Dto.AddressDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Application.Services;

/// <inheritdoc />
public class AddressService : IAddressService
{
    private readonly BaseRepository<Address> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public AddressService(BaseRepository<Address> repository, ILogger logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<BaseResult<AddressDto>> CreateAddressAsync(AddressDto dto)
    {
        try
        {
            if (dto == null)
            {
                return new BaseResult<AddressDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            await _repository.CreateAsync(_mapper.Map<Address>(dto));

            return new BaseResult<AddressDto>()
            {
                Data = dto
            };

        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<AddressDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<AddressDto>> DeleteAddressAsync(int id)
    {
        try
        {
            var address = await _repository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (address == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, id);
                return new BaseResult<AddressDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            await _repository.RemoveAsync(address);

            return new BaseResult<AddressDto>()
            {
                Data = _mapper.Map<AddressDto>(address)
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<AddressDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<AddressDto>> GetAddressByIdAsync(int id)
    {
        try
        {
            var address = await _repository.GetAll()
                .Select(x => _mapper.Map<AddressDto>(x))
                .FirstOrDefaultAsync(x => x.Id == id);

            if (address == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, id);
                return new BaseResult<AddressDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            return new BaseResult<AddressDto>()
            {
                Data = address
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<AddressDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<CollectionResult<AddressDto>> GetAddressesAsync()
    {
        try
        {
            var addresses = await _repository.GetAll()
                .Select(x => _mapper.Map<AddressDto>(x))
                .ToArrayAsync();

            if (!addresses.Any())
            {
                _logger.Warning(ErrorMessage.DataNotFount, addresses.Length);
                return new CollectionResult<AddressDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            return new CollectionResult<AddressDto>()
            {
                Data = addresses,
                Count = addresses.Length
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new CollectionResult<AddressDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<AddressDto>> UpdateAddressAsync(AddressDto dto)
    {
        try
        {
            var address = await _repository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (address == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, dto.Id);
                return new BaseResult<AddressDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            await _repository.UpdateAsync(_mapper.Map<Address>(dto));

            return new BaseResult<AddressDto>()
            {
                Data = dto
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<AddressDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }
}
