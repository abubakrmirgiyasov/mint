using Mint.Domain.Models;

namespace Mint.Domain.ViewModels;

public class BrandViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public List<Photo>? Photos { get; set; }
}
