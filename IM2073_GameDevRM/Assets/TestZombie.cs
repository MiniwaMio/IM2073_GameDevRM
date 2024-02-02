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

    int count = 0;

    Animator anim;

    [SerializeField] private ZombieHealthBar healthBar;

    public AudioSource soundZombie;

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
        isDead = false;
        var collider = GetComponent<Collider>();
        Destroy(collider );

        if (count == 0)
        {
            soundZombie.Play();
            count++;
        }

        anim.SetTrigger("Died");

        agent.isStopped = true;
        Destroy(gameObject,1);
    }

    public void take_damage(int dmg, bool headshot = false)
    {
        
        hp -= dmg;
        //Debug.Log(hp);

        healthBar.SetHealthBar(hp);
        
    }

}
