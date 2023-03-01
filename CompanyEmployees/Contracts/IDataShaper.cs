using System.Dynamic;
using Entities.Models;
namespace Contracts;

public interface IDataShaper<T>
{
    IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString);
    ShapedEntity ShapeData(T ShapedEntity, string fieldsString);
}
