namespace Adboard.Contracts.Errors;

/// <summary>
/// Модель ошибки
/// </summary>
public class ErrorDto
{
    /// <summary>
    /// Статус код ошибки
    /// </summary>
    public int StatusCode { get; set; }
    
    /// <summary>
    /// Текст ошибки
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// TraceID запроса
    /// </summary>
    public string TraceId { get; set; }
}