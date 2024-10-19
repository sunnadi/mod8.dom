using System;

public abstract class Beverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments())
        {
            AddCondiments();
        }
    }

    protected void BoilWater()
    {
        Console.WriteLine("Кипятим воду.");
    }

    protected void PourInCup()
    {
        Console.WriteLine("Наливаем в чашку.");
    }
    protected abstract void Brew();
    protected abstract void AddCondiments();

    protected virtual bool CustomerWantsCondiments()
    {
        return true;
    }
}

public class Tea : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем чай.");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем лимон.");
    }
}
public class Coffee : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем кофе.");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем сахар и молоко.");
    }

    protected override bool CustomerWantsCondiments()
    {
        Console.Write("Хотите добавить сахар и молоко в кофе? (y/n): ");
        string answer = Console.ReadLine();
        return answer.ToLower() == "y";
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Beverage tea = new Tea();
        tea.PrepareRecipe();

        Console.WriteLine();

        Beverage coffee = new Coffee();
        coffee.PrepareRecipe();
    }
}
