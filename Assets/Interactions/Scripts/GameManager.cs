using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject objectItem;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TMP_Text scoreText;

    private int score = 0;

    public void SpawnObject()
    {
        Instantiate(objectItem, spawnPoint.position, spawnPoint.rotation);
    }

    public void AddPoint()
    {
        score ++;
        scoreText.SetText("" + score);
    }

}
