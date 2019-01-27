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

    public GameObject[] spritesTransformaciones;

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

        for(int i = 0; i < spritesTransformaciones.Length; i++)
        {
            if(i != transformaciones)
            {
                spritesTransformaciones[i].SetActive(false);
            }
            else
            {
                spritesTransformaciones[i].SetActive(true);
            }
        }
        
        if (transformaciones >= maxTrans)
        {

            completado = true;
        }
    }
}
