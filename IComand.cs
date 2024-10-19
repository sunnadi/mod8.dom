using System;
using System.Collections.Generic;
public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Свет включен.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Свет выключен.");
    }
}
public class LightCommand : ICommand
{
    private Light light;
    private bool previousState;

    public LightCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        previousState = true; 
        light.TurnOn();
    }

    public void Undo()
    {
        if (previousState)
            light.TurnOff();
    }
}

public class Door
{
    public void Open()
    {
        Console.WriteLine("Дверь открыта.");
    }

    public void Close()
    {
        Console.WriteLine("Дверь закрыта.");
    }
}

public class DoorCommand : ICommand
{
    private Door door;
    private bool previousState;

    public DoorCommand(Door door)
    {
        this.door = door;
    }

    public void Execute()
    {
        previousState = true; 
        door.Open();
    }

    public void Undo()
    {
        if (previousState)
            door.Close();
    }
}

public class Thermostat
{
    public void IncreaseTemperature()
    {
        Console.WriteLine("Температура увеличена.");
    }

    public void DecreaseTemperature()
    {
        Console.WriteLine("Температура уменьшена.");
    }
}

public class ThermostatCommand : ICommand
{
    private Thermostat thermostat;
    private bool previousState; 

    public ThermostatCommand(Thermostat thermostat)
    {
        this.thermostat = thermostat;
    }

    public void Execute()
    {
        previousState = true; 
        thermostat.IncreaseTemperature();
    }

    public void Undo()
    {
        if (previousState)
            thermostat.DecreaseTemperature();
    }
}

public class RemoteControl
{
    private List<ICommand> commandHistory = new List<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Add(command);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory[commandHistory.Count - 1];
            lastCommand.Undo();
            commandHistory.RemoveAt(commandHistory.Count - 1);
        }
        else
        {
            Console.WriteLine("Нет команд для отмены.");
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        RemoteControl remote = new RemoteControl();

        Light livingRoomLight = new Light();
        Door frontDoor = new Door();
        Thermostat thermostat = new Thermostat();

        LightCommand lightCommand = new LightCommand(livingRoomLight);
        DoorCommand doorCommand = new DoorCommand(frontDoor);
        ThermostatCommand thermostatCommand = new ThermostatCommand(thermostat);

        remote.ExecuteCommand(lightCommand);       
        remote.ExecuteCommand(doorCommand);        
        remote.ExecuteCommand(thermostatCommand);  

        Console.WriteLine("Отмена последней команды:");
        remote.UndoLastCommand(); 
        remote.UndoLastCommand(); 
        remote.UndoLastCommand();
        remote.UndoLastCommand(); 
    }
}
