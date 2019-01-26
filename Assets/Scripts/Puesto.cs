using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puesto : MonoBehaviour
{

    public GameObject objetoTarea;
    public Collider2D ZonaInteracción;
    public int cantidad;
    public int puntosPorFinalizar;


    private bool activado;
    private int realizados;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmpezarTarea()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Instantiate(objetoTarea, ZonaInteracción.transform);
        }
        activado = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if(collision.tag=="Player"&& (collision as Player).objetollevado.completado)
        {
            RecibirObjeto();
        }
        */
    }


    private void RecibirObjeto()
    {
        realizados++;
        CompletarTarea();
        if (realizados >= cantidad)
        {
            activado = false;
        }
    }

    private void CompletarTarea()
    {
        //GameManager.puntos += puntosPorFinalizar;
    }
}
