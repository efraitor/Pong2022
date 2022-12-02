using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Librería para poder acceder a los TextMeshPro

public class GoalZone : MonoBehaviour
{
    //Referencia para acceder al marcador de puntos
    public TextMeshProUGUI scoreText;
    //Variable para guardar los puntos marcados
    int score;

    //Antes de que empiece el juego
    private void Awake()
    {
        //Ponemos la puntuación en 0
        score = 0;
        //Cambiamos el texto de las puntuaciones al valor que tenga en ese momento el score
        scoreText.text = score.ToString();

        //Para transformar un int en un string de 3 maneras
        //scoreText.text = score + ""; le sumo un string vacío a ese int, luego ya todo es string
        //scoreText.text = score.ToString(); transformo(cast) del int en un string
        //scoreText.text = "Score: " + score; a un string le ponemos después un int, con lo cuál ya todo es string
    }

    //Método para detectar cuando algo ha entrado en el trigger(zona de gol)
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        //Solo aquellos gameObjects etiquetados como pelota, que hayan entrado en el trigger
        if (collision.gameObject.tag == "Ball")
        {
            //Para probar
            Debug.Log("Alguien ha marcado gol");
            //Sumo 1 a la puntuación
            score++; //score++ <-> score = score + 1 <-> score += 1
            //Cambiamos el texto de las puntuaciones al valor que tenga en ese momento el score
            scoreText.text = score.ToString();
            //Ejecuto el método de que se ha marcado un punto que está programado en el GameManager
            GameManager.sharedInstance.GoalScored();
        }
    }
}
