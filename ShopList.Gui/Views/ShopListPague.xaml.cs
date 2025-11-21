using ShopList.Gui.ViewModels;
namespace ShopList.Gui.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
		BindingContext = new ShopListViewModels();
	}
}