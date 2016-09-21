using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface IDeck : IList<ICard>, IShuffable<ICard>
    {
    }
}
