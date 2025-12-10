using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class RoomAudio : MonoBehaviour
{
    public Room room;
    public FPController player;
    private bool playerInRoom;
    private bool doorOpening;

    public AudioMixer mixer;
    public AudioMixerSnapshot roomSS;
    public AudioMixerSnapshot corridor_doorOpenSS;
    public AudioMixerSnapshot corridor_doorClosedSS;

    public float transitionTime = 0;

    private void OnEnable()
    {
        Door.DoorOpening += DoorSnapshotTransitions;
        Door.DoorClosing += DoorSnapshotTransitions;
    }

    private void OnDisable()
    {
        Door.DoorOpening -= DoorSnapshotTransitions;
        Door.DoorClosing -= DoorSnapshotTransitions;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerInRoom = room.playerInRoom;
        doorOpening = room.door.doorOpen;

        if (playerInRoom)
        {
            roomSS.TransitionTo(transitionTime);
        }
    }

    private void DoorSnapshotTransitions(float time, Door door)
    {
        if (door != room.door) return;

        if (doorOpening)
        {
            corridor_doorClosedSS.TransitionTo(time);
        }
        else
        {
            corridor_doorOpenSS.TransitionTo(time);
        }
    }
}
