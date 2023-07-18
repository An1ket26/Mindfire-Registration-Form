using System.Numerics;
using System.Text;
interface Testing{
    void displayName(string name);
    void read(){
        Console.WriteLine("working");
    }
}
class Student:Testing
{
    private int id=4;
    private int x=2;
    public int _id
    {
        get { return id; }
        set { x = value; }
    }
    public string Name { get; set; }
    public int  Sum(int num1, int num2)
    {
        Console.WriteLine("called");
        return num1 + num2;
    }
    public void Greet()
    {
        Console.WriteLine("Welcome to .net env");
    }
    public void displayName(string name){
        Console.WriteLine(name);
    }
}

class Inherit : Student{
    public int Sum(int a,int b)
    {
        return a+b;
    }
}
class Prac
{
    enum WeekDays{
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }

    static void Main()
    {
        Student student = new Student();
        Console.WriteLine(student._id);
        student._id = 5;
        Console.WriteLine(student._id);
        student.Name = "Aniket";
        Console.WriteLine(student.Name);
        Console.WriteLine(student.Sum(2, 3));
        student.Greet();
        StringBuilder sb=new StringBuilder();
        sb.Append("Hi");
        sb.Append("Aniket");
        Console.WriteLine(sb.Length);
        string s=sb.ToString();
        foreach(char c in s)
        {
            Console.WriteLine(c);
        }
        Console.WriteLine(WeekDays.friday); 
        dynamic ch=32;
        Console.WriteLine(ch.GetType());
        int? i=null;
        if(i.HasValue)
        {
            Console.WriteLine(i);
        }
        else
        {
            Console.WriteLine("invalid");
        }
        Inherit h=new Inherit();
        Console.WriteLine(h.Sum(2,6));
        Student mix=new Inherit();
        Console.WriteLine(mix.Sum(2,6));
        string name="Aniket";
        h.displayName(name);
        Testing st=new Student();
        st.read();

        int[] arr=new int[5];
        for(int j=0;j<arr.Length;j++)
        {
            Console.WriteLine(arr[j]);
        }
        int [,] arr2=new int[2,2];
        Console.WriteLine(arr2.Length);
        int [][] jag=new int[3][];
        Console.WriteLine(jag.Length);
        Console.WriteLine(typeof(int));
    }
}
/*
cls,il,msil,dll vs pdb ,extension method
*/