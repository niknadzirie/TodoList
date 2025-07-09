using System;

namespace TodoList;

public class TodoListManager
{
    private List<TodoTask> _todolist { get; set; }
    public IReadOnlyList<TodoTask> TodoList => _todolist;
    public TodoListManager()
    {
        _todolist = new List<TodoTask>();
    }

    //Add Task
    public void AddTask(string todo)
    {
        if (!string.IsNullOrWhiteSpace(todo))
        {
            _todolist.Add(new TodoTask(todo));
        }
        else
        { 
            Console.WriteLine("Task cannot be empty");
        }
        
    }
    //Remove Task
    public void RemoveTask(int index)
    {
        if (index > _todolist.Count || index < 1)
        {
            Console.WriteLine("Invalid Task Number");
            return;
        }
        _todolist.RemoveAt(index - 1);
    }
    //Update Task
    public void UpdateTask(int index)
    {
        if (index > _todolist.Count || index < 1)
        {
            Console.WriteLine("Invalid Task Number");
            return;
        }
        _todolist[index - 1].IsCompleted = true;
    }
    //Retrieve Task
    public void RetrieveTask()
    {
        int count = 1;
        foreach (var todo in TodoList)
        {
            Console.WriteLine($"{count}. " + todo);
            count++;
        }
    }
}
