using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoLlevable : MonoBehaviour
{

    public int maxTrans;

    public int transformaciones;
    public bool completado;

    // Start is called before the first frame update
    void Start()
    {
        transformaciones = 0;
        completado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Transformar()
    {
        Debug.Log($"{transformaciones}");
        transformaciones++;
        
        if (transformaciones >= maxTrans)
        {

            completado = true;
        }
    }
}
