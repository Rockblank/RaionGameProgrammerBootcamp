using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesScript : MonoBehaviour
{
    public Transform baseObject;
    public Transform barrel;
    public float minXroation;
    public float maxXrotation;
    public float minYrotation;
    public float maxYrotation;
    public float kecepatanRotasi;

    // Update is called once per frame
    void Update()
    {
        aimCannon();
    }
    void aimCannon()
    {
        float currentYRotation = NormalizeAngle(baseObject.localRotation.eulerAngles.y);

        float rotasiBaseBaru = currentYRotation + kecepatanRotasi * Input.GetAxis("Mouse X");
        rotasiBaseBaru = Mathf.Clamp(rotasiBaseBaru, minYrotation, maxYrotation);
        baseObject.localRotation = Quaternion.Euler(0,rotasiBaseBaru,0);
    }
    float NormalizeAngle(float angle)
    {
        while (angle > 180) angle -= 360;
        while (angle > 180) angle += 360;
        return angle;
    }
}
