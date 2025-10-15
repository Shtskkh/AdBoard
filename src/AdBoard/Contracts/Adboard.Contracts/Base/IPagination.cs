namespace Adboard.Contracts.Base;

/// <summary>
/// Позволяет использовать пагинацию
/// </summary>
public interface IPagination
{
    /// <summary>
    /// Размер выборки
    /// </summary>
    public int Size { get; set; }
    
    /// <summary>
    /// Страница
    /// </summary>
    public int Page { get; set; }
}