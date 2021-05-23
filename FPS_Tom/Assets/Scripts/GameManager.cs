using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class GameManager : MonoBehaviour
{
    public GameObject winPanel;

    public int enemysKilled;
    public int totalEnemysInLevel;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window.

        Cursor.lockState = CursorLockMode.Locked; // keep confined to center of screen.

        //Cursor.lockState = CursorLockMode.None; // set to default default
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        if (enemysKilled == totalEnemysInLevel)
        {
            winPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
