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

        var std = from s in studentList
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
        }


        Console.ReadLine();
    }
}