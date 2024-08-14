namespace WebApplication1.Models
{
    public class Expense
    {
        // the properties that will be stored in the database
        public int Id { get; set; }

        public int value { get; set; }

        public string? Description { get; set; }   //make it null by giving '?' since it is a string
    }
}
