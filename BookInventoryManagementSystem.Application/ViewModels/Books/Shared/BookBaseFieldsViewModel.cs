﻿using System.ComponentModel;

namespace BookInventoryManagementSystem.Application.ViewModels.Books.Shared;

public abstract class BookBaseFieldsViewModel
{
    // All the common fields for a book, excluding ID since that's not always needed in the various view models
    [Required]
    public required string Title { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    [DisplayName("Publication Year")]
    public DateOnly? PublicationYear { get; set; }

    [StringLength(13)]
    public string? ISBN { get; set; }

    [StringLength(50)]
    public string? Genre { get; set; }

    [DisplayName("Cover Image URL")]
    public string? CoverImageURL { get; set; }

    public string? Tags { get; set; }
}
