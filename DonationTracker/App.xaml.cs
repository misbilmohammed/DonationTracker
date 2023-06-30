using DonationTracker.Model;
using DonationTracker.Store;
using DonationTracker.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace DonationTracker;

public partial class App : Application
{
    private User _currentUser;
    public static IHost? AppHost { get; private set; }

    public App()
    {
        // Mock LoggedIn User
        CreateCurrentUser();

        var charities = new AllCharities();
        charities.LoadACNCCharities();

        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<User>(_currentUser);
                services.AddSingleton<AllCharities>(charities);

                services.AddSingleton<NavigationStore>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });

            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
        startupForm.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();

        base.OnExit(e);
    }

    private void CreateCurrentUser()
    {
        Donor donor = new Donor
               ("Alley", "Smith", "1", "alleysmith",
               "alleysmith@gmail.com", "password", "0473829384",
               "8 James Drive, Bayswater, VIC 3153");
        Donation donation = new Donation("1", "1", 30, new DateTime(2023, 01, 10), false);

        for (int i = 0; i < 10; i++)
            donor.AddDonation(donation);

        _currentUser = donor;
    }
}
