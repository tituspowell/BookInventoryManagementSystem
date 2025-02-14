namespace BookInventoryManagementSystem.Data.Entities;

public class Review : BaseEntityWithId
{
    public required int RatingOutOfFive { get; set; } // Rating could be a float to allow 4.5 for example but we force whole numbers for simplicity
    public required string ReviewText { get; set; }
    public DateTime CreatedAt { get; private set; }

    // Foreign Keys
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public required ApplicationUser Reviewer { get; set; }
    public required string ReviewerId { get; set; }
}
