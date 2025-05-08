using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private StoreContext _context;

        public BeerService(StoreContext storeContext)
        {
            _context = storeContext;
        }

        //Get all
        public async Task<IEnumerable<BeerDto>> GetAllAsync() =>
            await _context.Beers.Select(b => new BeerDto
            {
                Id = b.BeerID,
                Name = b.Name,
                Alcohol = b.Alcohol,
                BrandID = b.BrandID
            }).ToListAsync();

        //Get por Id
        public async Task<BeerDto> GetByIdAsync(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer != null)
            {
                return new BeerDto
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };
            }

            return null;
        }

        //Create
        public async Task<BeerDto> CreateAsync(BeerInsertDto beerInsertDto)
        {
            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                BrandID = beerInsertDto.BrandID,
                Alcohol = beerInsertDto.Alcohol
            };

            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };

            return beerDto;
        }

        //Update
        public async Task<BeerDto> UpdateAsync(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _context.Beers.FindAsync(id);

            if(beer != null)
            {
                beer.Name = beerUpdateDto.Name;
                beer.Alcohol = beerUpdateDto.Alcohol;
                beer.BrandID = beer.BrandID;
                await _context.SaveChangesAsync();

                var beerDto = new BeerDto
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };

                return beerDto;
            }

            return null;
        }

        //Delete
        public async Task<BeerDto> DeleteAsync(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };

                _context.Remove(beer);
                await _context.SaveChangesAsync();

                return beerDto;
            }

            return null;
        }
    }
}
