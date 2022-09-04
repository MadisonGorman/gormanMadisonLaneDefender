using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
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
        // Continuously spawns enemies with an established delay between each
        InvokeRepeating("SpawnEnemy", 1.0f, 3.0f);

        // Provides the Lives and Score Texts with distinct in-game appearances, reflective of the initial values, defined above
        playerLivesText.text = "Lives : " + playerLives.ToString();
        playerScoreText.text = "Score : " + playerScore.ToString();
    }

    // Update is called once per frame
    // Upon pressing the R key, the game restarts
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    // Spawns a random enemy at a random spawn location
    public void SpawnEnemy()
    {
        // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
        randomEnemySpawnLocations = Random.Range(0, enemySpawnLocations.Length);

        // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
        randomEnemyReferences = Random.Range(0, enemyReferences.Length);

        // Referenced: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." by Alexander Zotov
        Instantiate(enemyReferences [randomEnemyReferences], enemySpawnLocations [randomEnemySpawnLocations].position, Quaternion.identity);
    }

    // Enables the player's score to be increased by a defined value and updated in-game
    public void IncreasePlayerScore()
    {
        playerScore += 100;

        playerScoreText.text = "Score : " + playerScore.ToString();
    }

    // Enables the player's lives to be decreased by 1 and updated in-game; a sound accompanies the loss of a life
    public void DecreasePlayerLives()
    {
        playerLives--;

        playerLivesText.text = "Lives : " + playerLives.ToString();

        AudioSource.PlayClipAtPoint(playerLostALifeSound, gameControllerTransform.position);

        // Upon the player attaining 0 lives, the game restarts
        if (playerLives == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
