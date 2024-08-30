using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{
    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;
    public bool temEscudo;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Fogo")
        {
            MachucarJogador(1);
        }
    }

    public void MachucarJogador(int danoParaReceber)
    {
        if (!temEscudo)
        {
            vidaAtualDoJogador -= danoParaReceber;
            if (vidaAtualDoJogador <= 0)
            {
                Debug.Log("Game Over");
                Destroy(gameObject);
            }
        }
    }
}
