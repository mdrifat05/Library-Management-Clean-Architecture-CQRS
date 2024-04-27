using LibraryManagement.Application.DTOs.Common;

namespace LibraryManagement.Application.DTOs.Authors;

public class UpdateAuthorDto : BaseDto
{
    public string AuthorName { get; set; }
    public string AuthorBio { get; set; }
}
