using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);//key vericez bellekten keye karsilik gelen data cekicez
                            
        object Get(string key); 


        void Add(string key , object value,int duration);//obje base herseyin

        bool IsAdd(string key);//cache data var mi&
        void Remove(string key);
        void RemoveByPattern(string pattern);//verdigimiz ile baslayan biten gibi    

    }
}
