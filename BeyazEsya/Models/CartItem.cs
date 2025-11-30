namespace BeyazEsya.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string CartID { get; set; }
        public int UserID { get; set; } 
        public int ProductID { get; set; }  
        public int Quantity { get; set; }

    }
}
