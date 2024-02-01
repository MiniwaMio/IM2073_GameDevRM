using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_take_damage : MonoBehaviour
{
    public bool dead;
    public GameObject zombie_main;

    public void take_dmg(int dmg)
    {
        zombie_main.GetComponent<TestZombie>().take_damage(dmg, false);
    }
}
