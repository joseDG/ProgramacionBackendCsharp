using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private BeerRepository _beerRepository;
        private IMapper _mapper;

        public List<string> Errors { get; }

        public BeerService(BeerRepository beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        //Get all
        public async Task<IEnumerable<BeerDto>> GetAllAsync()
        {
            var beers = await _beerRepository.Get();

            return beers.Select(b => _mapper.Map<BeerDto>(b));
        }

        //Get por Id
        public async Task<BeerDto> GetByIdAsync(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);
                return beerDto;
            }

            return null;
        }

        //Create
        public async Task<BeerDto> CreateAsync(BeerInsertDto beerInsertDto)
        {
            var beer = _mapper.Map<Beer>(beerInsertDto);

            await _beerRepository.Create(beer);
            await _beerRepository.Save();

            var beerDto = _mapper.Map<BeerDto>(beer);

            return beerDto;
        }

        //Update
        public async Task<BeerDto> UpdateAsync(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                beer = _mapper.Map<BeerUpdateDto, Beer>(beerUpdateDto, beer);

                _beerRepository.Update(beer);
                await _beerRepository.Save();

                var beerDto = _mapper.Map<BeerDto>(beer);

                return beerDto;
            }

            return null;
        }

        //Delete
        public async Task<BeerDto> DeleteAsync(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);

                _beerRepository.Delete(beer);
                await _beerRepository.Save();

                return beerDto;
            }

            return null;
        }

        //Validaciones
        public bool Validate(BeerInsertDto beerInsertDto)
        {
            if (_beerRepository.Search(b => b.Name == beerInsertDto.Name).Count() > 0)
            {
                Errors.Add("No puedo existir el nombre de una cerveza ya existente");
                return false;
            }
            return true;
        }

        public bool Validate(BeerUpdateDto beerUpdateDto)
        {
            if (_beerRepository.Search(b => b.Name == beerUpdateDto.Name &&
            beerUpdateDto.Id != b.BeerID).Count() > 0)
            {
                Errors.Add("No puedo existir el nombre de una cerveza ya existente");
                return false;
            }
            return true;
        }
    }
}
