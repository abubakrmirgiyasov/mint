using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Domain.ViewModels;

public class BrandViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public List<CategoryViewModel>? Categories { get; set; }

    public List<PhotoBindingModel>? Photos { get; set; }
}
