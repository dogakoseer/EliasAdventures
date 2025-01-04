using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GateState
{
    closed, opened
}
public class Gate : MonoBehaviour
{

    public GameObject gateOpened;
    public GameObject gateClosed;
    public GateState state;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        CloseDoor();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OpenDoor();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        if (state == GateState.closed)
        {
            gateClosed.SetActive(false);
            gateOpened.SetActive(true);
            state = GateState.opened;
            particle.Play();
        }
        else
            Debug.Log("Door alrdy opened");
    }
    public void CloseDoor()
    {
        if (state == GateState.opened)
        {
            gateClosed.SetActive(true);
            gateOpened.SetActive(false);
            state = GateState.closed;
        }
        else
            Debug.Log("Door alrdy closed");

    }
}
