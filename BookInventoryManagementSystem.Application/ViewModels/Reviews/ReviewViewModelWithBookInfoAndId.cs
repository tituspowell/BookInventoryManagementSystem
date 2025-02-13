namespace BookInventoryManagementSystem.Application.ViewModels.Reviews;

public class ReviewViewModelWithBookInfoAndId : ReviewViewModelWithBookInfo
{
    [Required]
    public int Id { get; set; }
}
