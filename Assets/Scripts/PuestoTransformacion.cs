using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuestoTransformacion : Puesto
{
    public float maxPower;
    public int transTarget;

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
        if (collision.tag == "Player" && (collision.gameObject.GetComponentInChildren<ObjetoLlevable>()).transformaciones==transTarget)
        {
            
            ObjetoLlevable go = collision.gameObject.GetComponentInChildren<ObjetoLlevable>();
            RecibirObjeto(go);
        }
    }

    public void RecibirObjeto( ObjetoLlevable objLlevable)
    {
        objLlevable.Transformar();
    }

}
