using EXILED.Extensions;
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

                List<ReferenceHub> randomPlayers = new List<ReferenceHub>();
                foreach (ReferenceHub p in Player.GetHubs())
                {
                    if (p.GetRole() == RoleType.ClassD)
                    {
                        randomPlayers.Add(p);
                    }
                }
                if (randomPlayers.Count > 0)
                {
                    ReferenceHub janitor = randomPlayers[rand.Next(0, randomPlayers.Count)];
                    janitor.AddItem(ItemType.KeycardJanitor);

                    foreach (Door door in Map.Doors)
                    {
                        if (door.DoorName.Contains("173_ARMORY"))
                        {
                            door.NetworkisOpen = true;
                            janitor.ClearBroadcasts();
                            janitor.Broadcast(30, "<color=#876c99>Вы - уборщик комплекса</color>", true);
                            janitor.SetPosition(door.gameObject.transform.position + Vector3.up);
                            break;
                        }
                    }
                }
                Destroy(gameObject.GetComponent<JanitorComponent>());
            }
        }
    }
}