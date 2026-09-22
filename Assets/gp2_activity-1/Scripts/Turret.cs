using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private float rotationSpeed = 6f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;

            if (directionToTarget != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                float dot = Vector3.Dot(transform.forward, directionToTarget);

                if (dot > 0.98f)
                {
                    Debug.DrawLine(transform.forward, directionToTarget);
                }
            }
        }
    }
}
