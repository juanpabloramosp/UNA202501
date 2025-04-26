namespace BackEnd.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public CategoryDTO? Category { get; set; }



        public bool Discontinued { get; set; }

    }
}
