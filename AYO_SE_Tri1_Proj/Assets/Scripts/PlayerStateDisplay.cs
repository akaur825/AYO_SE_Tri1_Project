using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStateDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text stateText;
    [SerializeField] Image stateBackground;

    private IBroker _broker;

    public void Construct(IBroker broker)
    {
        _broker = broker;
    }

    private void Start()
    {
        _broker.Subscribe<PlayerStateChanged>(OnStateChanged);
    }
    void OnEnable()
    {
        //_broker.Subscribe<PlayerStateChanged>(OnStateChanged);
    }

    void OnDisable()
    {
        _broker.Unsubscribe<PlayerStateChanged>(OnStateChanged);
    }

    private void OnStateChanged(PlayerStateChanged evnt)
    {
        // NEEDS TO BE FIXED TO ACCOUNT FOR ALL STATES CHANGING, NOT JUST SPEEDY PLAYER SPEED STATE

        //stateText.text = "switched state";
        //stateBackground.color = Color.lightPink;

        if (evnt.State is NormalSpeedPlayerState)
        {
            stateText.text = "No Effects Equipped";
            stateBackground.color = Color.cyan;
        }
        else if (evnt.State is SlowSpeedPlayerState)
        {
            stateText.text = "Apple! Slow...";
            stateBackground.color = Color.red;
        }
        else if (evnt.State is SpeedyPlayerSpeedState)
        {
            stateText.text = "Lemon! Fast!!!";
            stateBackground.color = Color.blue;
        }
    }
}
