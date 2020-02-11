using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRectangle : MonoBehaviour
{
    public GameObject prefab; //Спавнящийся префаб
    public Material[] materials; //Список материалов, который будет присваиваться префабу рандомно
    public Camera MainCamera; //Основная камера относительно которой будет считаться точка клика

    void FixedUpdate()
    {
        //Если была нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            //Переносим в Вектор2 позицию клика
            Vector2 SpawnPoint = MainCamera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

            //Проверяем пространство вокруг клика
            Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(SpawnPoint.x - 0.5f, SpawnPoint.y + 0.25f), new Vector2(SpawnPoint.x + 0.5f, SpawnPoint.y - 0.25f));

            if (colliders.Length == 0) //Если пространство вокруг клика свободно
            {
                //Задаем рандомный материал 
                Renderer rend = prefab.GetComponent<Renderer>();
                rend.enabled = true;
                rend.sharedMaterial = materials[Random.Range(0, materials.Length)];

                //Спавн префаба в позиции клика
                GameObject newGameObject = Instantiate(prefab, SpawnPoint, prefab.transform.rotation);
                //Переименуем, чтобы было легче ориентироваться
                newGameObject.name = rend.sharedMaterial.name;
            }
        }

    }

}
