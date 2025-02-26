using MauiProjectBNews.Models;
using MauiProjectBNews.Services;
using System.Web;

namespace MauiProjectBNews.Views
{
    public class GroupedNews
    {
        public string Category { get; set; }
        public IEnumerable<IGrouping<DateTime, NewsArticle>> Items { get; set; }
    }
    public partial class ArticleView : ContentPage
    {
        NewsService newsService;
        GroupedNews groupedNews;
        NewsArticle newsArticle;
        NewsCategory category;


        public ArticleView()
        {
            InitializeComponent();
        }
        public ArticleView(string Url, NewsCategory category)
        {
            InitializeComponent();
            BindingContext = new UrlWebViewSource
            {
                Url = HttpUtility.UrlDecode(Url)
            };
            newsService = new NewsService();
            groupedNews = new GroupedNews();
            newsArticle = new NewsArticle();
            this.category = category;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Title = $"{category.ToString()}";

            MainThread.BeginInvokeOnMainThread(async () => { await LoadNews(); });
        }

        private async Task LoadNews()
        {
            try
            {
                var news = await newsService.GetNewsAsync(category);

                groupedNews.Category = newsArticle.Title;
                groupedNews.Items = news.Articles.GroupBy(item => item.DatePublished).OrderBy(group => group.Key);

                GroupedNews.ItemsSource = groupedNews.Items;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Error loading news: {ex.Message}");
                await DisplayAlert("Failed to load news.", "Check connection or API-Key and try again.", "OK");
            }

        }




        private async void Button_Clicked(object sender, EventArgs e)
        {
            await LoadNews();

        }

        private async void GroupedNews_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item is NewsArticle article)
            {
                await Navigation.PushAsync(new NewPage1(article.Url));
            }
            

        }
    }
}
