namespace Adboard.Domain.SeedWorks;

/// <summary>
/// Интерфейс для всех сущностей, обеспечивающий понимание, какой тип используется для первичного ключа сущности
/// </summary>
/// <typeparam name="TKey">Тип первичного ключа</typeparam>
public interface IEntity<TKey>
{
    TKey Id { get; set; }
}