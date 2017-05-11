using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject[] alerts;
    public GameObject[] disasters;
    public Sprite[] tileSprites;

    public GameObject selectedPerson = null;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame()
    {
        for (int x = 0; x < 29; x++)
        {
            for (int y = 0; y < 19; y++)
            {
                GameObject tile = new GameObject("tile" + x + "_" + y);
                tile.transform.position = new Vector3((x * 64f)/100f, (y * 64f)/100f, 0f);
                tile.AddComponent<SpriteRenderer>().sprite = tileSprites[Random.Range(0, tileSprites.Length)];
            }
        }
    }

    public void CreateWhirlwind()
    {
        // Create Alert, pass in Disaster class to instantiate upon Alert completion
        GameObject obj = Instantiate(alerts[0], new Vector3(-7.5f, 0f, 0f), Quaternion.identity) as GameObject;

        Alert alert = obj.GetComponent<Alert>();
        alert.onComplete = () =>
        {
            Instantiate(disasters[0], new Vector3(-11f, 0f, 0f), Quaternion.identity);
        };
    }

    public void CreateMeteor()
    {
        // Create Alert, pass in Disaster class to instantiate upon Alert completion
        GameObject obj = Instantiate(alerts[1], new Vector3(2f, 2f, 0f), Quaternion.identity) as GameObject;

        Alert alert = obj.GetComponent<Alert>();
        alert.onComplete = () =>
        {
            Instantiate(disasters[1], new Vector3(2f, 2f, 0f), Quaternion.identity);
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
