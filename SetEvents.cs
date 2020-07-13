using EXILED;
using EXILED.Extensions;
using System.Collections.Generic;
using UnityEngine;

namespace BetterPersonnel
{
    internal class SetEvents
    {
        internal void OnWaitingForPlayers()
        {
            Global.CanUseConsoleCommand = false;
        }

        internal void OnRoundStart()
        {
            Global.CanUseConsoleCommand = true;
            GameObject mainSetter = GameObject.FindWithTag("FemurBreaker");
            mainSetter.AddComponent<JanitorComponent>();
        }

        internal void OnPlayerSpawn(PlayerSpawnEvent ev)
        {
            if (Global.IsLightRp)
            {
                if (ev.Player.GetRole() == RoleType.FacilityGuard)
                {
                    if (ev.Player.gameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.gameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.KeycardGuard);
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().AddItems.Add(ItemType.KeycardSeniorGuard);
                }
                if (ev.Player.GetRole() == RoleType.NtfCadet || ev.Player.GetRole() == RoleType.NtfLieutenant)
                {
                    if (ev.Player.gameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.gameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                }
                if (ev.Player.GetRole() == RoleType.ChaosInsurgency)
                {
                    if (ev.Player.gameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.gameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().AddItems.Add(ItemType.Radio);
                }
            }
            if (Global.IsFullRp)
            {
                if (ev.Player.gameObject.GetComponent<SetRoleOnSpawn>())
                {
                    Object.Destroy(ev.Player.gameObject.GetComponent<SetRoleOnSpawn>());
                }
                if (ev.Player.GetRole() == RoleType.Scp106 || ev.Player.GetRole() == RoleType.Scp096)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 99999;
                }
                else if (ev.Player.GetRole() == RoleType.NtfCadet || ev.Player.GetRole() == RoleType.NtfLieutenant || ev.Player.GetRole() == RoleType.FacilityGuard)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                }
                else if (ev.Player.GetRole() == RoleType.NtfScientist)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                }
                else if (ev.Player.GetRole() == RoleType.Scientist)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().AddItems.Add(ItemType.Radio);
                }
            }
        }

        internal void OnDoorInteract(ref DoorInteractionEvent ev)
        {
            if (Global.IsFullRp)
            {
                if (ev.Door.DoorName.ToLower().Contains("surface_gate"))
                {
                    ev.Allow = false;
                }
                if (ev.Door.DoorName.ToLower().Contains("372"))
                {
                    if (!accessCards372.Contains(ev.Player.GetCurrentItem().id) || ev.Player.inventory.curItem == ItemType.None)
                    {
                        ev.Allow = false;
                    }
                }
                if (ev.Player.GetCurrentItem().id == ItemType.KeycardGuard && ev.Player.inventory.curItem != ItemType.None)
                {
                    if (ev.Door.DoorName.ToLower().Contains("012"))
                    {
                        ev.Allow = true;
                    }
                    if (ev.Door.DoorName.ToLower().Contains("049"))
                    {
                        ev.Allow = true;
                    }
                    if (ev.Door.DoorName.ToLower().Contains("armory") && ev.Door.DoorName.ToLower().Contains("nuke"))
                    {
                        ev.Allow = true;
                    }
                }
            }
        }

        private readonly List<ItemType> accessCards372 = new List<ItemType>()
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