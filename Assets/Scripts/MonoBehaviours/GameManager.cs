using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public List<GameObject> characters = new List<GameObject>();
    private void Awake()
    {
        Instance = this;
    }
}
