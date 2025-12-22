using CatMS.Data;
using CatMS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CatMS.Repositorys;

public class CatRepository : ICatRepository
{
    private readonly ApplicationDbContext _context;
    public CatRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Cat> AddCatAsync(Cat cat)
    {
        await _context.Cats.AddAsync(cat);
        await _context.SaveChangesAsync();
        return cat;
    }

    public async Task<Cat> DeleteCatAsync(int id)
    {
        var data = await _context.Cats.FindAsync(id);
        if (data != null)
        {
            _context.Cats.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return null;
    }

    public async Task<IEnumerable<Cat>> GetAllCatsAsync()
    {
        return await _context.Cats.ToListAsync();
      
    }

    public async Task<Cat> GetByUrlHandleAsync(string urlHandle)
    {
        var data = await _context.Cats.FirstOrDefaultAsync(x => x.ImageUrl == urlHandle);
        return data;
    }

    public async Task<Cat> GetCatByIdAsync(int id)
    {

        return await _context.Cats.FirstOrDefaultAsync(x => x.Id == id);
    
    }

    public async Task<HomeViewModel> GetHomeViewDetals(int CatId)
    {
        var data = await _context.Cats
            .Include(c => c.Seller)
            .Where(c => c.Id == CatId)
            .Select(c => new HomeViewModel
            {// Cat info
                CatId = c.Id,
                Name = c.Name,
                Breed = c.Breed,
                Age = c.Age,
                Gender = c.Gender,
                Price = c.Price,
                Color = c.Color,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
                PostedDate = c.PostedDate,
                // Seller info

                SellerName = c.Seller.FullName,
                SellerEmail = c.Seller.Email,
                SellerPhone = c.Seller.Phone,
                SellerAddress = c.Seller.Address
            }
            ).FirstOrDefaultAsync();
        return data;
    }

    public async Task<List<HomeViewModel>> GetHomeViewModelCat()
    {
        var data = await _context.Cats
       .Include(c => c.Seller)
       .Select(c => new HomeViewModel
       {
           // Cat info
           CatId = c.Id,
           Name = c.Name,
           Breed = c.Breed,
           Age = c.Age,
           Gender = c.Gender,
           Price = c.Price,
           Color = c.Color,
           Description = c.Description,
           ImageUrl = c.ImageUrl,
           PostedDate = c.PostedDate,

           // Seller info
          
           SellerName = c.Seller.FullName,
           SellerEmail = c.Seller.Email,
           SellerPhone = c.Seller.Phone,
           SellerAddress = c.Seller.Address
       })
       .ToListAsync();

        return data;
    }

    public async Task<Cat> UpdateCatAsync(Cat cat)
    {
        var data = await _context.Cats.FirstOrDefaultAsync(x => x.Id == cat.Id);
       
        if (data != null)
        {
            data.Name = cat.Name;
            data.Breed = cat.Breed;
            data.Age = cat.Age;
            data.Gender = cat.Gender;
            data.Price = cat.Price;
            data.Color = cat.Color;
            data.Description = cat.Description;
            data.ImageUrl = cat.ImageUrl;
            data.PostedDate = cat.PostedDate;
            _context.Cats.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return null;
    }
}
