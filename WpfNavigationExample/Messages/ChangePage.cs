using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace WpfNavigationExample.Messages
{
    public class ChangePage
    {
        public Type ViewModelType { get; private set; }

        public ChangePage(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
