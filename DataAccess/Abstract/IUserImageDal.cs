using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserImageDal : IEntityRepository<UserImage>
    {
        void Add(UserImage userImage);
        void ProfileImageAdd(UserImage userImage);
        void ProfileImageDelete(UserImage userImage);
    }
}
