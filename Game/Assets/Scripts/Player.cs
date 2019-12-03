using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public int exp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHealth()
    {
        return health;
    }

    public int getExp()
    {
        return exp;
    }

    public void updateHealth(float current_health)
    {
        health = current_health;
    }

    public void updateExp(int current_exp)
    {
        exp = current_exp;
    }
}
