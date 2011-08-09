using System;
using System.Collections.Generic;
using System.Linq;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Repository.Abstract;
using CCE.WebConnection.DAL;
using CCE.WebConnection.DAL.Abstract;

namespace CCE.WebConnection.BL.Repository.Concrete
{
    public class UserRepository : IUserRepository 
    {
        #region Properties

        public IEntitiesModel EntitiesModel { get; set; }

        #endregion

        public UserRepository(IEntitiesModel entitiesModel)
        {
            EntitiesModel = entitiesModel;
        }

        public IEnumerable<IUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IUser GetByID(int pkID)
        {
            throw new NotImplementedException();
        }

        public void Save(IUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int pkID)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUser(string username, string password)
        {
            bool isValid = false;

            IQueryable<IUserEntity> userEntities = (from c in EntitiesModel.Users where c.Username == username && c.Password == password select c);

            if (userEntities.Count() > 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
