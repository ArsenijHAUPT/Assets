using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Medved : MonoBehaviour , ILiferable
{
    [Header("Возраст")]
    public float Year;
    public int Age;
    public Sprite[] AgeSprite;
    public Sprite[] DeathSprite;
    [Header("Потребности")]
    public float _Food;
    private float Food
    {
        get
        {
            return _Food;
        }
        set
        {
            if (value > 30)
                value = 30;
            if (value < 0)
                value = 0;
            _Food = value;
        }
    }
    public float _sleep;
    private float sleep
    {
        get
        {
            return _sleep;
        }
        set
        {
            if (value > 30)
                value = 30;
            if (value < 0)
                value = 0;
            _sleep = value;
        }
    }
    public float Health;
    [Header("Condition")]

    public bool Dead;
    public bool living;

    public bool FindingFood;
    public bool sleeping;
    public bool runningout;
    public bool explore;
    [Header("ConditionPriority")]
    public float PriorFindingFood;
    public float PriorSleeping;
    public float PriorRunningout;
    public float PriorExplore;
    public IEnumerator Live1;

   

    [Header("Loot")]
    public Sprite[] Loot;

    public float TimerTime;

    

    // Start is called before the first frame update
    void Start()
    {
        living = true;
        Live1 = Living();
        StartCoroutine(Live1);
        
    }


    //Update is called once per frame
    void FixedUpdate()
    {
        if (Health < 0 && living) 
        {
            Death();
        
        }

        TimerTime +=Time.deltaTime;
        if (!Dead)
        {
     
              
          
            if (Food < 15 && !FindingFood && !sleeping)
            {
               
                FindingFood = true;
            }
            if(sleep < 5 && !FindingFood && !sleeping)
            {
             
                sleeping = true;
            }
            if (sleeping)
            {
                GoSleep();
            }
            if (FindingFood)
            {
                GoEat();
            }
        }
      
      
        if(Year >= 2  && Age == 0)
        {
            GrowthUp();
                
        }
        if (Year >= 4 && Age == 1)
        {
            GrowthUp();
        }
        if (Year >= 7 && Age == 2)
        {
            GrowthUp();
        }
        if (Year >= 12 && Age == 3)
        {
            GrowthUp();
        }
        if (Year >= 16 && Age == 4)
        {
            GrowthUp();
        }
        if (Year >= 22 && Age == 5)
        {
            GrowthUp();
        }
        if (Year >= 28 && Age == 6)
        {
            GrowthUp();
        }
        if (Year >= 35 && Age == 7)
        {
            Death();
        }

    }
    private IEnumerator Living() 
    {
        while(true)
        {
            Live();
            FoodDown();
            SleepDown();
            print("IenumeratorIsActive");
            yield return new WaitForSeconds(1f);
            
        }
 
    }

    public void Live()
    {
     Year += 0.1f;
      
    
     
       
    }
    public void GrowthUp()
    {
        Age = Age + 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = AgeSprite[Age];
    }
    public void Eat()
    {

    }
    public void Sleep()
    {
      
        sleep += UnityEngine.Random.Range(0, 3);
        if (sleep > 25)
        {
            sleeping = false;
        }
    }
    public void SleepDown()
    {
        sleep -= 3;
    }
    public void Death()
    {
        Dead = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = DeathSprite[Age];
        if (living)
        {
         
            StopCoroutine(Live1);
            print(Live1 + "COr");
            living = false;
        }
    }

    public void FoodDown()
    {
        Food -= 1;
    }

    public void GoEat()
    {
        Food += UnityEngine.Random.Range(0, 3);
        if (Food > 20)
        {
            FindingFood = false;
        }
     
    }
    public void GoSleep()
    {
        sleep += (Time.time) * 0.0011f;
        if (Food > 20)
        {
            sleeping = false;
        }
    }
    public void GoSex()
    {

    }
    public void GoAway()
    {

    }
}
