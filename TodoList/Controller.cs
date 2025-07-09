using System;

namespace TodoList;

public class Controller
{
    public enum AppState
    {
        Menu,
        UserSelection,
        ShowingTask,
        AddTask,
        RemoveTask,
        UpdateTask,
        Exit
    }
    private AppState _appState { get; set; }
    private AppMenu _appMenu { get; set; }
    private TodoListManager _todoListManager { get; set; }
    public Controller()
    {
        _appState = AppState.Menu;
        _appMenu = new AppMenu();
        _todoListManager = new TodoListManager();
    }

    public void Start()
    {
        while (_appState != AppState.Exit)
        {
            switch (_appState)
            {
                case AppState.Menu:
                    _appMenu.DisplayMenu();
                    _appState = AppState.UserSelection;
                    break;

                case AppState.UserSelection:
                    Console.Write("Enter your selection (1/2/3/4/5): ");
                    int userSelection = Convert.ToInt32(Console.ReadLine());
                    _appState = _appMenu.HandleSelection(userSelection);
                    break;

                case AppState.ShowingTask:
                    _todoListManager.RetrieveTask();
                    _appState = AppState.Menu;
                    break;

                case AppState.AddTask:
                    string? task = Console.ReadLine();
                    _todoListManager.AddTask(task);
                    _appState = AppState.Menu;
                    break;

                case AppState.UpdateTask:
                    int updateTaskSelection = Convert.ToInt32(Console.ReadLine());
                    _todoListManager.UpdateTask(updateTaskSelection);
                    _appState = AppState.Menu;
                    break;  

                case AppState.RemoveTask:
                    int removeTaskSelection = Convert.ToInt32(Console.ReadLine());
                    _todoListManager.RemoveTask(removeTaskSelection);
                    _appState = AppState.Menu;
                    break;

            }
        }
    }
}

public class AppMenu
{
    public AppMenu()
    {

    }

    public void DisplayMenu()
    {
        Console.WriteLine("1. Show Task");
        Console.WriteLine("2. Add Task");
        Console.WriteLine("3. Update Task");
        Console.WriteLine("4. Remove Task");
        Console.WriteLine("5. Exit App");
    }

    public Controller.AppState HandleSelection(int selection)
    {

        if (selection < 1 || selection > 5)
        {
            Console.WriteLine("Invalid Selection");
            return Controller.AppState.Menu;
        }
        switch (selection)
        {
            case 1:
                return Controller.AppState.ShowingTask;
            case 2:
                return Controller.AppState.AddTask;
            case 3:
                return Controller.AppState.UpdateTask;
            case 4:
                return Controller.AppState.RemoveTask;
            case 5:
                return Controller.AppState.Exit;
            default:
                return Controller.AppState.Menu;
        }
    }

}
