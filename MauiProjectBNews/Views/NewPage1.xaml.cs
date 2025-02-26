using System.Web;

namespace MauiProjectBNews.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1(string Url)
{
    InitializeComponent();

    BindingContext = new UrlWebViewSource
    {
        Url = HttpUtility.UrlDecode(Url)
    };
}
}