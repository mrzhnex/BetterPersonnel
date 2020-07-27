using Exiled.API.Features;
using System.Collections.Generic;
using UnityEngine;

namespace BetterPersonnel
{
    public class SetRoleOnSpawn : MonoBehaviour
    {
        private float Timer = 0.0f;
        private Player PlayerHub;

        public List<ItemType> RemoveItems = new List<ItemType>();
        public List<ItemType> AddItems = new List<ItemType>();
        public int MaxHealth = 0;

        public void Start()
        {
            PlayerHub = Player.Get(gameObject);
        }

        public void Update()
        {
            Timer += Time.deltaTime;

            if (Timer > 0.2f)
            {
                foreach (ItemType itemType in RemoveItems)
                {
                    for (int i = 0; i < PlayerHub.Inventory.items.Count; i++)
                    {
                        if (PlayerHub.Inventory.items[i].id == itemType)
                            PlayerHub.Inventory.items.Remove(PlayerHub.Inventory.items[i]);
                    }
                }
                foreach (ItemType itemType in AddItems)
                {
                    PlayerHub.AddItem(itemType);
                }
                if (MaxHealth != 0)
                {
                    PlayerHub.MaxHealth = MaxHealth;
                    PlayerHub.Health = MaxHealth;
                }
                Destroy(GetComponent<SetRoleOnSpawn>());
            }
        }
    }
}