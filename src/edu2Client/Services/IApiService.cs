using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edu2Client.Services
{
    interface IApiService
    {
        public Task<T> GetAsync<T>(string url);
    }
}
