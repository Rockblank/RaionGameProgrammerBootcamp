using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
