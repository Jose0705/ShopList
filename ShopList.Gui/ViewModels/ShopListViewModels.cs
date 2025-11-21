using ShopList.Gui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ShopList.Gui.ViewModels
{

namespace ShopList.Gui.ViewModels
{
    public class ShopListViewModels
    {
        public class NewPague1{
        public ObservableCollection<Item> item { get;}
                public NewPague1()
            {
                item = new ObservableCollection<Item>();
                CargarDatos();
            }
            public void CargarDatos()
            {
                item.Add(new Item
                {
                    Id = 1,
                    Nombre = "",
                    Cantidad = 11
                });
                item.Add(new Item
                {
                    Id = 2,
                    Nombre = "",
                    Cantidad = 12
                });
                item.Add(new Item
                {
                    Id = 3,
                    Nombre = "",
                    Cantidad = 13
                });
            }
        }
    }
}}
