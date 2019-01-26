using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int EntreEventosTiempo;
    public List<Puesto> puestos;

    private float UltimoTiempo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - UltimoTiempo > EntreEventosTiempo)
        {
            puestos[Random.Range(0, puestos.Count)].EmpezarTarea();
            UltimoTiempo = Time.time;
        }
    }
}
