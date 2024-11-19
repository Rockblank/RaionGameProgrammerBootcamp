using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyMovement : MonoBehaviour
{
    [SerializeField] float kecepatanAwan = 8f;
    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time*kecepatanAwan);
    }
}
