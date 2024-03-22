using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.DAL.Repositories;
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
    private readonly BaseRepository<AddressBase> _addressBaseRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public AddressService(BaseRepository<Address> repository, BaseRepository<AddressBase> addressBaseRepository, ILogger logger, IMapper mapper)
    {
        _repository = repository;
        _addressBaseRepository = addressBaseRepository;
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

            if (await AddressContainsInBase(dto))
            {
                await _repository.CreateAsync(_mapper.Map<Address>(dto));

                return new BaseResult<AddressDto>()
                {
                    Data = dto
                };
            }

            return new BaseResult<AddressDto>()
            {
                ErrorMassage = ErrorMessage.AddressNotSupported,
                ErrorCode = (int)ErrorCode.AddressNotSupported
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

            if (await AddressContainsInBase(dto))
            {
                await _repository.UpdateAsync(_mapper.Map<Address>(dto));

                return new BaseResult<AddressDto>()
                {
                    Data = dto
                };
            }

            return new BaseResult<AddressDto>()
            {
                ErrorMassage = ErrorMessage.AddressNotSupported,
                ErrorCode = (int)ErrorCode.AddressNotSupported
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
    public async Task<BaseResult<AddressDto>> GetAddressByCoordinates(float longitude, float width)
    {
        try
        {
            var address = await _repository.GetAll()
                .Select(x => _mapper.Map<AddressDto>(x))
                .FirstOrDefaultAsync(x => x.Longitude == longitude && x.Width == width);

            if (address == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, longitude, width);
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
    public async Task<BaseResult<AddressDto>> GetAddressByLocation(string city, string street, string house)
    {
        try
        {
            var address = await _repository.GetAll()
                .Select(x => _mapper.Map<AddressDto>(x))
                .FirstOrDefaultAsync(x => x.City == city && x.Street == street && x.House == house);

            if (address == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, city, street,house);
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

    /// <summary>
    /// Проверка наличия адреса в базе адресов.
    /// </summary>
    /// <param name="dto"> Адрес для проверки. </param>
    /// <returns> True, если адрес найден, иначе false. </returns>
    private async Task<bool> AddressContainsInBase(AddressDto dto)
    {
        try
        {
            var addressBase = await _addressBaseRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Longitude == dto.Longitude
                                        && x.Width == dto.Width
                                        && x.City == dto.City
                                        && x.Street == dto.Street
                                        && x.House == dto.House);

            return addressBase != null;
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return false;
        }
    }
}
