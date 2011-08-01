using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.DAL.Llbl.FactoryClasses
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class GenericTimeStampConcurrencyPredicateFactory : IConcurrencyPredicateFactory
    {
        /// <summary>
        /// Singleton instance of GenericTimeStampConcurrencyPredicateFactory that can be assigned to
        /// ConcurrencyPredicateFactoryToUse of Entity.
        /// </summary>
        public static GenericTimeStampConcurrencyPredicateFactory SingletonInstance
        {
            get
            {
                if (_genericTimeStampConcurrencyPredicateFactory == null)
                {
                    _genericTimeStampConcurrencyPredicateFactory = new GenericTimeStampConcurrencyPredicateFactory();
                }
                return _genericTimeStampConcurrencyPredicateFactory;
            }
        }
        private static GenericTimeStampConcurrencyPredicateFactory _genericTimeStampConcurrencyPredicateFactory;

        /// <summary>
        /// Predicate Factory method required by inrterface
        /// </summary>
        /// <param name="predicateTypeToCreate"></param>
        /// <param name="containingEntity"></param>
        /// <returns></returns>
        public IPredicateExpression CreatePredicate(ConcurrencyPredicateType predicateTypeToCreate, object containingEntity)
        {
            IPredicateExpression toReturn = new PredicateExpression();
            EntityBase entityBase = (EntityBase)containingEntity;

            try
            {
                //relies on column with name "TimeStamp" existing.
                if (entityBase.Fields["TimeStamp"] != null)
                {
                    switch (predicateTypeToCreate)
                    {
                        case ConcurrencyPredicateType.Delete:
                            //for deletes
                            toReturn.Add(new FieldCompareValuePredicate(entityBase.Fields["TimeStamp"], ComparisonOperator.Equal, entityBase.Fields["TimeStamp"].CurrentValue));
                            break;
                        case ConcurrencyPredicateType.Save:
                            //for updates
                            toReturn.Add(new FieldCompareValuePredicate(entityBase.Fields["TimeStamp"], ComparisonOperator.Equal, entityBase.Fields["TimeStamp"].CurrentValue));
                            break;
                    }
                }
            }
            catch (ArgumentException)
            {
                //do nothing
            }

            return toReturn;
        }
    }
}
