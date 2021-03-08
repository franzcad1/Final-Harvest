using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creeper : MonoBehaviour
{
    [Header("Line of Sight")]
    public bool HasLOS;

    public GameObject player;

    private NavMeshAgent agent;
    private Animator animator;

    [Header("Attack")]
    public float attackDistance = 4.1f;
    public PlayerBehaviour playerBehaviour;
    public float damageDelay = 30;
    public bool IsAttacking = false;
    public float kickForce = 800.0f;
    public float distanceToPlayer;
    public AudioSource hitSound;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        hitSound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {

        if (HasLOS)
        {
            agent.SetDestination(player.transform.position);
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        }


        if (HasLOS && distanceToPlayer < attackDistance && !IsAttacking)
        {
            // could be an attack
            //animator.SetInteger("AnimState", (int)CryptoState.KICK);
            transform.LookAt(transform.position - player.transform.forward);
            DoKickDamage();
            IsAttacking = true;

            if (agent.isOnOffMeshLink)
            {
                //animator.SetInteger("AnimState", (int)CryptoState.JUMP);
            }
        }
        else if (HasLOS && distanceToPlayer > attackDistance)
        {
            //animator.SetInteger("AnimState", (int)CryptoState.RUN);
            IsAttacking = false;
        }
        else
        {
            //animator.SetInteger("AnimState", (int)CryptoState.IDLE);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = true;
            player = other.transform.gameObject;
        }
    }

    private void DoKickDamage()
    {
        playerBehaviour.TakeDamage(20);
        hitSound.Play();
        StartCoroutine(kickBack());
    }

    private IEnumerator kickBack()
    {
        yield return new WaitForSeconds(damageDelay);

        var direction = Vector3.Normalize(player.transform.position - transform.position);
        playerBehaviour.controller.SimpleMove(direction * kickForce);
        StopCoroutine(kickBack());
    }

}
