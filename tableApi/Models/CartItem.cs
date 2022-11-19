
namespace tableApi.Models
{
    public class CartItem
    {
        public decimal? ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }

        public CartItem()
        {
        }

        public CartItem(Plato product)
        {
            ProductId = product.Idplato;
            ProductName = product.Nombreplato;
            Price = product.Valorplato;
            Quantity = 1;
            //Image = product.Image;
        }

    }

}
