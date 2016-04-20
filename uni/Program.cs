using Logging;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace uni
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Presenter p = new Presenter();
                App app = new App();
                app.Run();
            }
            catch (Exception x)
            {
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
                ILog log = kernel.Get<ILog>();
                log.Write(x);

                MessageBox.Show(x.Message);
            }
        }
    }
}
