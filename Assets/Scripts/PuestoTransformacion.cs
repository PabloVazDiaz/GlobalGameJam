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
    public bool automatico;

    private float UltimoTiempo;
    private ObjetoLlevable go;

    private GameObject objetoTareaTransformado;
    private float power;
    public float cantidadPorClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (automatico && activado)
        {
            barra.fillAmount +=  Time.deltaTime / EntreEventosTiempo ;
        }
        if (Time.time - UltimoTiempo > EntreEventosTiempo && activado && automatico)
        {
            activado = false;
            go.gameObject.SetActive(true);
            go = null;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !activado) 
        {

            if (Input.GetKeyDown(KeyCode.Comma))
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
        if(collision.tag == "Player" && activado && !automatico)
        {
            if (Input.GetButtonDown($"Fire1-p1"))
            {
                barra.fillAmount += cantidadPorClick;
                if (barra.fillAmount >= 1)
                {
                    activado = false;
                    go.gameObject.SetActive(true);
                    go = null;
                    barra.fillAmount = 0;
                }
            }
        }
	    
    }

    override public void RecibirObjeto( ObjetoLlevable objLlevable)
    {
        activado = true;
        objLlevable.Transformar();
        UltimoTiempo = Time.time;
    }



}
