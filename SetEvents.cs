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
            try
            {
                Global.IsFullRp = Plugin.Config.GetBool("IsFullRp");
            }
            catch (System.Exception ex)
            {
                Log.Info("Catch an exception while getting boolean value from config file: " + ex.Message);
                Global.IsFullRp = false;
            }
            try
            {
                Global.IsMediumRp = Plugin.Config.GetBool("IsMediumRp");
            }
            catch (System.Exception ex)
            {
                Log.Info("Catch an exception while getting boolean value from config file: " + ex.Message);
                Global.IsMediumRp = false;
            }
            try
            {
                Global.IsLightRp = Plugin.Config.GetBool("IsLightRp");
            }
            catch (System.Exception ex)
            {
                Log.Info("Catch an exception while getting boolean value from config file: " + ex.Message);
                Global.IsLightRp = false;
            }

            Log.Info(nameof(Global.IsFullRp) + ": " + Global.IsFullRp);
            Log.Info(nameof(Global.IsMediumRp) + ": " + Global.IsMediumRp);
            Log.Info(nameof(Global.IsLightRp) + ": " + Global.IsLightRp);

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
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 150.0f;
                }
                if (ev.Player.GetRole() == RoleType.NtfCadet || ev.Player.GetRole() == RoleType.NtfLieutenant)
                {
                    if (ev.Player.gameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.gameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170.0f;
                }
                if (ev.Player.GetRole() == RoleType.ChaosInsurgency)
                {
                    if (ev.Player.gameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.gameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().AddItems.Add(ItemType.Radio);
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170.0f;
                }
                if (ev.Player.GetRole() == RoleType.NtfCommander || ev.Player.GetRole() == RoleType.NtfLieutenant)
                {
                    if (ev.Player.gameObject.GetComponent<SetRoleOnSpawn>())
                        Object.Destroy(ev.Player.gameObject.GetComponent<SetRoleOnSpawn>());
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170.0f;
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
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 99999.9f;
                }
                else if (ev.Player.GetRole() == RoleType.NtfCadet || ev.Player.GetRole() == RoleType.NtfLieutenant || ev.Player.GetRole() == RoleType.FacilityGuard)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                    if (ev.Player.GetRole() == RoleType.FacilityGuard)
                    {
                        ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 150.0f;
                    }
                    else
                    {
                        ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170.0f;
                    }
                }
                else if (ev.Player.GetRole() == RoleType.NtfScientist)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().RemoveItems.Add(ItemType.WeaponManagerTablet);
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170.0f;
                }
                else if (ev.Player.GetRole() == RoleType.Scientist)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().AddItems.Add(ItemType.Radio);
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 120.0f;
                }
                else if (ev.Player.GetRole() == RoleType.ClassD)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 120.0f;
                }
                else if (ev.Player.GetRole() == RoleType.ChaosInsurgency)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170.0f;
                }
                else if (ev.Player.GetRole() == RoleType.NtfCommander)
                {
                    ev.Player.gameObject.AddComponent<SetRoleOnSpawn>();
                    ev.Player.gameObject.GetComponent<SetRoleOnSpawn>().MaxHealth = 170.0f;
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
                    if (!AccessCards372.Contains(ev.Player.GetCurrentItem().id) || ev.Player.inventory.curItem == ItemType.None)
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
            if (Global.IsMediumRp)
            {
                if (ev.Player.GetCurrentItem().id == ItemType.KeycardChaosInsurgency && ev.Player.inventory.curItem != ItemType.None && ev.Player.GetRole() != RoleType.ChaosInsurgency)
                {
                    ev.Allow = false;
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