namespace ShopManagement.Application.Contracts.SubProductCategory
{
    public class SubProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string ShortDescription { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
        public long CategoryId { get; set; }
    }
}