using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public int Age { get; set; }


}
public class Standard
{

    public int StandardID { get; set; }
    public string StandardName { get; set; }
}

public class Practice
{
    static void Main()
    {
        IList<Student> studentList = new List<Student>() {
                new Student() { Id = 1, Fname = "John", Lname = "Lewis", Age = 13} ,
                new Student() { Id = 2, Fname = "Moin",Lname = "Lewis", Age = 21 } ,
                new Student() { Id = 3, Fname = "Bill",Lname = "Lewis", Age = 18 } ,
                new Student() { Id = 4, Fname = "Ram" ,Lname = "Lewis", Age = 20} ,
                new Student() { Id = 5, Fname = "Ron" ,Lname = "Lewis", Age = 15 }
            };
        IList<Standard> standardList = new List<Standard>() {
        new Standard(){ StandardID = 1, StandardName="Standard 1"},
        new Standard(){ StandardID = 2, StandardName="Standard 2"},
        new Standard(){ StandardID = 3, StandardName="Standard 3"}
    };

        /*var simpleselect=from s in studentList select s;
        foreach(Student st in simpleselect)
        {
            Console.WriteLine(st.Fname);
        }*/

        /*var std = from s in studentList where s.Age>20 select s;
        foreach (Student st in std)
        {
            Console.WriteLine(st.Fname);
        }*/

        /*IList mixedList = new ArrayList();
        mixedList.Add(0);
        mixedList.Add("One");
        mixedList.Add("Two");
        mixedList.Add(3);
        mixedList.Add(new Student() { Id = 1, Fname = "Bill" });

        var stringResult = from s in mixedList.OfType<string>()
                           select s;

        var intResult = from s in mixedList.OfType<int>()
                        select s;
        foreach (var str in stringResult)
            Console.WriteLine(str);

        foreach (var integer in intResult)
            Console.WriteLine(integer);*/

        /*var std = from s in studentList where s.Age > 12 orderby s.Fname descending,s.Age select s;
        foreach (Student st in std)
        {
            Console.WriteLine($"{st.Fname},{st.Age}");
        }*/

        /*var std = from s in studentList group s by s.Age;
        foreach (var grp in std)
        {
            Console.WriteLine(grp.Key);
            foreach(Student st in grp)
            {
                Console.WriteLine($"{st.Fname},{st.Age}");
            } 
        }*/

        /*var std = from s in studentList
                  join st in standardList on s.Id equals st.StandardID
                  select new
                  {
                      Fname = s.Fname,
                      Lname = s.Lname,
                      StandardName = st.StandardName
                  };
        foreach(var obj in std)
        {
            Console.WriteLine($"{obj.Fname} - {obj.Lname} - {obj.StandardName}");
        }*/

        /*var std = from s in studentList
                  join st in standardList on s.Id equals st.StandardID
                  into standardGroup
                  select new
                  {
                      Standards= standardGroup,
                      Fname = s.Fname,
                      Lname = s.Lname,
                  };
        foreach (var obj in std)
        {
            Console.WriteLine($"{obj.Fname} - {obj.Lname}");
            foreach(Standard st in obj.Standards)
            {
                Console.WriteLine($"{st.StandardID}");
            }
        }*/

        /*IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

        var cms = strList.Aggregate((s1, s2) => s1 + ',' + s2);

        Console.WriteLine(cms);*/

        /*var cms = studentList.Aggregate<Student,string>("",(std,s1) => std+=s1.Fname + '-');
        Console.WriteLine(cms);*/


        /* var totalAge = studentList.Aggregate<Student, int>(0, (i, s) => i += s.Age);
         Console.WriteLine(totalAge);*/


        /* var list = new List<int>() { 1, 2, 3, 4, 5 };

         var std = list.Count(i=>i%2!=0);

         Console.WriteLine(std);*/

        /*var list = new List<int>() { 1, 2, 3, 4, 5 };
        var std = list.Select(l=>l);
        foreach(var i in std)
        Console.WriteLine(i);*/

        /*var list = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine(list.Last(i=>i%2==0));*/

        /*var list = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine(list.First(i => i % 2 == 0));*/

        /*var list = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine(list.ElementAtOrDefault(1));*/

        /*var list = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine(list.SingleOrDefault(i=>i<2));*/

        /*Student std = new Student() { Id = 1, Fname = "Bill" };

        IList<Student> studentList1 = new List<Student>() { std };

        IList<Student> studentList2 = new List<Student>() { std };

        bool isEqual = studentList1.SequenceEqual(studentList2);
        Console.WriteLine(isEqual);

        Student std1 = new Student() { Id = 1, Fname = "Bill" };
        Student std2 = new Student() { Id = 1, Fname = "Bill" };

        IList<Student> studentList3 = new List<Student>() { std1 };

        IList<Student> studentList4 = new List<Student>() { std2 };

        isEqual = studentList3.SequenceEqual(studentList4);
        Console.WriteLine(isEqual);*/
        /*Student std1 = new Student() { Id = 1, Fname = "Bill" };
        Student std2 = new Student() { Id = 1, Fname = "Bill" };

        IList<Student> studentList3 = new List<Student>() { std1,std2 };

        IList<Student> studentList4 = new List<Student>() { std2,std1 };
        bool isEqual = studentList3.SequenceEqual(studentList4, new comperator());
        Console.WriteLine(isEqual);*/

        /*var items = new List<Tuple<int,int>>();
        items.Add(new Tuple<int,int>(1, 2));
        Console.WriteLine(items[0].Item1);*/

        /*var list = new List<int>() { 1, 2, 3, 4, 5 };
        list.Sort(Compare);
        foreach (var i in list)
        {
            Console.WriteLine(i);
        }*/

        /*IList<int> emptyList = new List<int>();

        var newList1 = emptyList.DefaultIfEmpty();
        var newList2 = emptyList.DefaultIfEmpty(100);

        Console.WriteLine("Count: {0}", newList1.Count());
        Console.WriteLine("Value: {0}", newList1.ElementAt(0));

        Console.WriteLine("Count: {0}", newList2.Count());
        Console.WriteLine("Value: {0}", newList2.ElementAt(0));*/

        /*IList<Student> stdlist = new List<Student>() {
            new Student() { Id = 1, Fname = "John", Age = 18 } ,
            new Student() { Id = 2, Fname = "Steve",  Age = 15 } ,
            new Student() { Id = 3, Fname = "Bill",  Age = 25 } ,
            new Student() { Id = 3, Fname = "Bill",  Age = 25 } ,
            new Student() { Id = 3, Fname = "Bill",  Age = 25 } ,
            new Student() { Id = 3, Fname = "Bill",  Age = 25 } ,
            new Student() { Id = 5, Fname = "Ron" , Age = 19 }
        };
        var std = stdlist.Distinct(new ObjectCompare());
        foreach (Student s in std)
        {
            Console.WriteLine(s.Id);
        }*/

        /*var items = new List<int> { 1, 2, 2, 2, 3, 4, 5, 6 };
        foreach(var i in items.Distinct())
        {
            Console.WriteLine(i);
        }*/

        /*IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
        IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

        var result = strList1.Except(strList2);

        foreach (string str in result)
            Console.WriteLine(str);
        var result2 = strList1.Intersect(strList2);

        foreach (string str in result2)
            Console.WriteLine(str);*/

        /*var items = new List<string>() { "One","Two","Three","Four","Five","Six"};
        var std = items.Skip(3);
        foreach ( string item in std )
        {
            Console.WriteLine(item);
        }

        std = items.SkipWhile(s => s.Length < 4);
        foreach (string item in std)
        {
            Console.WriteLine(item);
        }*/

        /*var items = new List<string>() { "One", "Two", "Three", "Four", "Five", "Six" };
        var std = items.Take(3);
        foreach (string item in std)
        {
            Console.WriteLine(item);
        }

        std = items.TakeWhile(s => s.Length < 4);
        foreach (string item in std)
        {
            Console.WriteLine(item);
        }*/




        Console.ReadLine();
    }

    /*public class comperator : IEqualityComparer<Student> //  only for objects
    {
        public bool Equals(Student x, Student y)
        {
            bool result = x.Id==y.Id;
            return result;
        }
        public int GetHashCode(Student l)
        {
            return l.Id;
        }

    }*/

    /*private static int Compare(int a, int b)
    {
        if (a < b)
        {
            return 0;
        }
        return -1;
    }*/

    /* public class ObjectCompare : IEqualityComparer<Student>
     {
         public bool Equals(Student x, Student y)
         {
             if (x.Id == y.Id)
             {
                 return true;
             }
             return false;
         }
         public int GetHashCode(Student obj)
         {
             return obj.Id.GetHashCode();
         }
     }*/
}