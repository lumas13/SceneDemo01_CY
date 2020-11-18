using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController01 : MonoBehaviour
{
    float speed = 10.0f;
    int gameScoreCounter = 10;
    int totalPowerUpLeft;
    
    public GameObject gamescore0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalPowerUpLeft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Debug.Log("Total PU left: " + totalPowerUpLeft.ToString());

        if (totalPowerUpLeft == 0)
        {
            Debug.Log("Going over to END SCREEN!");
            SceneManager.LoadScene("EndScene");
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameScoreCounter--;
            gamescore0.GetComponent<Text>().text = "Game Score: " + gameScoreCounter;

            if (gameScoreCounter == 0)
            {
                Debug.Log("Going OVER to new SCENE NOW!");
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            gameScoreCounter += 100;
            gamescore0.GetComponent<Text>().text = "Game Score: " + gameScoreCounter.ToString();

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}

