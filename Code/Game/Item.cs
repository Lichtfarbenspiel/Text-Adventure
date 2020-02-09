using System;

public class Item{
    public string name;
    string usage;
    int power;

    public Item(String name, String usage, int power)
    {
        this.name = name;
        this.usage = usage;
        this.power = power;
    }

    // items of the same type can be combined?
}