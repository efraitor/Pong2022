using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Velocidad de la bola
    public float speed = 25;

    // Start is called before the first frame update
    void Start()
    {
        //La bola se mueve a la derecha
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed; //Vector2.right = new Vector2(1,0)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * El objeto collision del paréntesis contiene la información del choque
     * En particular, nos interesa saber cuando choca con una pala.
     * -collision.gameObject: tiene información del objeto contra el cual he colisionado (raqueta)
     * -collision.transform.position: tiene información de la posición (raqueta)
     * -collision.collider: tiene información del collider (raqueta)
     */
    /*Es un método de Unity que detecta colisión entre dos GO. 
     * Al chocar el objeto contra el que choca le pasa su Colisión por parámetro */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si la pelota ha colisionado con la pala izquierda
        if (collision.gameObject.name == "RacketLeft")
        {
            //Obtenemos el factor de golpeo, pasándole la posición de la pelota, la posición de la pala, y lo que mide de alto el collider de la pala (es decir, lo que mide la pala)
            float yF = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            /*Le damos una nueva dirección a la pala
             * En este caso con una X a la derecha
             * Y nuestro factor de golpeo calculado
             * Normalizado todo el vector a 1, para que la bola no acelere*/
            Vector2 direction = new Vector2(1, yF).normalized;
            //Le decimos a la bola que salga con esa velocidad previamente calculada
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    /*
     * 1 - La bola choca contra la parte superior de la raqueta
     * 0 - La bola choca contra el centro de la raqueta
     * -1 - La bola choca contra la parte inferior de la raqueta
    */
    /*Es un método de tipo 3. En este caso le pasamos 3 parámetros:
     * - posición actual de la pelota
     * - posición actual de la pala
     * - altura de la pala
     * Y el método tal y como le indicamos nos devuelve un variable de tipo float */
    private float HitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}
