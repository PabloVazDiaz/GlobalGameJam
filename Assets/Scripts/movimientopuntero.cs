using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimientopuntero : MonoBehaviour
{
   

    public int numPlayer = 1;
    private float xMovement;
    private float yMovement;
    private Rigidbody2D rb;
    public float velocidad;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, -1.95f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        xMovement = Input.GetAxis($"Horizontal-p{numPlayer}");
        yMovement = Input.GetAxis($"Vertical-p{numPlayer}");



    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(xMovement, yMovement) * velocidad * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "botonjugar" && Input.GetButtonDown("Fire1-p" + numPlayer))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.tag == "botonsalirjuego" && Input.GetButtonDown("Fire1-p" + numPlayer))
        {
            Application.Quit();
        }

        if (collision.tag == "botonsalirmenu" && Input.GetButtonDown("Fire1-p" + numPlayer))
        {
            SceneManager.LoadScene(0);
        }
    }
}
