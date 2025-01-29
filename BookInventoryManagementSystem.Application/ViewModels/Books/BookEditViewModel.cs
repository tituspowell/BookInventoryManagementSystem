namespace BookInventoryManagementSystem.Application.ViewModels.Books;

public class BookEditViewModel : BookBaseFieldsViewModel
{
    [Required]
    public required int Id { get; set; }
}
