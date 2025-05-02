using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Game game;

    private void Update()
    {
        transform.Rotate(0, 0, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            game.AddCoin(1);
            Debug.Log("Монета собрана!");
            gameObject.SetActive(false);
        }
    }
}
