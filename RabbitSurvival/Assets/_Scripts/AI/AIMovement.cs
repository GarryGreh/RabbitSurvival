using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public MovementPath path;
    public float maxDistanceToPoint = .1f;
    public float maxDistanceAggress = 10.0f;
    public float minDistanceAggress = 1.0f;

    private NavMeshAgent agent;
    private Transform target;
    private AIAnimation anim;
    private bool isHowl;

    private IEnumerator<Transform> pointInPath;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<AIAnimation>();

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (path == null) // проверка прикрепили ли путь
        {
            Debug.Log("Прикрепи путь!");
            return;
        }

        pointInPath = path.GetNextPathPoint(); // обращение к корутине в классе MovementPath
        pointInPath.MoveNext(); // получение следующей точки в пути

        if (pointInPath.Current == null) // есть ли точка к которой передвигаться
        {
            Debug.Log("Нужны точки!");
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    private void Update()
    {
        if (pointInPath == null || pointInPath.Current == null) // проверка отсутствия пути
        {
            return; // выход, потому что пути нет
        }
        float distance = Vector3.Distance(transform.position, target.position);
        if(FindObjectOfType<HidePlayer>().CheckHide() || distance > maxDistanceAggress)
        {
            agent.isStopped = false;
            agent.SetDestination(pointInPath.Current.position);
            isHowl = false;
        }
        else if(!FindObjectOfType<HidePlayer>().CheckHide() && distance <= maxDistanceAggress)
        {            
            agent.SetDestination(target.position);
            if (!isHowl)
            {
                SoundManager.instance.PlayWolf();
                isHowl = true;
            }

            if (agent.remainingDistance <= minDistanceAggress)
            {
                agent.isStopped = true;
                GameManager.Instance.StatusGame(false);
            }
            else if(agent.remainingDistance > minDistanceAggress)
            {
                agent.isStopped = false;
            }
        }
        
        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude; // проверяем, достаточно ли близко к точке, чтобы начать следовать к другой точке
        if (distanceSqure < maxDistanceToPoint * maxDistanceToPoint) // достаточно ли мы близко, если да...
        {
            pointInPath.MoveNext(); // то двигаем к следующей точке
        }

        anim.IdleWalk(agent.velocity.magnitude);        
    }
}
