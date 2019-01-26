using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {

    public float velocidad;
    bool trabajonevera = false;
    bool trabajococina = false;
    public Image tareanevera;
    public Image tareacocina;  
    float actividadnevera = 0;
    float actividadcocina;

    

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        


        
        
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

        if (trabajonevera == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                actividadnevera = actividadnevera + 0.01f;
                tareanevera.fillAmount = actividadnevera;
            }
        }

        if (trabajococina == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                actividadcocina = actividadcocina + 0.01f;
                tareacocina.fillAmount = actividadnevera;
            }
        }


    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "cocina")
        {
            trabajococina = true;
            tareacocina.fillAmount = actividadcocina;
        }
    }


}
