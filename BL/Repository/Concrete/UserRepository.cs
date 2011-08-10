using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private IMappingEngine MappingEngine { get; set; }

        #endregion

        public UserRepository(IEntitiesModel entitiesModel, IMappingEngine mappingEngine)
        {
            EntitiesModel = entitiesModel;
            MappingEngine = mappingEngine;
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

        public IUser GetByUsername(string username)
        {
            IUserEntity userEntity = (from c in EntitiesModel.Users where c.Username == username select c).Single();
            return MappingEngine.Map<IUserEntity, IUser>(userEntity);
        }

        public bool UpdatePassword(IUser user, string newPassword)
        {
            bool isSuccess = false;

            try
            {
                IUserEntity userEntity = (from c in EntitiesModel.Users where c.PkId == user.PkId select c).Single();
                userEntity.Password = newPassword;
                EntitiesModel.SaveChanges();

                isSuccess = true;
            }
            catch (Exception)
            {
            }

            return isSuccess;
        }
    }
}
