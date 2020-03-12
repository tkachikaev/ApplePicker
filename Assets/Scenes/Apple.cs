using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private float appleDestroy = -50f;
    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.y < appleDestroy)
        {
            Destroy(this.gameObject);
            ApplePicker applePicker = new ApplePicker();
            applePicker.AppleDestroyed();
        }
    }
}
