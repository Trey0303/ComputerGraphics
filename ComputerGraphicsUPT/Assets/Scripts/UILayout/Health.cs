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
    public Slider healthBar;
    float curHealth = 3;//set a seperate float from the healtbar
    bool invincible = false;
    public float invincibilityTime = 2;
    private float setBackTime = 0;


    // provide an event for other systems to subscribe to
    public UnityEventFloat OnHealthChanged { get; private set; } = new UnityEventFloat();

    private void Start()
    {
        OnHealthChanged.AddListener(UpdateHealth);//updates healthbar with new value
        setBackTime = invincibilityTime;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
                TakeDamage(1);

        }
        if (invincible)
        {
            invincibilityTime -= Time.deltaTime;
            if (invincibilityTime <= 0){
                invincibilityTime = setBackTime;
                invincible = false;
            }
        }

    }

    //damage is applied to curHealth
    public void TakeDamage(float damage)
    {
        if (!invincible)
        {
            //Debug.Log("took damage");
            //Debug.Log("Damage: " + (damage));
            curHealth = curHealth - damage;
            // invoke the event with the health taken
            OnHealthChanged.Invoke(curHealth);//tells OnHealthChange that a change to curHealth has occured
            invincible = true;
        }
            

    }

    public void UpdateHealth(float health)
    {
        healthBar.value = health;
    }
}

