using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public GameObject First; //Первый соединяемый объект
    public GameObject Second; //Второй соединяемый объект

    void LateUpdate()
    {
        //Если оба объекта на месте
        if (First != null && Second != null)
        {
            //Отслежевыаем положение объектов и рендерим линию между их центрами
            LineRenderer render = this.GetComponent<LineRenderer>();
            render.SetPositions(new Vector3[2] { First.transform.position, Second.transform.position });
        } else
        {
            //Если один из объектов удален - удаляем связь
            Destroy(this.gameObject);
        }
    }
}
