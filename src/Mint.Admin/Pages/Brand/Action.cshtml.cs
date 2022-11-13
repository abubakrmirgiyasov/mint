using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mint.Admin.Services;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Admin.Pages.Category
{
    public class ActionModel : PageModel
    {
        public BrandViewModel? BrandViewModel { get; set; }

        private readonly IBrandRequest _brand;

        public ActionModel(IBrandRequest brand)
        {
            _brand = brand;
        }

        public async Task OnGet()
        {
            //if (HttpContext.IsAuthenticated())
            //{

            ViewData["Categories"] = new CategoryManager().FormingViewModels(await _brand.GetCategoriesAsync());
             
            BrandViewModel = Guid.TryParse(HttpContext.Request.Query["id"].ToString(), out Guid newId) ?
                new BrandManager().FormingViewModel(await _brand.GetBrandByIdAsync(newId)) :
                null!;
            //}
        }

        public async Task OnPost()
        {
            try
            {
                var id = HttpContext.Request.Query["id"].ToString();
                var brand = HttpContext.Request.Form["BrandName"];
                var categories = HttpContext.Request.Form["CategoryName"].ToArray();
                var subCategories = HttpContext.Request.Form["SubCategoryName"].ToArray();
                var files = await new PhotoManager().AddPhotoAsync(HttpContext.Request.Form.Files);

                var brandBindingModel = new BrandBindingModel()
                {
                    Name = brand,
                    Categories = new List<CategoryBindingModel>(),
                    Photos = files.Where(x => x.Name == "BrandFile").ToList(),
                };

                for (int i = 0; i < categories.Length; i++)
                {
                    brandBindingModel.Categories.Add(new CategoryBindingModel()
                    {
                        Name = categories[i],
                        Photos = files.Where(x => x.Name == "CategoryFile").ToList(),
                        SubCategories = new List<SubCategoryBindingModel>(),
                        BrandId = brandBindingModel.Id,
                    });

                    for (int j = 0; j < subCategories.Length; j++)
                    {
                        brandBindingModel.Categories[i].SubCategories.Add(new SubCategoryBindingModel()
                        {
                            Name = subCategories[j],
                            Photos = files.Where(x => x.Name == "SubCategoryFile").ToList(),
                            CategoryId = brandBindingModel.Categories[i].Id
                        });
                    }
                }

                if (Guid.TryParse(id, out Guid newId))
                {
                    brandBindingModel.Id = newId;
                    await _brand.UpdateBrandAsync(brandBindingModel);
                }
                else
                {
                    brandBindingModel.Id = Guid.NewGuid();
                    await _brand.UpdateBrandAsync(brandBindingModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
