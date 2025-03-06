using Inventory_Management_System_WPF.Commands;
using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.Stores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inventory_Management_System_WPF.ViewModels
{
    public class AddProductViewModel: BaseViewModel
    {
        #region Fields
        private ProductCategoryEnum _selectedCategory;
        private ProductViewModel _product;
        private readonly Inventory _inventory;
        #endregion

        #region Properites
        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ProductCategoryEnum SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                RaiseOnPropertyChanged(nameof(SelectedCategory));
                GenerateProductObject();
            }
        }
        public List<ProductCategoryEnum> Categories { get; }
        public ProductViewModel Product
        {
            get => _product;
            set
            {
                _product = value;
                RaiseOnPropertyChanged(nameof(Product));
            }
        }

        #endregion

        #region Constructors
        public AddProductViewModel(Inventory inventory, NavigationStore navigationStore, Func<MainMenuViewModel> createMainMenuViewModel)
        {
            Categories = Enum.GetValues(typeof(ProductCategoryEnum)).Cast<ProductCategoryEnum>().ToList();
            AddCommand = new AddProductCommand(_inventory, null);
            CancelCommand = new NavigateCommand(navigationStore, createMainMenuViewModel);
        }
        #endregion

        #region Methods
        private void GenerateProductObject()
        {
            switch (SelectedCategory)
            {
                case ProductCategoryEnum.Electronics:
                    GetElectronicsObjectData();
                    break;
                case ProductCategoryEnum.PerishableGoods:
                    GetPerishableGoodsObjectData();
                    break;
                case ProductCategoryEnum.Clothing:
                    GetClothingObjectData();
                    break;
            }
            Product.Category = SelectedCategory;
            AddCommand = new AddProductCommand(_inventory, Product);
            RaiseOnPropertyChanged(nameof(AddCommand));
        }
        private void GetElectronicsObjectData()
        {
            Product = new ElectronicsViewModel();
            
        }
        private void GetPerishableGoodsObjectData()
        {
            Product = new PerishableGoodsViewModel();
        }
        private void GetClothingObjectData()
        {
            Product = new ClothingViewModel();
        }
        #endregion
    }
}
