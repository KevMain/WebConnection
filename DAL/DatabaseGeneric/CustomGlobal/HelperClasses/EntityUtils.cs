using System;
using System.ComponentModel;
using System.Threading;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace CCE.WebConnection.DAL.Llbl.HelperClasses
{
    public class EntityUtils
    {
        #region Public Static Members

        #endregion

        #region Constants

        #endregion

        #region Class Member Declarations

        #endregion

        /// <summary>
        /// Private CTor, no instatiation possible
        /// </summary>
        private EntityUtils()
        {
        }

        public static void ThrowConcurrencyError(EntityBase entity, ConcurrencyPredicateType type)
        {
            string concurrencyErrorMessage = string.Format(Const.EXC_CONCURRENCY_ERROR, type);
            throw new ORMConcurrencyException(concurrencyErrorMessage, entity);
        }

        public static void ThrowConcurrencyError(ORMConcurrencyException ex, ConcurrencyPredicateType type)
        {
            ex = new ORMConcurrencyException
                (
                string.Format(Const.EXC_CONCURRENCY_ERROR, "Update"),
                ex.EntityWhichFailed
                );

            throw ex;
        }

        //To Complete
        //public static object ParseExceptionMessage(ApplicationException exception)
        //{
        //    //string message = exception.Message;

        //    //message = message.Replace(

        //    //ApplicationException ex = new ApplicationException();
        //}

        public static void UpdateAutoFields(IEntity2 entity)
        {
            //convert to int & check what value if someone not logged in
            try
            {
                if (entity.IsNew)
                {
                    if (SafeHasField(entity, "Created"))
                    {
                        entity.Fields["Created"].CurrentValue = DateTime.Now;
                    }

                    if (SafeHasField(entity, "CreatedBy"))
                    {
                        entity.Fields["CreatedBy"].CurrentValue = Thread.CurrentPrincipal.Identity.Name;
                    }
                }

                if (SafeHasField(entity, "Modified"))
                {
                    entity.Fields["Modified"].CurrentValue = DateTime.Now;
                }

                if (SafeHasField(entity, "ModifiedBy"))
                {
                    entity.Fields["ModifiedBy"].CurrentValue = Thread.CurrentPrincipal.Identity.Name;
                }

                if (SafeHasField(entity, "DateLastUpdated"))
                {
                    entity.Fields["DateLastUpdated"].CurrentValue = DateTime.Now;
                }
            }
            catch (InvalidCastException ice)
            {
                throw new ApplicationException(
                    "System.Threading.Thread.CurrentPrincipal.Identity.Name was not Integer: " + Thread.CurrentPrincipal.Identity.Name,
                    ice);
            }
        }

        /// <summary>
        /// Adds a predicate compare value expression if the field exists in the entity.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="filter"></param>
        /// <param name="fieldName"></param>
        /// <param name="cOperator"></param>
        /// <param name="cValue"></param>
        /// <remarks>
        /// Instantiates "PredicateExpression filter" if required
        /// </remarks>
        public static void AddPredicateCompareValueExpressionIfFieldExist(IEntityFields fields, ref PredicateExpression filter, string fieldName, ComparisonOperator cOperator, object cValue)
        {
            //add any required elements to the predicate expression
            if (SafeHasField(fields, fieldName))
            {
                //check the filter is not null.  the reason it is done like this is so that
                //if not filtering is required the filter will not need to be instantiated.
                if (filter == null)
                {
                    filter = new PredicateExpression();
                }

                FieldCompareValuePredicate fcvp = new FieldCompareValuePredicate
                (
                    fields[fieldName],
                    null,
                    cOperator,
                    cValue,
                    false
                );

                //add the predicate to the predicateExpression
                filter.Add(fcvp);
            }
        }

        public static bool SafeHasField(IEntity2 entity, string fieldName)
        {
            bool hasField = false;

            if (entity != null)
            {
                PropertyDescriptorCollection entityProperties = TypeDescriptor.GetProperties(entity);

                //Find returns null if property is not found.
                if (entityProperties.Find(fieldName, true) != null)
                {
                    hasField = true;
                }
            }

            return hasField;
        }

        public static bool SafeHasField(IEntityFields fields, string fieldName)
        {
            bool hasField = false;

            if (fields != null)
            {
                // Find returns null if property is not found.
                if (fields[fieldName] != null)
                {
                    hasField = true;
                }
            }

            return hasField;
        }

        public static void GenericFieldValidation(IEntity entity, int fieldIndex, object value)
        {
            if (value is string)
            {
                if (((string)value).Length > entity.Fields[fieldIndex].MaxLength)
                {
                    throw new ORMEntityValidationException(
                        string.Format
                            (
                            "The maximum number of characters for the field '{0}' is {1}. The number of characters entered was {2}."
                            , entity.Fields[fieldIndex].Name
                            , entity.Fields[fieldIndex].MaxLength,
                            ((string)value).Length
                            ),
                            entity
                        );
                }
            }
        }

        public static byte[] GetTimeStampValue(IEntity2 entity)
        {
            byte[] timestampValue = null;

            if (SafeHasField(entity, Const.ConstFieldNames.TimeStamp.ToString()))
            {
                timestampValue = (byte[])entity.Fields[Const.ConstFieldNames.TimeStamp.ToString()].CurrentValue;
            }

            return timestampValue;
        }

        public static void SetTimeStampValue(IEntity2 entity, byte[] timestampValue)
        {
            if (timestampValue != null && SafeHasField(entity, Const.ConstFieldNames.TimeStamp.ToString()))
            {
                //need to use ForcedCurrentValueWrite to bypass readonly checks
                entity.Fields[Const.ConstFieldNames.TimeStamp.ToString()].ForcedCurrentValueWrite(timestampValue);
            }
        }

        #region Class Property Declarations

        #endregion
    }
}
