using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

[SerializeField]
public class scr_Health : MonoBehaviour
{
    public float health;

    public float defaultHealth;
    public TMP_Text hpText;
    private string _Name;

    private int lastFrame;
    public int FramesCountSinceDamageTaken 
    {
        get { return Time.frameCount - lastFrame; }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = defaultHealth;
        _Name = this.gameObject.name;
        UpdateUi();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(other.GetComponent<BulletDamage>().damage);
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Die();
            }
        }
        
    }


    public void TakeDamage(float damageAmount) 
    {
        if (FramesCountSinceDamageTaken > 2)
        {
            health -= damageAmount;
        }
        
        lastFrame = Time.frameCount;
        UpdateUi();
        Debug.Log(_Name + " health is now: " + health);

    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        UpdateUi();
        // Test
        Debug.Log(_Name + " health is now: " + health);
    }

    public void Die()
    {
        if (this.gameObject.name == "Player" && this.health <= 0 && this != null)
        {
            //SceneManager.LoadScene("Game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (this != null)
        {
            Destroy(gameObject);
            GameEvents.current.EnemyKilled();
        }
        
    }

    public void UpdateUi() 
    {
        hpText.text = "Health : " + health;
        //if (this.gameObject.name == "Player")
        //{
         //   
        //}
    }
}
