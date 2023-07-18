namespace HeightWeightInfo
{
    class File2
    {
    }
    public partial class Record
    {
        public void PrintRecord()
        {
            Console.WriteLine("Height:" + h);
            Console.WriteLine("Weight:" + w);
        }
    }
}
namespace HeightWeightInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Record myRecord = new Record(10, 15);
            myRecord.PrintRecord();
            Console.ReadLine();
        }
    }
}