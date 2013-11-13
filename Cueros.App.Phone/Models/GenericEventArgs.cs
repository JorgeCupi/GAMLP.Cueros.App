using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Phone.Models
{
    class GenericEventArgs<T> : EventArgs
    {
        public IList<T> Result { private set; get; }

        public GenericEventArgs(IList<T> result)
        {
            this.Result = result;
        }
    }
}
