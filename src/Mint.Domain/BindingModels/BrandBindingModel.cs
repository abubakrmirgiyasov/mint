using Microsoft.AspNetCore.Http;

namespace Mint.Domain.BindingModels;

public class BrandBindingModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public List<CategoryBindingModel> Categories { get; set; } = null!;

    public List<PhotoBindingModel> Photos { get; set; } = null!;
}
