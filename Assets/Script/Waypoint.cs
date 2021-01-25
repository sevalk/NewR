using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    [SerializeField]public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the waypoint is less than this, then it has reacehd the waypoint
    private int lastWaypointIndex;

    public float movementSpeed = 1.0f;
    private float rotationSpeed = 2.0f;

    [SerializeField] Transform Character;

    [SerializeField] Transform parent;//cube stakcs parent
    public bool isFinished = false;

    [SerializeField] Button tryAgainButton;
    [SerializeField] Button playAgainButton;

    [SerializeField] GameObject pivot;

    [SerializeField] Slider slider;

    [SerializeField] GameObject finishParticles;


    private void Awake()
    {
        
        slider.value = 0f;
    }

    void Start()
    {
        
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex]; //Set the first target waypoint at the start so the enemy starts moving towards a waypoint
    }

    
    void Update()
    {

        if (parent.childCount == 0)
        {
            if (isFinished)
            {
                pivot.transform.position = Character.position;
                Character.gameObject.GetComponent<Animation>().Play("Runtojumpspring");
                movementSpeed = 0;
                playAgainButton.gameObject.SetActive(true);
                Camera.main.transform.parent = pivot.transform;
                finishParticles.SetActive(true);
            }
            else
            {
                Character.gameObject.GetComponent<Animation>().Play("Idle");
                movementSpeed = 0;
                tryAgainButton.gameObject.SetActive(true);
            }
           
        }

        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }

   
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;

            slider.value += 1f / 20f;

            UpdateTargetWaypoint();
            
        }
    }

   
    // Increaes the index of the target waypoint. If the player has reached the last waypoint in the waypoints list, it changes the targetWaypointIndex
    
    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = lastWaypointIndex;
        }
        
        targetWaypoint = waypoints[targetWaypointIndex];
    }

   public void LoadSceneAgain()
    {
       
        SceneManager.LoadScene(0);
    }



}
