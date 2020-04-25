namespace MathModel
{
    public class Oscillograph
    {
        public double MsPerDel { get; set; }
        private readonly GDO _gdo;

        private double MaxT => 10 * (MsPerDel / 1000);
        private double Step => MaxT / 2000;
        public Point[] Graph => _gdo.Generate(Step);

        public Oscillograph(GDO gdo)
        {
            MsPerDel = 200;
            _gdo = gdo;
        }
    }
}