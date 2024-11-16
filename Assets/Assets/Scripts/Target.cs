using System;
using UnityEngine;


public class Target : MonoBehaviour
{
    private LevelController levelController;

    public void Setup(LevelController controller)
    {
        levelController = controller;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hi targetDestroy is called");
        if(!other.gameObject.layer.Equals(LayerMask.NameToLayer("WatterTrigger")))
        return;

        levelController.TargetDestroyed();
        Destroy(gameObject);
    }
}