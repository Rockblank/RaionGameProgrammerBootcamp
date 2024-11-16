using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test : MonoBehaviour, ITest<string>
{
    public string TestName { get; set;}

    public void Log(string score)
    {
        Debug.Log($"{DateTime.Now} | {TestName} | {score}");
    }

    private void Awake()
    {
        Log("Nigga im King");
    }
}
