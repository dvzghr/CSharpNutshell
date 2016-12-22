using System;
using System.Collections.Generic;

namespace InheritanceGenericNonGeneric
{
    public abstract class AbstractBlockRule
    {
        public long Id { get; set; }
        public abstract List<IRestriction> Restrictions { get; set; }
    }

    public interface IRestriction
    {
        object Limit { get; }
    }

    public interface IRestriction<T> : IRestriction where T : struct
    {
        // hide IRestriction.Limit
        new T Limit { get; }
    }

    public class TimeRestriction : IRestriction<TimeSpan>
    {
        object IRestriction.Limit { get; }

        public TimeSpan Limit { get; }
    }

    public class AgeRestriction : IRestriction<int>
    {
        object IRestriction.Limit { get; }

        public int Limit { get; set; }
    }

    public class NonGenericRestriction : IRestriction
    {
        public object Limit { get; }
    }

    public class BlockRule : AbstractBlockRule
    {
        public override List<IRestriction> Restrictions { get; set; } = new List<IRestriction>();

        public BlockRule()
        {
            var ngRestr = new NonGenericRestriction();
            Console.WriteLine(ngRestr.Limit);

            var timeRestr = new TimeRestriction();
            Console.WriteLine(timeRestr.Limit);

            var ageRestr = new AgeRestriction();
            Console.WriteLine(ageRestr.Limit);

            Restrictions.Add(ngRestr);
            Restrictions.Add(timeRestr);
            Restrictions.Add(ageRestr);
        }
    }


    //OPTIONAL BASE CLASS
    public abstract class RestrictionBase<T> : IRestriction<T> where T : struct
    {
        // explicit implementation
        object IRestriction.Limit
        {
            get { return Limit; }
        }

        // override when required
        public virtual T Limit { get; }
    }

    //public class TimeRestriction : RestrictionBase<TimeSpan>
    //{
    //}

    //public class AgeRestriction : RestrictionBase<int>
    //{
    //}

}
