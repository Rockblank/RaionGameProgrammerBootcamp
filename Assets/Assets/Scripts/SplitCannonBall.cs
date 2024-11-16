using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCannonBall : cannonball
{
    private static readonly int SpecialAvailableHash = Animator.StringToHash("SpecialAvailable");
    private static readonly int SpecialUsedHash = Animator.StringToHash("SpecialUsed");

    public float splitTime = 0.005f;
    public float splitAngle = 20.0f;
    public cannonball simpleCannonBallPrefab;

    public override void SetUp(Vector3 fireforce)
    {
        base.SetUp(fireforce);
        anmtr.SetTrigger(SpecialAvailableHash);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        enabled = false;
    }

    private void SpawnSpliitCannonBall()
    {
        var position = transform.position;
        var forward = rgdbdy.velocity;

        var ball1Forward = Quaternion.AngleAxis(-splitAngle,Vector3.up) * forward;
        var ball1 = Instantiate(simpleCannonBallPrefab,position,Quaternion.identity);
        ball1.SetUp(ball1Forward);

        var ball2Forward = Quaternion.AngleAxis(splitAngle,Vector3.up) * forward;
        var ball2 = Instantiate(simpleCannonBallPrefab,position,Quaternion.identity);
        ball2.SetUp(ball2Forward);

        //animatortrigger
        anmtr.SetTrigger(SpecialUsedHash);
        enabled = false;
        Debug.Log("Oi im alive");
    }

    private void Update()
    {
        splitTime -= Time.deltaTime;
        if (splitTime <= 0)
        {
            SpawnSpliitCannonBall();
        }
    }
}
