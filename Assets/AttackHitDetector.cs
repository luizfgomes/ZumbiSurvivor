using UnityEngine;
using Util.Ragdoll;

public class AttackHitDetector : MonoBehaviour
{
    private RagdollController _ragdollController;

    private void OnTriggerStay ( Collider other )
    {
        if(other.tag == "CollisionDetector" )
        {
            _ragdollController = other.GetComponentInParent<RagdollController>();
            _ragdollController.SetRagdollActive(true);
            Debug.Log("Teste");
        }
    }
}
