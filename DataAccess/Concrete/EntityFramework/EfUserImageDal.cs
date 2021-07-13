using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserImageDal : EfEntityRepositoryBase<UserImage, BugsContext>, IUserImageDal
    {
        public void ProfileImageDelete(UserImage userImage)
        {
            using (BugsContext context = new BugsContext())
            {
                var deletedEntity = context.Entry(userImage);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void ProfileImageAdd(UserImage userImage)
        {
            using (BugsContext context = new BugsContext())
            {
                var addedEntity = context.Entry(userImage);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
