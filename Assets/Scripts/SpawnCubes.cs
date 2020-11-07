using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnCubes : MonoBehaviour
{
    public GameObject spawnerPrefab;
    public GameObject cubeParent;
    private GameObject cubeObject;
    private int spawnNumber;
    public Text userInput;
    int i=0;
    private float radius;

    bool isSpawning = false;

    private void Start()
    {
        radius = 10;
    }

    private void FixedUpdate()
    {
        if (isSpawning)
        {
            spawnNumber = int.Parse(userInput.text.ToString());
            if (i < spawnNumber)
            {
                cubeObject = Instantiate(spawnerPrefab, cubeParent.transform) as GameObject;

                cubeObject.transform.position = new Vector3(transform.position.x +
                    Random.Range(-1f, 1f) * radius,
                    2f, transform.position.z +
                    Random.Range(-1f, 1f) * radius);

                i++;
            }
        }
        
    }
    public void Spawn()
    {
        isSpawning = true;  
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
