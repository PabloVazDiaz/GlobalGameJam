using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puesto : MonoBehaviour
{

    public GameObject objetoTarea;
    public Collider2D ZonaInteraccion;
    public int cantidad;
    public int puntosPorFinalizar;
    private ObjetoLlevable go;

    public bool activado;
    public int realizados;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoltarObjetos()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Debug.Log($"{transform.TransformPoint(Vector3.zero)}");
            Instantiate(objetoTarea,ZonaInteraccion.transform.TransformPoint(Vector3.zero),Quaternion.identity);
        }
        activado = true;
        transform.Find("cerrado").gameObject.SetActive(false);
        transform.Find("abierto").gameObject.SetActive(true);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.tag == "Player" && activado)
        {
            Movimiento mov = collision.gameObject.GetComponent<Movimiento>();
            if (Input.GetButtonDown("Fire2-p"+ mov.numPlayer))
            {

                go = collision.gameObject.GetComponentInChildren<ObjetoLlevable>();
                if (go.completado)
                {
                    go.gameObject.transform.parent = null;
                    go.gameObject.SetActive(false);
                    RecibirObjeto(go);
                }
                else
                {
                    go = null;
                }


            }

        }

    }


    virtual public void RecibirObjeto(ObjetoLlevable objLlevable)
    {
        objLlevable = null;
        realizados++;
        CompletarTarea();
        if (realizados >= cantidad)
        {
            activado = false;
            transform.Find("cerrado").gameObject.SetActive(true);
            transform.Find("abierto").gameObject.SetActive(false);
        }
    }

    private void CompletarTarea()
    {
        //GameManager.puntos += puntosPorFinalizar;
    }
}
