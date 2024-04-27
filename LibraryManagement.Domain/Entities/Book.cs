using LibraryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities;

public sealed class Book : BaseDomainEntity
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedDate { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalCopies { get; set; }

    // Navigation Properties
    public int AuthorID { get; set; }
    public Author Author { get; set; }

}
