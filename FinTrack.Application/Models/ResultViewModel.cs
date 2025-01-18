using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinTrack.Application.Models;
public class ResultViewModel
{
    public ResultViewModel(bool isSuccess = true, string messsage = "")
    {
        IsSuccess = isSuccess;
        Messsage = messsage;
    }

    public bool IsSuccess { get; private set; }
    public string Messsage { get; private set; }
    public static ResultViewModel Success() => new();
    public static ResultViewModel Error(string message) => new(false, message);
}

public class ResultViewModel<T> : ResultViewModel
{
    public T Data { get; private set; }

    public ResultViewModel(T data, bool isSuccess = true, string messsage = "")
    {
        Data = data;
    }
    public static ResultViewModel<T> Success(T Data) => new(Data);
    public static ResultViewModel<T> Error(string message)
        => new(default, false, message);
}
