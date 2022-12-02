using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Librer�a para poder acceder a los TextMeshPro
using UnityEngine.UI; //Librer�a para acceder a los componentes de la UI

public class GameManager : MonoBehaviour
{
    //Referencias a los objetos que queremos que se activen o desactiven
    public GameObject ball;
    public GameObject racketLeft;
    public GameObject racketRight;
    public GameObject dottedLine;
    public TextMeshProUGUI leftScore;
    public TextMeshProUGUI rightScore;
    public TextMeshProUGUI title;
    public Button startButton;

    //Referencia para guardar la direcci�n de la pelota
    Vector2 direction;

    //Creamos un Singleton
    public static GameManager sharedInstance;

    private void Awake()
    {
        //Si la instancia est� vac�a
        if (sharedInstance == null)
            //Rellenal� con todo el c�digo que est� dentro de este Script
            sharedInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // M�todo para que el juego empiece al pulsar el bot�n
    public void StartGame()
    {
        //Al inicio del juego activamos y desactivamos los objetos que queremos
        title.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        dottedLine.gameObject.SetActive(true);
        racketLeft.gameObject.SetActive(true);
        racketRight.gameObject.SetActive(true);
        ball.gameObject.SetActive(true);
        leftScore.gameObject.SetActive(true);
        rightScore.gameObject.SetActive(true);
    }

    //M�todo para hacer lo que ocurre al marcar un punto
    public void GoalScored()
    {
        //Ponemos la pelota al marcar un gol en la posici�n de origen
        ball.transform.position = Vector2.zero; //Vector2.zero; <-> new Vector2(0,0);

        //Aqu� guardamos la velocidad en X que llevaba la pelota e invertimos su signo
        direction = new Vector2(-ball.GetComponent<Rigidbody2D>().velocity.x, 0);

        //Paramos la pelota
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //Usando Invoke esperamos X segundos antes de llamar a un m�todo
        Invoke("LaunchBall", 2.0f); //Le decimos el m�todo que quiero invocar y el tiempo que tiene que pasar en segundos para que eso suceda
    }

    //M�todo para hacer que la bola se lance
    void LaunchBall()
    {
        //Aplicamos esa nueva direcci�n en la bola
        ball.GetComponent<Rigidbody2D>().velocity = direction;
    }
}
