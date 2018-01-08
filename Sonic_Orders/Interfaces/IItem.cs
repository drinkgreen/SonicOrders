using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SONIC_Orders.Interfaces
{
    public interface IItem
    {
        int Key();

        string Name();

        double Price();

        string ItemType();
             
    }
}
