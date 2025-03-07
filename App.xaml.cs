using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.Stores;
using Inventory_Management_System_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory_Management_System_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Inventory _inventory;
        private NavigationStore _navigationStore = new NavigationStore();

        protected override void OnStartup(StartupEventArgs e)
        {
            _inventory = new Inventory();
            _navigationStore.CurrentViewModel = CreateMainMenuViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }

        private MainMenuViewModel CreateMainMenuViewModel()
        {
            return new MainMenuViewModel(_inventory, _navigationStore, CreateAddProductViewModel, CreateRemoveProductViewModel, CreateBrowseProductsViewModel);
        }
        private AddProductViewModel CreateAddProductViewModel()
        {
            return new AddProductViewModel(_inventory, _navigationStore, CreateMainMenuViewModel);
        }
        private RemoveProductViewModel CreateRemoveProductViewModel()
        {
            return new RemoveProductViewModel(_inventory, _navigationStore, CreateMainMenuViewModel);
        }
        private BrowseProductsViewModel CreateBrowseProductsViewModel()
        {
            return new BrowseProductsViewModel(_inventory, _navigationStore, CreateMainMenuViewModel);
        }
    }
}
