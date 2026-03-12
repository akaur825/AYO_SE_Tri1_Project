using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Codice.Client.Common.EventTracking.TrackFeatureUseEvent.Features.DesktopGUI.Filters;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    public bool gameOver;
    private GameTimer endPanel;
    private SpeedPlayerState speedPlayerState;
    private ISpecialEffects specialEffects;
    private IBroker _broker;
    private string speedPlayerStateToString;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        speedPlayerState = new NormalSpeedPlayerState(this);
        specialEffects = GameObject.FindAnyObjectByType<SpecialEffectProxy>();
        _broker.NotifyObservers(speedPlayerState.PlayerStateToString());
    }

    private void speedStateUpdated()
    {
        _broker.NotifyObservers(speedPlayerState.PlayerStateToString());
        speedPlayerStateToString = "The current Player Speed State is " + speedPlayerState.PlayerStateToString();
        Debug.Log(speedPlayerStateToString);
        _broker.NotifyObservers(speedPlayerStateToString);
    }

    public void advanceSpeedStateDirectly(SpeedPlayerState newState)
    {
        speedPlayerState = newState;
        speedStateUpdated();
    }
    
    public void Construct(IBroker broker)
    {
        _broker = broker;
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
        playerAnimator.SetFloat("Horizontal", input.x);
        playerAnimator.SetFloat("Vertical", input.y);
        playerAnimator.SetFloat("Speed", input.sqrMagnitude);
        speedPlayerState.Act();
    }

    private void FixedUpdate()
    {
        playerRb.linearVelocity = input * speedPlayerState.getSpeed();
        //Debug.Log(playerRb.linearVelocity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        speedPlayerState = speedPlayerState.advanceState(other);
        speedStateUpdated();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLLISION DETECTED!!!!");
        if (specialEffects != null)
        {
            specialEffects.PlayPlayerDeathEffect(transform.position);
        }
        endPanel = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameTimer>();
        endPanel.TimerFinished();
    }
}
