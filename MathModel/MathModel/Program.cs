namespace MathModel
{
    class Program
    {
        private static void Main(string[] args)
        {
            var gdo = new GDO();
            var o = new Oscillograph(gdo);

            gdo.R100 += 1;
            o.MsPerDel += 200;
            var g = o.Graph;
        }
    }
}
