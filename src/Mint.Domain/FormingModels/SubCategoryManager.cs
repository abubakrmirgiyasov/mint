using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels
{
    public class SubCategoryManager
    {
        public List<SubCategoryViewModel> FormingViewModels(List<SubCategory>? subCategories)
        {
            try
            {
                if (subCategories != null)
                {
                    var subCategoriesViewModel = new List<SubCategoryViewModel>();

                    foreach (var subCategory in subCategories)
                    {
                        subCategoriesViewModel.Add(new SubCategoryViewModel()
                        {
                            Id = subCategory.Id,
                            Name = subCategory.Name,
                            Photos = new PhotoManager().FormingViewModels(subCategory.Photos?.ToList()),
                        });
                    }
                    return subCategoriesViewModel;
                }
                return null!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
