using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    // NOTE: Need to implement the functionality required for a life to be lost, aand said enemy to be destroyed, when the enemy reaches the other side of the screen

    // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
    public Transform[] enemySpawnLocations;
    
    // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
    public GameObject[] enemyReferences;

    // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
    int randomEnemySpawnLocations;

    // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
    int randomEnemyReferences;

    public Transform gameControllerTransform;

    public TextMeshProUGUI playerLivesText;

    public int playerLives = 3;

    public AudioClip playerLostALifeSound;

    public TextMeshProUGUI playerScoreText;

    public int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, 2.0f);

        playerLivesText.text = "Lives : " + playerLives.ToString();

        playerScoreText.text = "Score : " + playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    public void SpawnEnemy()
    {
        // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
        randomEnemySpawnLocations = Random.Range(0, enemySpawnLocations.Length);

        // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
        randomEnemyReferences = Random.Range(0, enemyReferences.Length);

        // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
        Instantiate(enemyReferences [randomEnemyReferences], enemySpawnLocations [randomEnemySpawnLocations].position, Quaternion.identity);
    }

    public void IncreasePlayerScore()
    {
        playerScore += 100;

        playerScoreText.text = "Score : " + playerScore.ToString();
    }

    public void DecreasePlayerLives()
    {
        playerLives--;

        playerLivesText.text = "Lives : " + playerLives.ToString();

        AudioSource.PlayClipAtPoint(playerLostALifeSound, gameControllerTransform.position);

        if (playerLives == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
