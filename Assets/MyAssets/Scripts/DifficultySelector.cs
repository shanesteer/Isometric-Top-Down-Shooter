using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Easy()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
    }

    public void Hard()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
    }
}
