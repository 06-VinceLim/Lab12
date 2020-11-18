using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject CoinCollected; //Reference for text to print
    public float speed; //Player speed
    private int TotalCoin; //Total coin
    private int cointCount; //Counting how many coin was counted
    // Start is called before the first frame update
    void Start()
    {
        TotalCoin = GameObject.FindGameObjectsWithTag("Coin").Length; //Counting total coins that's in the game via tags before the game start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //W to move forward
        {

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S)) //S to move backwards
        {

            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A)) //A to move left
        {

            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))//D to move right
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (TotalCoin == 0) // If total coin reaches 0 means you win
        {
            Debug.Log("Going OVER to new SCENE NOW!");
            SceneManager.LoadScene("WinScene");// Sends player to win screen
        }
        if (transform.position.y < -5) // If player's y postion falls below -5 it triggers the following if condition
        {
            Debug.Log("Going OVER to new SCENE NOW!"); 
            SceneManager.LoadScene("LoseScene");// Sends player to lose screen
        }
        TotalCoin = GameObject.FindGameObjectsWithTag("Coin").Length; //Counting total coins that's in the game via tags currently
        CoinCollected.GetComponent<Text>().text = "Coin Collected : " + cointCount; //printing how many coin collected

    }

    private void OnTriggerEnter(Collider other) // When touching an object with "OnTrigger" enabled you trigger the following conditions
    {
        if (other.gameObject.tag == "Coin") //If object touched has the tag "Coin" it will add your count collected and destory the coin
        {
            cointCount++;

            Destroy(other.gameObject);
        }
    }
}
