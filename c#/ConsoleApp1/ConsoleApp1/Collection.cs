using System.Collections;


class c1<T>
{
    List<T> genericList = new List<T>();
}
class collect
{
    static void Main()
    {
        var arrlist = new ArrayList();
        arrlist.Add(1);
        arrlist.Add("Hi");
        int a =(int)arrlist[0];
        Console.WriteLine(a);
        int[] arr = { 1, 2, 3, 4, 5 };
        arrlist.AddRange(arr);
        arrlist.Insert(0, 2);
        arrlist.Remove(1);//first occurence of 1
        arrlist.RemoveAt(1);//position
        arrlist.RemoveRange(1, 2);//from 1 position remove 2 elements
        foreach(var item in arrlist)
        {
            Console.WriteLine(item);
        }    
        Console.WriteLine(arrlist.Contains(5));
        //Array list you have to know the types
        //list
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.AddRange(arr);
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(list.Count);
        //sortedList

        SortedList<int, string> numberNames = new SortedList<int, string>()
                                    {
                                        {3, "Three"},
                                        {5, "Five"},
                                        {1, "One"}
                                    };

        Console.WriteLine("---Initial key-values---");

        foreach (KeyValuePair<int, string> kvp in numberNames)
            Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

        numberNames.Add(6, "Six");
        numberNames.Add(2, "Two");
        numberNames.Add(4, "Four");

        Console.WriteLine("---After adding new key-values---");

        foreach (var kvp in numberNames)
            Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

        SortedList<string, string> cities = new SortedList<string, string>()
                                            {
                                                {"London", "UK"},
                                                {"New York", "USA"}
                                            };

        Console.WriteLine("---Initial key-values---");

        foreach (var kvp in cities)
            Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

        cities.Add("Mumbai", "India");
        cities.Add("Johannesburg", "South Africa");

        Console.WriteLine("---After adding new key-values---");

        foreach (var kvp in cities)
            Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

        //Dictionary
        var dict=new Dictionary<int, string>();
        dict.Add(1, "one");
        if (dict.ContainsKey(1))
        {
            Console.WriteLine(dict[1]);
        }
        //.remove .clear

        Hashtable num1=new Hashtable();
        num1.Add(1, "One");
        num1.Add(2, "two");
        foreach(DictionaryEntry kvp in num1)
        {
            Console.WriteLine("key={0} value={1}", kvp.Key, kvp.Value);
        }

        //stack
        Stack<int> myStack = new Stack<int>();
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);
        Console.WriteLine(myStack.Peek());
        foreach (var item in myStack)
            Console.Write(item + ","); //prints 4,3,2,1, 

        //queue
        Queue<int> callerIds = new Queue<int>();
        callerIds.Enqueue(1);
        callerIds.Enqueue(2);
        callerIds.Enqueue(3);
        callerIds.Enqueue(4);
        Console.WriteLine(callerIds.Dequeue());
        foreach (var id in callerIds)
            Console.Write(id); //prints 1234
    }

}
