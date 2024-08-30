using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoInimigo : MonoBehaviour
{
    public float velocidadeDoLaser;
    public int danoParaDar;

    // Start is called before the first frame update
    void Start()
    {
        // Verifique se o laser tem um Collider2D
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogError("O Laser não possui um Collider2D!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }

    private void MovimentarLaser()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisão detectada com: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colidiu com o Player");
            VidaDoJogador vidaDoJogador = other.gameObject.GetComponent<VidaDoJogador>();
            if (vidaDoJogador != null)
            {
                vidaDoJogador.MachucarJogador(danoParaDar);
            }
            else
            {
                Debug.LogError("O objeto Player não possui o componente VidaDoJogador!");
            }
            Destroy(this.gameObject);
        }
    }
}