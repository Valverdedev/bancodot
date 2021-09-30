using bancodot.Domain.Entities;
using FluentValidation;


namespace bancodot.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        public interface IBaseService<TEntity> where TEntity : BaseEntity
        {
            TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

            void Delete(int id);


            TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        }
    }
}
