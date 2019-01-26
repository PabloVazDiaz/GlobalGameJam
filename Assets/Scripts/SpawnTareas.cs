using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnTareas : MonoBehaviour
{
    public int EntreEventosTiempo;
    public List<Puesto> puestos;

    private float UltimoTiempo;

    // Start is called before the first frame update
    void Start()
    {
        UltimoTiempo = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - UltimoTiempo > EntreEventosTiempo)
        {
            if(puestos.Where(x => x.activado == false).Any())
            {
                puestos.Where(x => x.activado == false).ToList()[Random.Range(0, puestos.Where(x => x.activado == false).ToList().Count)].SoltarObjetos();
                UltimoTiempo = Time.time;
            }
            
        }
    }
}