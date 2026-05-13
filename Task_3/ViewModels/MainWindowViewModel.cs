using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Task_3.Models;
namespace Task_3.ViewModels;


public partial class MainWindowViewModel : ViewModelBase
{
    private readonly UserProfile _userProfile = new(); // Creating user
    private string _resultText = ""; // Text for result
    
    // Initialize links for methods
    public ICommand CreateGreetingCommand { get; }
    public ICommand ClearCommand { get; }
    public ICommand AboutCommand { get; }
    public ICommand ExitCommand { get; }
    
    // Install methods with RelayCommand
    public MainWindowViewModel()
    {
        CreateGreetingCommand = new RelayCommand(CreateGreeting);
        ClearCommand = new RelayCommand(Clear);
        AboutCommand = new RelayCommand(About);
        ExitCommand = new RelayCommand(Exit);
    }

    public string Name
    {
        get => _userProfile.Name;
        set
        {
            if (_userProfile.Name == value)
            {
                return;
            }

            _userProfile.Name = value;
            OnPropertyChanged();
        }
    }

    public string Profession
    {
        get => _userProfile.Profession;
        set
        {
            if (_userProfile.Profession == value)
            {
                return;
            }
            _userProfile.Profession = value;
            OnPropertyChanged();
        }
    }
    
    public string FavoriteFramework
    {
        get => _userProfile.FavoriteFramework;
        set
        {
            if (_userProfile.FavoriteFramework == value)
            {
                return;
            }
            _userProfile.FavoriteFramework = value;
            OnPropertyChanged();
        }
    }
    
    public string ResultText 
    {
        get => _resultText;
        set => SetProperty(ref _resultText, value);
    }

    // Make a result (Greeting)
    public void CreateGreeting()
    {
        var name = string.IsNullOrWhiteSpace(Name)
            ? "User"
            : Name;

        var framework = string.IsNullOrWhiteSpace(FavoriteFramework)
            ? "Avalonia"
            : FavoriteFramework;
        
        var profession  = string.IsNullOrWhiteSpace(Profession)
            ? "None"
            : Profession;

        ResultText = $"Hi, {name}! You study {framework}.\nYour profession: {profession}.";
    }
    
    // Clear data
    public void Clear()
    {
        Name = "";
        Profession = "";
        FavoriteFramework = "Avalonia";
        ResultText = "";
    }
    
    // About text
    public void About()
    {
        ResultText = "Hello Avalonia App\nLearning application on Avalonia UI.";
    }
    
    // Exit method
    public void Exit()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
}
