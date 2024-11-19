using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletspeed;
    public Animator bulletAnimator;
    private Vector3 direction;
    public void setDirection (Vector3 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.position += direction*bulletspeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        bulletAnimator.SetTrigger("Exploded");
    }
    public void OnFinishedExplosionAnimation()
    {
        Destroy(gameObject);
    }
}
