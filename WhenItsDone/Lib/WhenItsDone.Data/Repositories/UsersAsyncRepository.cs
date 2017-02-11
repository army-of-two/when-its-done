﻿using System.Linq;

using AutoMapper;

using Bytes2you.Validation;

using WhenItsDone.Data.Contracts;
using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Repositories
{
    public class UsersAsyncRepository : GenericAsyncRepository<User>, IUsersAsyncRepository, IAsyncRepository<User>
    {
        public UsersAsyncRepository(IWhenItsDoneDbContext dbContext)
            : base(dbContext)
        {
        }

        public UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();

            return this.DbSet.Where(user => user.Username == username).ProjectToFirstOrDefault<UsernameProfilePictureUserViewDTO>();
        }


        public MedicalInformationUserViewDTO GetCurrentUserMedicalInformation(string username)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();

            return this.DbSet.Where(user => user.Username == username).ProjectToFirstOrDefault<MedicalInformationUserViewDTO>();
        }
    }
}
