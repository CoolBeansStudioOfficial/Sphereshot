using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    [SerializeField] private float delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Invoke("SelfDestruct", delay);
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
