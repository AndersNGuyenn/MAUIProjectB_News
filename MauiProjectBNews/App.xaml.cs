﻿using MauiProjectBNews.Models;

namespace MauiProjectBNews
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           MainPage = new AppShell();
        }
    }
}