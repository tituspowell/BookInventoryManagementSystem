﻿namespace BookInventoryManagementSystem.Application.ViewModels.Reviews;

public class ReviewViewModelWithBookInfo : ReviewViewModel
{
    // Extra information about the associated book
    public required string BookTitle { get; set; }
    public required string BookAuthor { get; set; }
    public required string ReviewerName { get; set; }
    public required bool ReviewIsByLoggedInUser { get; set; }
    public DateTime CreatedAt { get; set; }
}
