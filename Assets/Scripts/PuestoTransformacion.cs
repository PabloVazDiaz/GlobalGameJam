using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuestoTransformacion : Puesto
{
    public float maxPower;

    private GameObject objetoTareaTransformado;
    private float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* if(collision.tag=="Player"&& (collision as Player).objetollevado.completado)
         {
             RecibirObjeto();
         }
         */
    }


    
}
