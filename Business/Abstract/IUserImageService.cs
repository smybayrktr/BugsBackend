using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IResult Add(IFormFile file, UserImage userImage);

        IResult Delete(UserImage userImage);
        IResult Update(IFormFile file, UserImage userImage);
        IDataResult<List<UserImage>> GetAll(Expression<Func<UserImage, bool>> filter = null);
        IDataResult<UserImage> GetById(int id);
        IResult ProfileImageAdd(IFormFile file, UserImage userImage);
        IResult ProfileImageDelete(UserImage userImage);
    }
}
