namespace BookInventoryManagementSystem.Application.ViewModels.Books;

public class BookIndexViewModel : BookBaseFieldsViewModel
{
    // ID used not for display but as a hidden field for Edit and Delete actions
    [Required]
    public required int Id { get; set; }
}
