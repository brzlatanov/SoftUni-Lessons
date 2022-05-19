using System;
using System.Collections.Generic;
using System.Text;

namespace Phones
{
    public interface ISmartPhoneCall
    {
        void Call(string number);
        void Browse(string website);
    }
}
