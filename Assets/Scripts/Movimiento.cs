using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {

    public float velocidad;

    bool trabajolavadora = false;
    public Image tarealavadora;
    float actividadlavadora = 0;
    private GameObject objetoColisionado;
    private GameObject objetoSujetado;
    public GameObject personaje;
    bool sujetar = false;
    bool hijo = false;
    public float contador;
    void Update()
    {

        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);
        transform.Translate(Vector2.up * Input.GetAxis("Vertical") * velocidad * Time.deltaTime);

        if (transform.position.x < -8.37)
        {
            transform.position = (new Vector2(-8.37f, transform.position.y));
        }

        if (transform.position.x > 8.37)
        {
            transform.position = (new Vector2(8.37f, transform.position.y));
        }

        if (transform.position.y > 4.1)
        {
            transform.position = (new Vector2(transform.position.x, 4.1f));
        }

        if (transform.position.y < -4.8)
        {
            transform.position = (new Vector2(transform.position.x, -4.8f));
        }

        if (trabajolavadora == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                actividadlavadora = actividadlavadora + 0.01f;
                tarealavadora.fillAmount = actividadlavadora;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.GetComponentInChildren<ObjetoLlevable>() != null)
            {
                objetoSujetado.transform.parent = null;
                objetoSujetado = null;
            }
            else if (objetoColisionado != null && objetoColisionado.tag=="objetocogible")
            {
                objetoSujetado = objetoColisionado;
                objetoSujetado.transform.parent = transform;
                objetoSujetado.transform.position = transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objetoColisionado = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objetoColisionado = null;
    }

}

  
    