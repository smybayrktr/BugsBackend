using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserImage : IEntity
    {
        public int UserImageId { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public string ProfileImage { get; set; }
        public DateTime UserImageDate { get; set; }
    }
}
