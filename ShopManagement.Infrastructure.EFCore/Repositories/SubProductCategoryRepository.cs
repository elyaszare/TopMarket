using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.SubProductCategory;
using ShopManagement.Domain.SubProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class SubProductCategoryRepository : RepositoryBase<long, SubProductCategory>, ISubProductCategoryRepository
    {
        private readonly ShopContext _context;

        public SubProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSubProductCategory GetDetails(long id)
        {
            return _context.SubProductCategories.Select(x => new EditSubProductCategory
            {
                Id = x.Id,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                CategoryId = x.CategoryId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<SubProductCategoryViewModel> GetSubProductCategories()
        {
            return _context.SubProductCategories.Select(x => new SubProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();
        }

        public SubProductCategory GetSlugBy(long id)
        {
            return _context.SubProductCategories.Include(x => x.ProductCategory).FirstOrDefault(x => x.Id == id);
        }

        public SubProductCategory GetSubCategoryWithCategorySlugBy(long id)
        {
            return _context.SubProductCategories.Include(x => x.ProductCategory).FirstOrDefault(x => x.Id == id);
        }

        public List<SubProductCategoryViewModel> Search(SubProductCategorySearchModel searchModel)
        {
            var query = _context.SubProductCategories.Include(x => x.ProductCategory).Select(x =>
                new SubProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    IsRemoved = x.IsRemoved,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,
                    CategoryName = x.ProductCategory.Name,
                    CategoryId = x.CategoryId
                }).AsEnumerable();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
