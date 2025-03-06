using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Models
{
    public enum ClothingSizeEnum
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL,
    }
    public enum ClothingFabricEnum
    {
        Cotton,
        Polyester,
        Wool,
        Silk,
        Nylon,
    }
    public class Clothing : Product
    {
        #region Properites
        public ClothingSizeEnum Size { get;}
        public ClothingFabricEnum Fabric { get;}
        #endregion

        public Clothing(string name, double price, int quantity, ProductCategoryEnum category, ClothingSizeEnum size, ClothingFabricEnum fabric) : base(name, price, quantity, category)
        {
            Size = size;
            Fabric = fabric;
        }
    }
}
