using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public GameObject laserDoJogador;
    public Transform localDoDisparoUnico;
    public float velocidadeDoNave;
    public bool temLaserDuplo;
    public float tempoEntreDisparos = 0.5f; // Tempo de recarga entre disparos
    public int vidaDoJogador = 3; // Vida inicial do jogador
    public GameObject Fogo; // Prefab do fogo

    private Vector2 teclasApertadas;
    private float proximoDisparo = 0f; // Tempo para o próximo disparo

    void Start()
    {
        temLaserDuplo = false;
    }

    void Update()
    {
        MovimentarJogador();
        AtirarLaser(); // Chamar o método AtirarLaser aqui
    }

    private void MovimentarJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.velocity = teclasApertadas.normalized * velocidadeDoNave;
    }

    private void AtirarLaser()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= proximoDisparo)
        {
            Debug.Log("Atirou");
            if (temLaserDuplo == false)
            {
                Debug.Log("Disparando laser único");
                Instantiate(laserDoJogador, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }
            proximoDisparo = Time.time + tempoEntreDisparos; // Atualiza o tempo para o próximo disparo
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Fogo)
        {
            vidaDoJogador -= 1; // Reduz a vida do jogador em 1
            Debug.Log("Jogador levou dano! Vida restante: " + vidaDoJogador);
            Destroy(collision.gameObject); // Destroi o prefab do fogo

            if (vidaDoJogador <= 0)
            {
                Debug.Log("Jogador morreu!");
                // Adicione aqui a lógica para quando o jogador morrer, como reiniciar o jogo ou mostrar uma tela de game over
            }
        }
    }
}
