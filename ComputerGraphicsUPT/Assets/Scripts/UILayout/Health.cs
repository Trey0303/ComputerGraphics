using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
// set up our own kind of UnityEvent that will send floats
[System.Serializable]
public class UnityEventFloat : UnityEvent<float> { }

// ...

public class Health : MonoBehaviour
{
    public Transform playerTransform;

    public Transform spawnPoint;

    public Slider healthBar;
    //[Range(0, 3)]
    public float curHealth = 3;//set a seperate float from the healtbar
    bool invincible = false;
    public float invincibilityTime = 2;
    private float setBackTime = 0;


    // provide an event for other systems to subscribe to
    public UnityEventFloat OnHealthChanged { get; private set; } = new UnityEventFloat();

    private void Start()
    {
        OnHealthChanged.AddListener(UpdateHealth);//updates healthbar with new value
        setBackTime = invincibilityTime;

        playerTransform = GameObject.Find("Player").transform;

        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    private void Update()
    {
        if (invincible)
        {
            invincibilityTime -= Time.deltaTime;
            if (invincibilityTime <= 0){
                invincibilityTime = setBackTime;
                invincible = false;
            }
        }

        if(curHealth <= 0)
        {
            Dead();
        }

    }

    //damage is applied to curHealth
    public void TakeDamage(float damage)
    {
        if (!invincible)
        {
            curHealth = curHealth - damage;
            // invoke the event with the health taken
            OnHealthChanged.Invoke(curHealth);//tells OnHealthChange that a change to curHealth has occured
            invincible = true;
        }
            

    }

    public void Dead()
    {
        //set player back to full health 
        Heal(3);
        OnHealthChanged.Invoke(curHealth);

        StoreData.GreenItemCount = 0;

        //reset player at spawn position
        GameObject.Find("Player").GetComponent<SamplePlayerCharacter>().enabled = false;
        playerTransform.position = spawnPoint.position;
        playerTransform.rotation = spawnPoint.rotation;
        GameObject.Find("Player").GetComponent<SamplePlayerCharacter>().enabled = true;
    }

    public void Heal(float amount)
    {
        
        //subtract amount of green used from total green player has
        StoreData.GreenItemCount = StoreData.GreenItemCount - StoreData.MaxGreen;

        curHealth = curHealth + amount;

        OnHealthChanged.Invoke(curHealth);


    }

    public void UpdateHealth(float health)
    {
        healthBar.value = health;
    }
}

