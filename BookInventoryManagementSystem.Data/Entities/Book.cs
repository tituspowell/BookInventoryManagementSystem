namespace BookInventoryManagementSystem.Data.Entities;

public class Book : BaseEntityWithId
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int PublicationYear { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public string? CoverImageURL { get; set; }
    public string? Tags { get; set; }

    // Review related fields. Calculating these dynamically leads to circular reference problems between books and reviews.
    // As this is a small project, we just store these for each book whenever a review is added or deleted. In a huge dataset,
    // this could impact performance, but it saves creating an extra layer of abstraction with an IBookRatingProvider.
    public float AverageRating { get; set; }
    public int NumberOfReviews { get; set; }
}
