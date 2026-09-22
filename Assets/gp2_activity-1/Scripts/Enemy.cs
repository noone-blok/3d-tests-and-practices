using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject waypointOne;
    [SerializeField] private GameObject waypointTwo;

    [SerializeField] private float timeToReachEnd = 4f;

    Vector3 startPosition;
    Vector3 endPosition;

    float timer = 0f;
    bool toB = true;

    private void OnEnable()
    {
        Debug.Log("Enemy Enabled");
    }

    private void OnDisable()
    {
        Debug.Log("Enemy Disabled");
    }

    void Update()
    {
        //1. Add frame time to our stopwatch 
        timer += Time.deltaTime;

        float t = timer / timeToReachEnd;

       if (toB)
       {
            startPosition = waypointOne.transform.position;
            endPosition = waypointTwo.transform.position;
        }
        else
        {
            startPosition = waypointTwo.transform.position;
            endPosition = waypointOne.transform.position;
        }

       if (t < 1.00f)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
        }

       if (t > 1f)
        {
            timer = 0f;
            toB = !toB;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Drone Killed");
        GameManager.Instance.AddScore();
        Destroy(this.gameObject);
    }
}
