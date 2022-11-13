namespace Mint.Domain.BindingModels
{
    public class SubCategoryBindingModel
    {
        public string Name { get; set; } = "";

        public Guid CategoryId { get; set; }

        public List<PhotoBindingModel> Photos { get; set; } = null!;
    }
}
