using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeilaoGraff.Models
{
    public abstract class Entidade<TId, TEntity> :
        AbstractValidator<TEntity>
        where TId : struct
        where TEntity : Entidade<TId, TEntity>
    {
        public TId Id { get; protected set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool Validar();

        protected Entidade()
        {
            Id = default(TId);
            ValidationResult = new ValidationResult();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entidade<TId, TEntity>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entidade<TId, TEntity> a, Entidade<TId, TEntity> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entidade<TId, TEntity> a, Entidade<TId, TEntity> b) => !(a == b);

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => GetType().Name + " [Id=" + Id + "]";
    }
}
