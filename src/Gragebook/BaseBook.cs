namespace Gragebook
{
    public abstract class BookBase : NamedObject, IBook
    {
        protected BookBase(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}