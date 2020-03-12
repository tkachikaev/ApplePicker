using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 20f;
    public float leftAndRight = 10f;
    public float chanceToChangeDirections = 0.5f;
    public float seconSpawnApple = 1f;

    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketButotomy = 1.5f;
    public float basketPositionY = -14f;
    public List<GameObject> basketList;

    void Start()
    {
        
        Invoke("DropApple", 2f);
        basketList = new List<GameObject>();
        for (int i = 0; i < numBasket; i++)
        {
            GameObject tBasket = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketPositionY + (basketButotomy * i);
            tBasket.transform.position = pos;
            basketList.Add(tBasket);
        }
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

    public void AppleDestroyed()
    {
        GameObject[] appleArrey = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject appleGo in appleArrey)
        {
            Destroy(appleGo);    
        }

        int basketIndex = basketList.Count-1;
        GameObject tBasket = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasket);
    }
}
