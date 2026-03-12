using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStateDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text stateText;
    [SerializeField] Image stateBackground;

    private IBroker _broker;

    public void SetDependency(IBroker broker)
    {
        _broker = broker;
    }

    public void Start()
    {
        _broker.Subscribe(OnStateChanged);
    }
    void OnEnable()
    {
        // cannot subscribe here due to the order of execution of the Start and OnEnable methods
    }

    public void OnDisable()
    {
        _broker.Unsubscribe(OnStateChanged);
    }

    public void OnStateChanged(string state)
    {

        if (state == "NormalSpeedPlayerState")
        {
            stateText.text = "No Effects Equipped";
            stateBackground.color = Color.cyan;
        }
        else if (state == "SlowEffectTimedSpeedPlayerState")
        {
            stateText.text = "Apple! Slow...";
            stateBackground.color = Color.red;
        }
        else if (state == "SpeedyEffectTimedSpeedPlayerState")
        {
            stateText.text = "Lemon! Fast!!!";
            stateBackground.color = Color.yellow;
        }
    }
}
