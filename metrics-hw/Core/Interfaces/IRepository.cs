﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        IList<T> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime);

        //T GetById(int id);

        void Create(T item);

        //void Update(T item);

        //void Delete(int id);
    }

}
