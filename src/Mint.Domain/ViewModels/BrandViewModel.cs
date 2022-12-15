using Mint.Domain.BindingModels;

namespace Mint.Domain.ViewModels;

public class BrandViewModel
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public List<PhotoBindingModel>? Photos { get; set; }
}
