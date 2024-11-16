using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonball : MonoBehaviour
{
    public float explosionRadius = 7.0f;
    public float explosionForce = 9.0f;
    public float explosionUpwarModifier = 1.0f;


    protected Rigidbody rgdbdy;
    public Animator anmtr;
    private static readonly int explodedhash = Animator.StringToHash("Exploded");

    private void Awake()
    {
        rgdbdy = GetComponent<Rigidbody>();
    }

    public virtual void SetUp(Vector3 fireforce)
    {
        rgdbdy.AddForce(fireforce, ForceMode.Impulse);
        rgdbdy.angularVelocity = new Vector3(Random.Range(-10, 10),Random.Range(-10, 10),Random.Range(-10, 10));
    }

    public void OnFinishedExplosionAnimation()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        rgdbdy.angularVelocity = Vector3.zero;
        rgdbdy.velocity = Vector3.zero;
        rgdbdy.isKinematic = true;
        rgdbdy.detectCollisions = false;
        
        anmtr.SetTrigger(explodedhash);

        Vector3 explosionPos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius, LayerMask.GetMask("Targets"));

        foreach (Collider hit in colliders)
        {
            Rigidbody collidedRgdbdy = hit.GetComponent<Rigidbody>();

            if (collidedRgdbdy != null)
            {
                collidedRgdbdy.AddExplosionForce(explosionForce,explosionPos,explosionRadius,explosionUpwarModifier,ForceMode.Impulse);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
