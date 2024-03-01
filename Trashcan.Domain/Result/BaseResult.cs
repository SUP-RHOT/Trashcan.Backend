namespace Trashcan.Domain.Result;

/*
/// <summary>
/// 
/// </summary>
public class BaseResult
{
    /// <summary>
    /// 
    /// </summary>
    public bool IsSuccess => String.IsNullOrEmpty(ErrorMassage);
    
    /// <summary>
    /// 
    /// </summary>
    public string ErrorMassage { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? ErrorCode { get; set; }
}*/

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseResult<T> // : BaseResult
{
    /// <summary>
    /// 
    /// </summary>
    public BaseResult()
    {
    }
    
    /*/// <summary>
    /// 
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <param name="errorCode"></param>
    /// <param name="data"></param>
    public BaseResult(string errorMessage, int errorCode, T data)
    {
        ErrorCode = errorCode;
        ErrorMassage = errorMessage;
        Data = data;
    }*/

    /// <summary>
    /// 
    /// </summary>
    public bool IsSuccess => String.IsNullOrEmpty(ErrorMassage);
    
    /// <summary>
    /// 
    /// </summary>
    public string ErrorMassage { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? ErrorCode { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public T Data { get; set; }
}