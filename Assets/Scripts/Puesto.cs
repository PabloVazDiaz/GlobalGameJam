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

    public bool activado;
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
            Debug.Log($"{transform.TransformPoint(Vector3.zero)}");
            Instantiate(objetoTarea,ZonaInteraccion.transform.TransformPoint(Vector3.zero),Quaternion.identity);
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
