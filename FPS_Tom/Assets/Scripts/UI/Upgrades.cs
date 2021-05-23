using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    public GameObject playerObject;

    private void SpendPoints()
    {

        if (playerObject.GetComponent<scr_Points>().points >= 25)
        {
            playerObject.GetComponent<scr_Points>().points -= 25;
            playerObject.GetComponent<scr_Points>().UpdatePointsUI();
        }
        
    }

    public void IncreaseAmmoInClip()
    {
        if (playerObject.GetComponent<scr_Points>().points >= 25)
        {
            SpendPoints();
            playerObject.GetComponentInChildren<ProjectileGun>().magazineSize += 10;
        }
        else
        {
            return;
        }
        
    }

    public void IncreaseBulletDamage()
    {
        if (playerObject.GetComponent<scr_Points>().points >= 25)
        {
            SpendPoints();
            playerObject.GetComponentInChildren<ProjectileGun>().bullet.GetComponentInChildren<BulletDamage>().damage += 10f;
        }
        else
        {
            return;
        }
        
    }
}
