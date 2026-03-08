using UnityEngine;

public class GameBootStrap : MonoBehaviour
{
    private IBroker broker;

    [SerializeField] private PlayerController player;
    [SerializeField] private PlayerStateDisplay display;

    void Awake()
    {
        broker = new Broker();

        player.Construct(broker);
        display.Construct(broker);
    }
}
