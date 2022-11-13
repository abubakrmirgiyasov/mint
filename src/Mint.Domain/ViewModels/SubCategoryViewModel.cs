using Mint.Domain.BindingModels;

namespace Mint.Domain.ViewModels
{
    public class SubCategoryViewModel
    {
        public string? Name { get; set; }

        public Guid? CategoryId { get; set; }

        public List<PhotoBindingModel>? Photos { get; set; }
    }
}
