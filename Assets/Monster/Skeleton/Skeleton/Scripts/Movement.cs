using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timeForNewPath;
    bool inCoRoutine;
    static Animator anim;
    Vector3 target;
    bool validPath;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        anim = GetComponent<Animator>();
    }

   //Obtiene una posición aleatoria nueva en el mapa
    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-100,100);
        float z = Random.Range(-100,100);

        Vector3 pos = new Vector3(x,0,z);
        return pos;
    }

    IEnumerator Move()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target,path);

        //Si la posición no es válida calcula una nueva
        while(!validPath)
        {
            yield return new WaitForSeconds(0.01f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(target,path);
        }
        inCoRoutine = false;
    }

    void GetNewPath()
    {
        anim.SetBool("isIdle",false);
        anim.SetBool("isAttacking",false);
        anim.SetBool("isWalking",true);

        target = getNewRandomPosition();
        navMeshAgent.SetDestination(target);
    }

    // Update is called once per frame
    void Update()
    {
        //Si acaba el movimiento empieza de nuevo a buscar una posición aleatoria
        if(!inCoRoutine)
        {
        StartCoroutine(Move());
        }
    }
}
