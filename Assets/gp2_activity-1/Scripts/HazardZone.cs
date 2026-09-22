using UnityEngine;

public class HazardZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hazard Zone Entered");
        GameManager.Instance.DeductScore();
    }
}
