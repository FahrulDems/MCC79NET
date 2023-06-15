namespace Account
{
    internal class Program
    {
        private static List<Data> datas = new List<Data>();

        public static void Main(string[] args) 
        {
            Menu menu1 = new Menu(datas);
            menu1.Run();
        }
    }
}