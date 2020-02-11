using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateConnectionOnRec : MonoBehaviour
{
    //Объект на сцене создающий связи
    GameObject Connectioner;

    private void Start()
    {
        //Находим объект перед началом
        Connectioner = GameObject.Find("Connectioner");
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Если нажат Ctrl и при этом на объект кликнули смотрим какие места свободны в "создателе связи"
            Debug.Log("ENTER");
            CreateConnection crCon = Connectioner.GetComponent<CreateConnection>();
            if (crCon.FirstConed == null)
            {
            Debug.Log("FIRST IN");
                crCon.FirstConed = this.gameObject;
            }else if (crCon.SecondConed == null)
            {
            Debug.Log("SECOND IN");
            crCon.SecondConed = this.gameObject;
            }
        }
    }
}
