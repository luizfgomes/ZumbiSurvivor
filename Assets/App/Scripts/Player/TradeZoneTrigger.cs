using UnityEngine;

public class TradeZoneTrigger : MonoBehaviour
{
    [SerializeField ]private StackManager stackManager;
    private void OnTriggerEnter ( Collider other )
    {
        if ( other.CompareTag("TradeZone") )
        {
            Vector3 tradePoint = other.transform.position;

            if(!stackManager )
                stackManager = GetComponent<StackManager>();

            if ( stackManager != null )
            {
                stackManager.ReleaseStackToZone(tradePoint);
            }
        }
    }
}