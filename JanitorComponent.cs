using Exiled.API.Features;
using System.Collections.Generic;
using UnityEngine;

namespace BetterPersonnel
{
    public class JanitorComponent : MonoBehaviour
    {
        private System.Random rand = new System.Random();
        private float Timer = 0.0f;

        public void Update()
        {
            Timer += Time.deltaTime;
            if (Timer > 0.5f)
            {

                List<Player> randomPlayers = new List<Player>();
                foreach (Player p in Player.List)
                {
                    if (p.Role == RoleType.ClassD)
                    {
                        randomPlayers.Add(p);
                    }
                }
                if (randomPlayers.Count > 0)
                {
                    Player janitor = randomPlayers[rand.Next(0, randomPlayers.Count)];
                    janitor.AddItem(ItemType.KeycardJanitor);

                    foreach (Door door in Map.Doors)
                    {
                        if (door.DoorName.Contains("173_ARMORY"))
                        {
                            door.NetworkisOpen = true;
                            janitor.ClearBroadcasts();
                            janitor.Broadcast(30, "<color=#876c99>Вы - уборщик комплекса</color>", Broadcast.BroadcastFlags.Normal);
                            janitor.Position = door.gameObject.transform.position + Vector3.up;
                            break;
                        }
                    }
                }
                Destroy(gameObject.GetComponent<JanitorComponent>());
            }
        }
    }
}