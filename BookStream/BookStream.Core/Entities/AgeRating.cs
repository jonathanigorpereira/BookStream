using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStream.Core.Entities;
public class AgeRating : BaseEntity
{
    public AgeRating(string description)
        :base()
    {
        Description = description;
    }

    public string Description { get; private set; }
}
