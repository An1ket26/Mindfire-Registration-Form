/*public delegate void MyDelegate(string msg);

class delg
{
    static void methodA(string msg)
    {
        Console.WriteLine(msg);
    }
    static void Main()
    {
        MyDelegate a = new MyDelegate(methodA);
        a("Aniket");
    }
}*/
public delegate T MyDelegate<T>(T param1, T param2);

public class c1
{
    static int method1(int a,int b)
    {
        return a + b;
    }
    static string method2(string a,string b) {  return a + b; }
    static void Main(String[] args)
    {
        MyDelegate<int> d = method1;
        MyDelegate<string> e = method2;
        Console.WriteLine(d(1,2));
        Console.WriteLine(e("Hello", "World"));
    }
}