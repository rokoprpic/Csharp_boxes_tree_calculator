using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        //Generate box list
        List<(int length, int height, int width)> boxList = GenerateBoxList();
        PrintGeneratedList(boxList);

        //Max stack combination
        List<(int length, int height, int width)> maxStack = MaxStackList(boxList);
        PrintMaxStack(maxStack);

        //Min stack combination
        List<(int length, int height, int width)> minStack = MinStackList(boxList);
        PrintMinStack(minStack);

        Console.ReadLine();
    }

    //generate and print
    static List<(int length, int height, int width)> GenerateBoxList()
    {
        List<(int length, int height, int width)> boxList = new List<(int length, int height, int width)>();
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            int length = random.Next(1, 11);
            int width = random.Next(1, 11);
            int height = random.Next(1, 11);
            boxList.Add((length, width, height));
        }
        return boxList;
    }
    static void PrintGeneratedList(List<(int length, int height, int width)> boxList)
    {
        Console.WriteLine("Generated box list:");
        foreach (var box in boxList)
        {
            Console.WriteLine($"({box.length}, {box.height}, {box.width})");
        }
        Console.WriteLine("-------------------");
    }

    //max stack and print
    static List<(int length, int height, int width)> MaxStackList(List<(int length, int height, int width)> boxList)
    {
        List<(int length, int height, int width)> stack = new List<(int length, int height, int width)>();
        foreach (var box in boxList)
        {
            if (stack.All(b => box.length <= b.length && box.width <= b.width))
            {
                stack.Add(box);
            }
        }
        return stack;
    }
    static void PrintMaxStack(List<(int length, int height, int width)> boxList)
    {
        Console.WriteLine("Max stack box list:");
        foreach (var box in boxList)
        {
            Console.WriteLine($"({box.length}, {box.height}, {box.width})");
        }
        Console.WriteLine("-------------------");
    }

    //min stack and print
    static List<(int length, int height, int width)> MinStackList(List<(int length, int height, int width)> boxList)
    {
        List<(int length, int height, int width)> stack = new List<(int length, int height, int width)>();
        foreach (var box in boxList)
        {
            if (stack.All(b => box.length < b.length && box.width < b.width))
            {
                stack.Add(box);
            }
        }
        return stack;
    }
    static void PrintMinStack(List<(int length, int height, int width)> boxList)
    {
        Console.WriteLine("Min stack box list:");
        foreach (var box in boxList)
        {
            Console.WriteLine($"({box.length}, {box.height}, {box.width})");
        }
        Console.WriteLine("-------------------");
    }

}
