using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawn : MonoBehaviour
{
    private float timerForDoubleClick = 0.0f; //Таймер для клика
    public float delay = 0.3f; //Врем ожидания второго клика
    private bool isDoubleClick = false; //клик трекер

    private void Update()
    {
        if (isDoubleClick == true) 
        {
            timerForDoubleClick += Time.deltaTime; //Увеличиваем таймер с каждым фреймом
        }

        if (timerForDoubleClick >= delay) //Если таймер перевалил за время ожидания
        {
            timerForDoubleClick = 0.0f; //Сброс таймера
            isDoubleClick = false; //Сброс клик трекера
        }
    }

    /// <summary>
    /// Детектор клика и провекра первый ли это клик
    /// </summary>
    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1") && isDoubleClick == false)
        {
            isDoubleClick = true; //Клик трекер вклчен
        }
    }

    /// <summary>
    /// Детектор второго клика
    /// </summary>
    private void OnMouseDown()
    {
        //Проверим так же не нажат ли CTRL так как если не проводить эту проверку, то объект может быть случайно удален при создании связи
        if (isDoubleClick == true && timerForDoubleClick < delay && !Input.GetKey(KeyCode.LeftControl)) //Если клик трекер включен и и время делея не пересечено
        {
            Destroy(this.gameObject);
        }
    }
}
