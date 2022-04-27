using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Abstract
{
    public interface IEntityService<T> where T:class,IEntity,new()
    {
        IDataResult<T> GetById(int id);
        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}
