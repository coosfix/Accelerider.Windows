﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Refit;

namespace Accelerider.Windows.Models
{
    [Headers("User-Agent: Accelerider.Windows.Wpf: v1.0.0-pre",
             "Accept-Language: en-US")]
    internal interface IAcceleriderApi
    {
        // Accelerider account functions ------------------------------------------------
        [Get("/users/current")]
        Task<AcceleriderUser> GetCurrentUser();

        [Patch("/users/current")]
        Task UpdateUserInfoAsync([Body] AcceleriderUserUpdateInfo updateInfo);

        [Delete("/tokens/{id}")]
        Task SignOutAsync(long id);

        // App store functions ----------------------------------------------------------
        [Get("/apps/children")]
        Task<IList<AcceleriderModule>> GetAllAppInfoAsync();

        [Get("/apps/{id}")]
        Task<AcceleriderModule> GetAppInfoByIdAsync(long id);

        [Get("/apps/{id}/content")]
        Task<Stream> GetAppByIdAsync(long id);
    }
}
