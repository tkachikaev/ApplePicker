using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("SetDynamically")]
    public Text scoreGT;
    void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");

        scoreGT = scoreGo.GetComponent<Text>();
        scoreGT.text = "0";
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

    private void OnCollisionEnter(Collision collision)
    {
        //Ищем яблоко
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score += 10;
            scoreGT.text =  +score.ToString();
            
            
        }
    }
}
