using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {

    public float velocidad;

    public int numPlayer = 1;
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

        transform.Translate(Vector2.right * Input.GetAxis("Horizontal-p"+numPlayer) * velocidad * Time.deltaTime);
        transform.Translate(Vector2.up * Input.GetAxis("Vertical-p"+numPlayer) * velocidad * Time.deltaTime);

        if (transform.position.x < -7.312342f)
        {
            transform.position = (new Vector3(-7.312342f, transform.position.y,-0.5f));
        }

        if (transform.position.x > 7.312342f)
        {
            transform.position = (new Vector3(7.312342f, transform.position.y,-0.5f));
        }

        if (transform.position.y > 3.422362f)
        {
            transform.position = (new Vector3(transform.position.x, 3.422362f, -0.5f));
        }

        if (transform.position.y < -3.535445f)
        {
            transform.position = (new Vector2(transform.position.x, -3.535445f));
        }

        if (Input.GetAxis("Horizontal-p"+numPlayer) > 0)
        {
            transform.localScale = new Vector3(-0.5011851f, 1.262527f, 1f);
        }


        if (Input.GetAxis("Horizontal-p"+numPlayer) < 0)
        {
            transform.localScale = new Vector3(0.5011851f, 1.262527f, 1f);
        }

        if (trabajolavadora == true)

            if (Input.GetButtonDown("Fire1-p"+numPlayer))
            {
                actividadlavadora = actividadlavadora + 0.01f;
                tarealavadora.fillAmount = actividadlavadora;
            }
    

        if (Input.GetButtonDown("Fire1-p"+numPlayer))
        {
            if (this.GetComponentInChildren<ObjetoLlevable>() != null)
            {
                objetoSujetado.transform.position = new Vector3(objetoSujetado.transform.position.x, objetoSujetado.transform.position.y, 0f);
                objetoSujetado.transform.parent = null;
                objetoSujetado = null;
               
            }
            if (objetoColisionado != null && objetoColisionado.tag == "objetocogible" && transform.localScale.x > 0)
            {
                objetoSujetado = objetoColisionado;
                objetoSujetado.transform.parent = transform;
                objetoSujetado.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, - 1);
            }
            if (objetoColisionado != null && objetoColisionado.tag == "objetocogible" && transform.localScale.x < 0)
            {
                objetoSujetado = objetoColisionado;
                objetoSujetado.transform.parent = transform;
                objetoSujetado.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, -1);
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

  
    