using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using Logging;

namespace uni
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log>();
        }
    }
}
