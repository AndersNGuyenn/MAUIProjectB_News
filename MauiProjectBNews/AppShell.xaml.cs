using MauiProjectBNews.Models;
using MauiProjectBNews.Services;
using MauiProjectBNews.Views;

namespace MauiProjectBNews
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            var article = new NewsArticle();

            foreach (NewsCategory category in Enum.GetValues(typeof(NewsCategory)))
            {
                var url = article.Url;
                
                var sc = new ShellContent
                {
                    Title = category.ToString(),
                    ContentTemplate = new DataTemplate(() => new ArticleView(url,category))
                };
                this.Items.Add(sc);
            }
        }
    }
}
    