using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileSystems;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;

        public UserImageManager(IUserImageDal userImageDal)
        {
            _userImageDal = userImageDal;
        }
        //[SecuredOperation("user,admin")]
        [CacheRemoveAspect("IUserImageService.Get")]
        [TransactionScopeAspect]
        public IResult Add(IFormFile file, UserImage userImage)
        {
            userImage.ImagePath = FileHelper.AddAsync(file);
            userImage.UserImageDate = DateTime.Now;
            _userImageDal.Add(userImage);
            return new SuccessResult(Message.PostAdded);
        }

        public IResult Delete(UserImage userImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _userImageDal.Get(p => p.UserId == userImage.UserId).ImagePath;
            IResult result = BusinessRules.Run(FileHelper.DeleteAsync(oldpath));

            if (result != null)
            {
                return result;
            }

            _userImageDal.Delete(userImage);
            return new SuccessResult(Message.PostDeleted);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<UserImage>> GetAll(Expression<Func<UserImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(filter));
        }

        public IDataResult<UserImage> GetById(int id)
        {

            return new SuccessDataResult<UserImage>(_userImageDal.Get(I => I.UserId == id));
        }
        public IResult ProfileImageAdd(IFormFile file, UserImage userImage)
        {
            userImage.ProfileImage = FileHelper.AddAsync(file);
            userImage.UserImageDate = DateTime.Now;
            _userImageDal.ProfileImageAdd(userImage);
            return new SuccessResult(Message.PostAdded);
        }

        public IResult ProfileImageDelete(UserImage userImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _userImageDal.Get(p => p.UserId == userImage.UserId).ProfileImage;
            IResult result = BusinessRules.Run(FileHelper.DeleteAsync(oldpath));

            if (result != null)
            {
                return result;
            }

            _userImageDal.Delete(userImage);
            return new SuccessResult(Message.PostDeleted);
        }

        [CacheRemoveAspect("IUserImageService.Get")]
        public IResult Update(IFormFile file, UserImage userImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _userImageDal.Get(p => p.UserId == userImage.UserId).ImagePath;
            userImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);
            userImage.UserImageDate = DateTime.Now;
            _userImageDal.Update(userImage);
            return new SuccessResult(Message.PostUpdated);
        }
    }
}
