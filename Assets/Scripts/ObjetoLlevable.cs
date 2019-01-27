using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoLlevable : MonoBehaviour
{

    public int maxTrans;
    public Sprite targetSprite; 
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


    public void Transformar(Sprite transfSprite)
    {
        transformaciones++;
        targetSprite = transfSprite;
        if (transformaciones >= maxTrans)
        {

            completado = true;
        }
    }
}
