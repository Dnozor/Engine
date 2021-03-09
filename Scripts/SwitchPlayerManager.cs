using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerManager : MonoBehaviour
{
	[SerializeField] private bool currentPlayer = true;

	private Transform player1;
	private Transform player2;

	private const string PLAYER1_TAG = "Player1";
	private const string PLAYER2_TAG = "Player2";

	public bool CurrentPlayer
	{
        set
        {
			currentPlayer = value;
			SwitchPlayer();
        }
	}

	void Start()
    {
		player1 = GameObject.FindWithTag(PLAYER1_TAG).transform;
		player2 = GameObject.FindWithTag(PLAYER2_TAG).transform;

		if(player1 == null || player2 == null)
        {
			Debug.LogError("Initialization failed in : " + this.GetType().ToString());
			return;
        }

		SwitchPlayer();
    }

	void SwitchPlayer()
    {
		if (!currentPlayer) player2.position = player1.position;
		else player1.position = player2.position;

		player1.gameObject.SetActive(currentPlayer);
		player2.gameObject.SetActive(!currentPlayer);

		currentPlayer = !currentPlayer;
	}

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.S)) SwitchPlayer();
    }
}
