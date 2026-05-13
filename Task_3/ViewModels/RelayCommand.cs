using System;
using System.Windows.Input;

namespace Task_3.ViewModels;

public class RelayCommand : ICommand
{
    private readonly Action _execute;

    // assign a method to a variable
    public RelayCommand(Action execute)
    {
        _execute = execute;
    }

    // Can use method? true - yes / false - no
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    // Do method
    public void Execute(object? parameter)
    {
        _execute();
    }

    public event EventHandler? CanExecuteChanged;
}