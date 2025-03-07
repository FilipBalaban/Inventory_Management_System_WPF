using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        #endregion

        #region Methods
        public override StackPanel ReturnDataStackPanel()
        {
            throw new NotImplementedException();
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
