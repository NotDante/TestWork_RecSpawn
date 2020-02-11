using UnityEngine;

/// <summary>
/// Скрипт создания связи
/// </summary>
public class CreateConnection : MonoBehaviour
{
    public GameObject FirstConed; //Первый связуемый объект
    public GameObject SecondConed;//Второй связуемый объект

    public GameObject Line; //Префаб линии

    private void Update()
    {
        //Проверяем нажат ли Ctrl
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Если нажат и у нас есть оба объекта, то переходим к созданию связи
            if (FirstConed != null && SecondConed != null)
            {
                //Спавним линию и создаем связь
                GameObject newLine = Instantiate(Line);
                Connection con = newLine.GetComponent<Connection>();
                con.First = FirstConed.gameObject;
                con.Second = SecondConed.gameObject;

                //Обнуляем первый и второй объекты для следующей связи 
                //Можно переделать скрипт, обнулив только первый объект и поместив на его место второй
                //Тогда можно будет создавать цепочки связей 
                FirstConed = null;
                SecondConed = null;
                Debug.Log("Nulled");
            }

            Debug.Log("Pressed");
        } else
        {
            //Если Ctrl отпустили, то оба объекта обнуляются
            FirstConed = null;
            SecondConed = null;
            Debug.Log("Nulled");
        }
    }
}
