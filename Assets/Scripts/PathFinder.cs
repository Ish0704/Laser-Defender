using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WavesConfigSO wavesConfig;
    List<Transform> waypoints = new List<Transform>();
    int wayPointIndex = 0;

    void Awake()
    {
        enemySpawner=FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        wavesConfig = enemySpawner.GetCurrentWave();
        waypoints = wavesConfig.GetWayPoints();
        transform.position = waypoints[wayPointIndex].position;
    }
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if(wayPointIndex < waypoints.Count)
        {
            Vector3 targetPos = waypoints[wayPointIndex].position;
            float delta = wavesConfig.GetMovespeed()*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
            if (transform.position == targetPos)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
