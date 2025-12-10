using UnityEngine;
using UnityEngine.Audio;

public class Room : MonoBehaviour
{
    public string roomName;
    public Door door;
    public bool playerInRoom;
    private FPController player;



    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<FPController>();
        
    }



    private void Update()
    {
        if (player.CurrentSurface == null) return;

        playerInRoom = CheckPlayerInRoom();

        if (playerInRoom)
        {



        }
        else if (!playerInRoom )
        {
            //if (door.doorOpen)


        }
    }


    private bool CheckPlayerInRoom()
    {
        var room = player.CurrentSurface.GetComponentInParent<Room>();
        return room != null && room == this ? true : false;
    }
}
