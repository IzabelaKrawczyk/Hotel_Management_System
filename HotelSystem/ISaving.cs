using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{
    interface ISaving
    {
        void WriteBIN(string nazwa);
        object ReadBIN(string nazwa);
    }
}
