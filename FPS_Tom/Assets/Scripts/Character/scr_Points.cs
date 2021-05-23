using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_Points : MonoBehaviour
{
    public float points;
    public float pointsPerEnemy;

    public TMP_Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onEnemyKilled += OnEnemyDeath;
        points = 0;
        
    }

    private void OnEnemyDeath() 
    {
        points += pointsPerEnemy;
        UpdatePointsUI();
    }

    public void UpdatePointsUI()
    {
        pointsText.text = "Points : " + points;
    }
}
