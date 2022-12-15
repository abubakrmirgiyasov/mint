namespace Mint.Domain.BindingModels
{
    public class SubCategoryBindingModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public Guid? CategoryId { get; set; }

        public List<PhotoBindingModel>? Photos { get; set; }
    }
}
