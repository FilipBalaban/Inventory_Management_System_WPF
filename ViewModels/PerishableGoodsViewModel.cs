using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Inventory_Management_System_WPF.ViewModels
{
    public class PerishableGoodsViewModel : ProductViewModel
    {
        #region Fields
        private double? _weight;
        private int? _calories;
        private DateTime? _expirationDate;
        private string _expirationDateStr;
        #endregion

        #region Properties
        public double? Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                CheckFilledProperties();
            }
        }
        public int? Calories
        {
            get => _calories;
            set
            {
                _calories = value;
                CheckFilledProperties();
            }
        }
        public DateTime? ExpirationDate
        {
            get => _expirationDate;
            set
            {
                _expirationDate = value;
                CheckFilledProperties();
            }
        }
        
        #endregion

        #region Constructor
        public PerishableGoodsViewModel()
        {
            
        }
        public PerishableGoodsViewModel(string name, ProductCategoryEnum category, double price, int quantity, double weight, int calories, DateTime expirationDate) : base(name, category, price, quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            Weight = weight;
            Calories = calories;
            ExpirationDate = expirationDate;
        }
        #endregion

        #region Methods
        public override Grid ReturnDataGrid()
        {
            Grid grid = CreateBaseDataGrid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) });
            grid.RowDefinitions.Add(new RowDefinition()); // 4
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) });
            grid.RowDefinitions.Add(new RowDefinition()); // 6

            // Weight
            TextBlock weightBlock = new TextBlock()
            {
                Text = $"Weight: {Weight.ToString()}"
            };
            Grid.SetColumn(weightBlock, 0);
            Grid.SetRow(weightBlock, 4);
            grid.Children.Add(weightBlock);

            // Calories
            TextBlock calorieBlock = new TextBlock()
            {
                Text = $"Calories: {Calories.ToString()}"
            };
            Grid.SetColumn(calorieBlock, 2);
            Grid.SetRow(calorieBlock, 4);
            grid.Children.Add(calorieBlock);

            // Expiration Date
            TextBlock expirationDateBlock = new TextBlock()
            {
                Text = $"Expiration date: {((DateTime)ExpirationDate).ToString("d")}"
            };
            Grid.SetColumn(expirationDateBlock, 0);
            Grid.SetRow(expirationDateBlock, 6);
            grid.Children.Add(expirationDateBlock);

            return grid;
        }

        public override List<string> ReturnGridViewData()
        {
            throw new NotImplementedException();
        }

        public override StackPanel ReturnStackPanel()
        {
            TextBox weightBox = new TextBox();
            weightBox.SetBinding(TextBox.TextProperty, new Binding("Weight")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            TextBox caloriesBox = new TextBox();
            caloriesBox.SetBinding(TextBox.TextProperty, new Binding("Calories")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            DatePicker expirationDatePicker= new DatePicker();
            expirationDatePicker.SetBinding(DatePicker.SelectedDateProperty, new Binding("ExpirationDate")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });


            StackPanel stackPanel = new StackPanel
            {
                Children =
                {
                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Children =
                        {
                            new StackPanel
                            {
                                Children =
                                {
                                    new TextBlock
                                    {
                                        Text="Weight"
                                    },
                                    weightBox
                                }
                            },
                            new StackPanel
                            {
                                Children =
                                {
                                    new TextBlock
                                    {
                                        Text="Calories"
                                    },
                                    caloriesBox
                                }
                            },
                        }
                    },
                    new StackPanel
                    {
                        Children =
                        {
                            new TextBlock
                            {
                                Text = "Expiration date",
                                Margin = new System.Windows.Thickness(0,8,0,0)
                            },
                            expirationDatePicker
                        }
                    }
                }
            };

            return stackPanel;

        }
        protected override void CheckFilledProperties()
        {
            base.CheckFilledProperties();
            if(RequiredPropertiesFilled && _weight.HasValue && _calories.HasValue && _expirationDate.HasValue)
            {
                RequiredPropertiesFilled = true;
            }
            else
            {
                RequiredPropertiesFilled = false;
            }
        }
        #endregion
    }
}
