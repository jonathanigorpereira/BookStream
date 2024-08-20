using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStream.Core.Entities;
public class BookGenre : BaseEntity
{
    public BookGenre(string genre) : base()
    {
        Genre = genre;
    }

    public string Genre { get; private set; }
}
