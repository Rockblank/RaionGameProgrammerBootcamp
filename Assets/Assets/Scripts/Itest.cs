using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITest<T>
{
    string TestName { get; set;}

    void Log(T score);
}
