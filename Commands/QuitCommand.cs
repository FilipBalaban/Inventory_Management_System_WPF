using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory_Management_System_WPF.Commands
{
    public class QuitCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show("You have exited the application. Implement yes and no!");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
