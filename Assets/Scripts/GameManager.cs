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

    private const int MAP_WIDTH = 30;
    private const int MAP_HEIGHT = 17;

    private int[,] MAP = new int[MAP_HEIGHT, MAP_WIDTH]{
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16, 0, 4, 4, 4, 4, 4, 3,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16, 5,12,12,12,12,12, 7,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16, 5,12,12,12,12,12, 7,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16, 5,12,12,12,12,12, 7,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16, 5,12,12,12,12,12, 7,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16, 5,12,12,12,12,12, 7,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16, 1, 6, 6, 6, 6, 6, 2,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16}
    };

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        StartCoroutine(CreateMap());
    }

    IEnumerator CreateMap()
    {
        for (int y = 0; y < MAP_HEIGHT; y++)
        {
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                GameObject tile = new GameObject("tile" + x + "_" + y);

                int tileInfo = MAP[y, x];
                int spriteIndex = tileInfo / (tileSprites.Length - 1);
                float rotationAmount = (int)(tileInfo % (tileSprites.Length - 1)) * 90f;

                tile.AddComponent<SpriteRenderer>().sprite = tileSprites[spriteIndex];
                tile.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((x * 64f) + 32f, 1080 - (y * 64f) - 32f, 0f));
                tile.transform.localEulerAngles = new Vector3(0f, 0f, rotationAmount);

                if (x % 4 == 1) // Do four tiles at a time
                    yield return new WaitForSeconds(0.005f);
            }
        }
    }

    public void CreateWhirlwind()
    {
        // Create Alert, pass in Disaster class to instantiate upon Alert completion
        Instantiate(alerts[0]).GetComponent<Alert>().onComplete = (alert) =>
        {
            Whirlwind whirlwind = Instantiate(disasters[0], new Vector3(-200f, 540f, 0f), Quaternion.identity).GetComponent<Whirlwind>();
            whirlwind.OffsetFromAlert(alert);
        };
    }

    public void CreateMeteor()
    {
        // Create Alert, pass in Disaster class to instantiate upon Alert completion
        Instantiate(alerts[1], new Vector3(1160f, 740f, 0f), Quaternion.identity).GetComponent<Alert>().onComplete = (alert) =>
        {
            Instantiate(disasters[1], new Vector3(1160f, 740f, 0f), Quaternion.identity);
        };
    }
}
