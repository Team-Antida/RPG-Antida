using System;

delegate int StringDelegate<T>(T value);
public delegate void SomeDelegate<T>(T item);


 
public class MultiDelegates
{
    static int PrintString(string str)
    {
        Console.WriteLine("Str: {0}", str);
        return 1;
    }
    int PrintStringLength(string value)
    {
        Console.WriteLine("Length: {0}", value.Length);
        return 2;
    }

    public static void Notify(string i)
    {
        Console.WriteLine("Notify {0}",i);
    } 

    public static void Main()
    {
        //StringDelegate<string> d = MultiDelegates.PrintString;
        //d += new MultiDelegates().PrintStringLength;
        //int result = d("some string value");
        //Console.WriteLine("Returned result: {0}", result);

        Func<string, int> intParseFunction = int.Parse;
        int num = intParseFunction("10");

        Action<int> printNumberAction = Console.WriteLine;
        printNumberAction(num);




    }
}
