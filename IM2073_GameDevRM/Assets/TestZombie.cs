using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class TestZombie : MonoBehaviour
{
    public bool isDead = false;
    public bool inRage = false;
    public int hp;
    private NavMeshAgent agent;

    Animator anim;

    [SerializeField] private ZombieHealthBar healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hp < 1)
        {
            dead();
        }
    }

    public void dead()
    {
        isDead = true;

        var collider = GetComponent<Collider>();
        Destroy(collider );

        anim.SetTrigger("Died");

        agent.isStopped = true;
        Destroy(gameObject,2);
    }

    public void take_damage(int dmg, bool headshot = false)
    {
        
        hp -= dmg;
        Debug.Log(hp);

        healthBar.SetHealthBar(hp);
        
    }

}
