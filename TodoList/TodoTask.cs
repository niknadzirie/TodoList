using System;

namespace TodoList;

public class TodoTask
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public TodoTask(string description)
    {
        Description = description;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return $"{(IsCompleted ? "[X]" : "[ ]")} {Description}";
    }
}
