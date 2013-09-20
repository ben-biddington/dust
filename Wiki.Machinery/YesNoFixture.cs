using fit;

namespace Wiki.Machinery
{
    public class YesNoFixture : Fixture
    {
        private readonly bool _trueOrFalse;
        private readonly string _message;
        private readonly int _colSpan;

        public YesNoFixture(bool trueOrFalse, string message, int colSpan)
        {
            _trueOrFalse = trueOrFalse;
            _message = message;
            _colSpan = colSpan;
        }

        public override void DoTable(Parse table)
        {
            if (!_trueOrFalse)
            {
                var branch = new Parse("td colspan='" + _colSpan + "'", _message, null, null);
                Wrong(branch);
                table.Add(branch);
            }
            else
            {
                Right(table.Parts.Leaf);
            }
        }
    }
}