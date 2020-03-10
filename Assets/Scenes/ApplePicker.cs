using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 20f;
    public float leftAndRight = 10f;
    public float chanceToChangeDirections = 0.5f;
    public float seconSpawnApple = 1f;


    void Start()
    {
        Invoke("DropApple", 2f);
    }


    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x > leftAndRight)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (pos.x < -leftAndRight)
        {
            speed = Mathf.Abs(speed);
        }

    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", seconSpawnApple);

    }
}
