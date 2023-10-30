using UnityEngine;

public class KillPlayerOnContact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            GameManager.Instance.KillPlayer(player);
        }
    }
}
