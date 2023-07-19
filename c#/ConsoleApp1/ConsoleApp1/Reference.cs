class A
{
    public A()
    {
        Console.WriteLine("A called");
    }
    public A(int a)
    {
        Console.WriteLine($"{a}");
    }
}
class B : A 
{
    public B(int b):base(b)
    {
        Console.WriteLine("B called");
    }
    public void CheckRef(ref int a)
    {
        a += 10;
    }
    public void CheckOut(out int a,out int b)
    {
        a = 15;
        b = 16;
    }
}



class Reference
{
    static void Main()
    {
        Console.WriteLine(ClassLibrary1.Class1.HelloWorld());
        B b = new B(2);
        A a = new A(3);
        var items = new Dictionary<int, int>();
        int n = int.Parse(Console.ReadLine());
        while(n>0)
        {
            int x = int.Parse(Console.ReadLine());
            if(items.ContainsKey(x))
            {
                items[x]++;
            }
            else
            {
                items.Add(x, 1);
            }
            n--;

        }
        foreach(var kvp in items)
        {
            
            Console.WriteLine($"{kvp.Key} = {kvp.Value}");
        }
        int cr = 2;
        int v = 3;
        b.CheckRef(ref cr);
        Console.WriteLine(cr);
        b.CheckOut(out cr,out v);
        Console.WriteLine($"{cr},{v}");
    }
}