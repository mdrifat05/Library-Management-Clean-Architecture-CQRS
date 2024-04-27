using LibraryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities;

public sealed class Author : BaseDomainEntity
{
    public string AuthorName { get; set; }
    public string AuthorBio { get; set; }
}
