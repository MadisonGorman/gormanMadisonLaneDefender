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


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, 2.00f);
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
}
