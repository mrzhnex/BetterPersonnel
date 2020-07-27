using Exiled.Events.EventArgs;
using System.Collections.Generic;
using UnityEngine;

namespace BetterPersonnel
{
    public class SetEvents
    {
        internal void OnWaitingForPlayers()
        {
            Global.CanUseConsoleCommand = false;
        }

        internal void OnRoundStarted()
        {
            Global.CanUseConsoleCommand = true;
            GameObject mainSetter = GameObject.FindWithTag("FemurBreaker");
            mainSetter.AddComponent<JanitorComponent>();
        }

        internal void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (Global.IsFullRp)
            {
                if (ev.Door.DoorName.ToLower().Contains("surface_gate"))
                {
                    ev.IsAllowed = false;
                }
                if (ev.Door.DoorName.ToLower().Contains("372"))
                {
                    if (!AccessCards372.Contains(ev.Player.CurrentItem.id) || ev.Player.Inventory.curItem == ItemType.None)
                    {
                        ev.IsAllowed = false;
                    }
                }
                if (ev.Player.CurrentItem.id == ItemType.KeycardGuard && ev.Player.Inventory.curItem != ItemType.None)
                {
                    if (ev.Door.DoorName.ToLower().Contains("012") || ev.Door.DoorName.ToLower().Contains("049") || (ev.Door.DoorName.ToLower().Contains("armory") && ev.Door.DoorName.ToLower().Contains("nuke")))
                    {
                        ev.IsAllowed = true;
                    }
                }
            }
            if (Global.IsMediumRp)
            {
                if (ev.Player.CurrentItem.id == ItemType.KeycardChaosInsurgency && ev.Player.Inventory.curItem != ItemType.None && ev.Player.Role != RoleType.ChaosInsurgency)
                {
                    ev.IsAllowed = false;
                }
            }
        }

        internal void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (Global.IsLightRp)
            {
                if (ev.NewRole == RoleType.FacilityGuard)
                {
                    if (ev.Player.GameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.GameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.KeycardGuard);
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().AddItems.Add(ItemType.KeycardSeniorGuard);
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 150;
                }
                else if (ev.NewRole == RoleType.NtfCadet || ev.NewRole == RoleType.NtfLieutenant)
                {
                    if (ev.Player.GameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.GameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170;
                }
                else if (ev.NewRole == RoleType.ChaosInsurgency)
                {
                    if (ev.Player.GameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.GameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().AddItems.Add(ItemType.Radio);
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170;
                }
                else if (ev.NewRole == RoleType.NtfCommander || ev.NewRole == RoleType.NtfScientist)
                {
                    if (ev.Player.GameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.GameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170;
                }
            }
            if (Global.IsFullRp)
            {
                if (ev.Player.GameObject.GetComponent<SetRoleOnSpawn>())
                {
                    Object.Destroy(ev.Player.GameObject.GetComponent<SetRoleOnSpawn>());
                }
                if (ev.NewRole == RoleType.Scp106 || ev.NewRole == RoleType.Scp096)
                {
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 99999;
                }
                else if (ev.NewRole == RoleType.NtfCadet || ev.NewRole == RoleType.NtfLieutenant || ev.NewRole == RoleType.FacilityGuard)
                {
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                    if (ev.NewRole == RoleType.FacilityGuard)
                    {
                        ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 150;
                    }
                    else
                    {
                        ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170;
                    }
                }
                else if (ev.NewRole == RoleType.NtfScientist)
                {
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170;
                }
                else if (ev.NewRole == RoleType.Scientist)
                {
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().AddItems.Add(ItemType.Radio);
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 120;
                }
                else if (ev.NewRole == RoleType.ClassD)
                {
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 120;
                }
                else if (ev.NewRole == RoleType.ChaosInsurgency)
                {
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170;
                }
                else if (ev.NewRole == RoleType.NtfCommander)
                {
                    ev.Player.GameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.GameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170;
                }
            }
        }

        private readonly List<ItemType> AccessCards372 = new List<ItemType>()
        {
            ItemType.KeycardContainmentEngineer,
            ItemType.KeycardFacilityManager,
            ItemType.KeycardGuard,
            ItemType.KeycardJanitor,
            ItemType.KeycardScientistMajor,
            ItemType.KeycardNTFCommander,
            ItemType.KeycardNTFLieutenant,
            ItemType.KeycardO5,
            ItemType.KeycardScientist,
            ItemType.KeycardSeniorGuard,
            ItemType.KeycardZoneManager,
            ItemType.KeycardChaosInsurgency
        };
    }
}