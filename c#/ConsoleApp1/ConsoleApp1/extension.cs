
using Extend;
class ext
{
    
    static void Main()
    {
        int i = 0;
        Console.WriteLine(i.isGreater(100));
    }
}

namespace Extend
{
    public static class IntExtend
    {
        public static bool isGreater(this int i,int val)
        {
            return i > val;
        }
    }
}