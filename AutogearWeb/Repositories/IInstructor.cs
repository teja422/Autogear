using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AutogearWeb.EFModels;

namespace AutogearWeb.Repositories
{
    public interface IInstructor : IDisposable
    {
        autogearEntities DataContext { get; set; }

        IList<Instructor> GetInstructorList();

    }
}
