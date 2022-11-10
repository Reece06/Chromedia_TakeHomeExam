using System;
using System.Collections.Generic;
using System.Text;

namespace Chromedia_TakeHomeExam.Interface
{
    public interface ICache
    {
        T GetFromCache<T>(string key);
        void SetCache<T>(T obj, string key);
    }
}
