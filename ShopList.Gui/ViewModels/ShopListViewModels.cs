using ShopList.Gui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;



namespace ShopList.Gui.ViewModels
    {
    public class ShopListViewModels : INotifyPropertyChanged
    {

        private string _nombreDelArticulo = string.Empty;
        private int _cantidadAComprar = 1;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Item> item { get; }
        public string NombreDelArticulo
        {
            get => _nombreDelArticulo;
            set
            {
                if (value != _nombreDelArticulo)
                {
                    _nombreDelArticulo = value;
                    OnPropetyChanged(nameof(NombreDelArticulo));
                }
            }
        }
        public int CantidadAComprar
        {
            get => _cantidadAComprar;
            set
            {
                if (value != _cantidadAComprar)
                {
                    _cantidadAComprar = value;
                    OnPropetyChanged(nameof(CantidadAComprar));
                }
            }
        }
        public ICommand AgregarShopListItemCommand { get; private set; }
        
        public ShopListViewModels()
        {
            item = new ObservableCollection<Item>();
            CargarDatos();
            AgregarShopListItemCommand = new Command(AgregarShopListItem);
        }
        public void AgregarShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo) || CantidadAComprar <= 0)
            {
                return;
            }
            Random generador = new Random();

            var Item = new Item
            {
                Id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado = false,
            };
            item.Add(Item);
            NombreDelArticulo = String.Empty;
            CantidadAComprar = 1;
        }

        public void EleminarShopListItem()
        {

        }
        public void CargarDatos()
        {
            item.Add(new Item
            {
                Id = 1,
                Nombre = "leche",
                Cantidad = 10,
                Comprado = false
            });
            item.Add(new Item
            {
                Id = 2,
                Nombre = "Huevo",
                Cantidad = 22,
                Comprado = false
            });
            item.Add(new Item
            {
                Id = 3,
                Nombre = "Carne",
                Cantidad = 32,
                Comprado = true
            });
        }
        private void OnPropetyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propetyName)
                );
        }
        }
    }    

