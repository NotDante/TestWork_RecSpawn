using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    /// <summary>
    /// Перемещаем объект по позиции мыши
    /// </summary>
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        //Vector3 чтобы не улетеало за камеру
    }
}
