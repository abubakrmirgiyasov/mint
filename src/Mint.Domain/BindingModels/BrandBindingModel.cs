namespace Mint.Domain.BindingModels;

public class BrandBindingModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public List<PhotoBindingModel> Photos { get; set; } = null!;
}
