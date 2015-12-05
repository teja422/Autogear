using System;
using AutogearWeb.EFModels;

namespace AutogearWeb.Repositories
{
    public interface ILogin : IDisposable
    {
        autogearEntities DataContext { get; set; }


    }
}
