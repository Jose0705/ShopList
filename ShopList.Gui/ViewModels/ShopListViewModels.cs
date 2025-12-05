using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopList.Gui.Models;
using ShopList.Gui.Persistence;
using System.Collections.ObjectModel;


namespace ShopList.Gui.ViewModels
{
    public partial class ShopListViewModels : ObservableObject
    {
        [ObservableProperty]
        private string _nombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidadAComprar = 1;
        [ObservableProperty]
        private Item? _selectedItem;

        [ObservableProperty]
        private ObservableCollection<Item> items = new();

        private ShopListDatabase? _database = null;
        public ShopListViewModels()
        {
            _database = new ShopListDatabase();
            items = new ObservableCollection<Item>();
            // CargarDatos();
            //AgregarShopListItemCommand = new Command(AgregarShopListItem);
        }
        [RelayCommand]
        public async Task AgregarShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo) || CantidadAComprar <= 0)
            {
                return;
            }

            var nuevo = new Item
            {
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado = false,
            };

           await _database.SaveItemAsync(nuevo);
            GetItems();
            SelectedItem = nuevo;

   
            NombreDelArticulo = string.Empty;
            CantidadAComprar = 1;
        }
        [RelayCommand]
        public async void EleminarShopListItem()
        {
            if (SelectedItem == null)
                return;

            if (_database != null)
            {
                await _database.RemoveItemAsync(SelectedItem);
            }

            int index = items.IndexOf(SelectedItem);
            items.Remove(SelectedItem);

            if (items.Count > 0)
            {
                if (index >= items.Count)
                    index = items.Count - 1;

                SelectedItem = items[index];
            }
            else
            {
                SelectedItem = null;
            }
        }
        private async void GetItems()
        {
            IEnumerable<Item> itemsFromDb = await _database.GetAllItemAsync();

            Items = new ObservableCollection<Item>(itemsFromDb);
        }

        public void CargarDatos()
            {
                items.Add(new Item
                {
                    Id = 1,
                    Nombre = "leche",
                    Cantidad = 10,
                    Comprado = false
                });
                items.Add(new Item
                {
                    Id = 2,
                    Nombre = "Huevo",
                    Cantidad = 22,
                    Comprado = false
                });
                items.Add(new Item
                {
                    Id = 3,
                    Nombre = "Carne",
                    Cantidad = 32,
                    Comprado = true
                });
            }
        }
    }

