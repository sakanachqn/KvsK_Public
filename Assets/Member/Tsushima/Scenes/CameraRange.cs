using UnityEngine;

public class CameraRange : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float distance;
    public float RangeFinder()
    {
        return Vector3.Distance(PlayerController.PlayerGameObject.transform.position, this.gameObject.transform.position);
    }
}
