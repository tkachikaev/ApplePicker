using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketButotomy = 1.5f;
    public float basketPositionY = -14f;
    void Start()
    {
        for (int i = 0; i < numBasket; i++)
        {
            GameObject tBasket = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketPositionY + (basketButotomy * i);
            tBasket.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        // Координата Z камеры определяет, как далеко в трехмерном пространстве
        // находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси X в координату X указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
}
