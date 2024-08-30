using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
	[SerializeField] private string nomeDoLevelDoJogo;

	[SerializeField] private GameObject painelMenuInicial;

	[SerializeField] private GameObject PainelOpcoes;

	public void jogar()
	{
		SceneManager.LoadScene("Jogo");
	}

	public void AbrirOpcoes()
	{
		painelMenuInicial.SetActive(false);
		PainelOpcoes.SetActive(true);
	}

	public void FecharOpcoes()
	{
		PainelOpcoes.SetActive(false);
		painelMenuInicial.SetActive(true);
	}
	
	public void SairJogo()
	{
		Debug.Log("Sair Do Jogo");
		Application.Quit();
	}
}