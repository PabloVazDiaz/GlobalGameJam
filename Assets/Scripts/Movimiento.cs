using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {

    public float velocidad;
    public Canvas playerCanvas;
    public Image showSprite;
    public int numPlayer = 1;
    public Image tarealavadora;
    private GameObject objetoColisionado;
    private GameObject objetoSujetado;
    public GameObject personaje;
    public float contador;
    public Sprite[] sprites;
    public SpriteRenderer spriterRender;
    private Rigidbody2D rb;
    private float xMovement;
    private float yMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterRender.sprite = sprites[Random.Range(0, sprites.Count())];
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        xMovement = Input.GetAxis($"Horizontal-p{numPlayer}");
        yMovement = Input.GetAxis($"Vertical-p{numPlayer}");


        if (Input.GetAxis("Horizontal-p"+numPlayer) > 0)
        {
            transform.localScale = new Vector3(-0.3413753f, 0.8599529f, -5f);
        }


        if (Input.GetAxis("Horizontal-p"+numPlayer) < 0)
        {
            transform.localScale = new Vector3(0.3413753f, 0.8599529f, -5f);
        }
    
        if (Input.GetButtonDown("Fire1-p"+numPlayer))
        {
            if (this.GetComponentInChildren<ObjetoLlevable>() != null)
            {
                objetoSujetado.transform.position = new Vector3(objetoSujetado.transform.position.x, objetoSujetado.transform.position.y, 0f);
                objetoSujetado.transform.parent = null;
                objetoSujetado = null;
               
            }
            if (objetoColisionado != null && objetoColisionado.tag == "objetocogible" && transform.localScale.x >= 0)
            {
                objetoSujetado = objetoColisionado;
                objetoSujetado.transform.parent = transform;
                objetoSujetado.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.25f, - 1);
                //StopAllCoroutines();
                StartCoroutine(Bocadillo(2f, objetoSujetado.GetComponent<ObjetoLlevable>().targetSprite));
                
            }
            if (objetoColisionado != null && objetoColisionado.tag == "objetocogible" && transform.localScale.x < 0)
            {
                objetoSujetado = objetoColisionado;
                objetoSujetado.transform.parent = transform;
                objetoSujetado.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y - 0.25f, -1);
                //StopAllCoroutines();
                StartCoroutine(Bocadillo(2f, objetoSujetado.GetComponent<ObjetoLlevable>().targetSprite));
            }
        }
    }

    private void Move()
    {
        Vector2 movement = new Vector2(xMovement, yMovement) * velocidad * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        
    }

    IEnumerator Bocadillo(float seconds, Sprite sprite)
    {
        Image[] images= playerCanvas.GetComponentsInChildren<Image>();
        Image image = images[1];
        image.sprite = sprite;
        playerCanvas.enabled = !playerCanvas.enabled;
        yield return new WaitForSeconds(seconds);
        playerCanvas.enabled = !playerCanvas.enabled;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "objetocogible")
        {
            objetoColisionado = collision.gameObject;
        }
              
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        objetoColisionado = null;
        
            
    }

}

  
    