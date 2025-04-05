using UnityEngine;

public class HUDPersistance : MonoBehaviour
{
    private static HUDPersistance instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // menține Canvas-ul în viață
        }
        else
        {
            Destroy(gameObject); // evită dubluri la reîntoarcere în scenă
        }
    }
}
