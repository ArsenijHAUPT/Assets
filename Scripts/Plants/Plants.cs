using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [Header("Возраст")]
    public float PlantAge;
    public int Stage;
    public Sprite[] AgeLook;
    [Header("Потребности")]
    public float needsWater;
    [Header("Condition")]
    public bool Growthing;
    public bool Dead;
    [Header("ConditionPriority")]
    public bool growthing;
    public IEnumerator _Live;
    [Header("Loot")]
    public GameObject[] loot;

    // Start is called before the first frame update
    void Start()
    {
        _Live = Living();
        StartCoroutine(_Live);
    }
    private IEnumerator Living()
    {
        while (true)
        {
            Live();
         
            print("IenumeratorIsActive");
            yield return new WaitForSeconds(1f);

        }

    }
    public void GrowthUp()
    {
        Stage = Stage + 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = AgeLook[Stage];
       
    }

    public void Live()
    {
        PlantAge += 0.1f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Dead)
        {
            StopCoroutine(_Live);
        }
        if(PlantAge > 1.2f)
        {
            Dead = true;
        }
        if (PlantAge >= 0.2f && Stage == 0)
        {
            GrowthUp();

        }
        if (PlantAge >= 0.4f && Stage == 1)
        {
            GrowthUp();

        }
        if (PlantAge >= 0.6f && Stage == 2)
        {
            GrowthUp();

        }
        if (PlantAge >= 0.8f  && Stage == 3)
        {
            GrowthUp();

        }
 
    }
}
