using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform currentPlayer;

    private Transform player1;
    private Transform player2;

    private const string PLAYER1_TAG = "Player1";
    private const string PLAYER2_TAG = "Player2";

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindWithTag(PLAYER1_TAG).transform;
        player2 = GameObject.FindWithTag(PLAYER2_TAG).transform;

        if (player1 == null || player2 == null)
        {
            Debug.LogError("Initialization failed in : " + this.GetType().ToString());
            return;
        }

        SwitchPlayer();
    }

    void SwitchPlayer()
    {
        if (currentPlayer == null) currentPlayer = player2;

        var currenPosition = currentPlayer.position;
        currentPlayer.gameObject.SetActive(false);

        currentPlayer = currentPlayer.Equals(player1) ? player2 : player1;
        currentPlayer.position = currenPosition;

        currentPlayer.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SwitchPlayer();
    }
}
