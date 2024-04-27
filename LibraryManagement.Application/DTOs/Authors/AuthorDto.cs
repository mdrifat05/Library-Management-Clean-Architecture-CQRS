using LibraryManagement.Application.DTOs.Common;

namespace LibraryManagement.Application.DTOs.Authors;

public class AuthorDto : BaseDto
{
    public string AuthorName { get; set; }
    public string AuthorBio { get; set; }
}
