using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuestoTransformacion : Puesto
{
    public float maxPower;
    public int transTarget;
    public Image barra;
    public int EntreEventosTiempo;

    private float UltimoTiempo;
    private ObjetoLlevable go;

    private GameObject objetoTareaTransformado;
    private float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - UltimoTiempo > EntreEventosTiempo && activado)
        {
            activado = false;
            go.gameObject.SetActive(true);
            go = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"  &&  !activado);
        {

            if(Input.GetKeyDown(KeyCode.Comma))
            {
                if (!activado)
                {
                    go = collision.gameObject.GetComponentInChildren<ObjetoLlevable>();
                    if (go.transformaciones == transTarget)
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
    }

    public void RecibirObjeto( ObjetoLlevable objLlevable)
    {
        activado = true;
        objLlevable.Transformar();
        UltimoTiempo = Time.time;
    }



}
