using Oxide.Core.Plugins;
using Oxide.Ext.RustEdit;
using System.Collections.Generic;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("RustEditAPIExample", "k1lly0u", "0.1.0")]
    class RustEditAPIExample : RustPlugin
    {
        /*
        
            - API Methods -

            RustEditAPI.GetActiveAPCs(ref List<BradleyAPC> list) - Gets all active BradleyAPCs spawned on custom APC paths

            RustEditAPI.GetActiveNPCs(ref List<BaseCombatEntity> list) - Gets all active NPCs spawned via NPCSpawners

            RustEditAPI.GetAllMapEntities(ref List<BaseEntity> list) - Gets all map placed entities that derive from BaseEntity

            RustEditAPI.GetMapEntitiesOfType<T>(ref List<T> list) - Gets all map placed entities that are of the specified type

            RustEditAPI.GetSpawnpoints(ref List<Transform> list) - Gets the Transform component of all the map placed spawn points

            - Hooks -

            void RustEdit_OnMapDataProcessed() - Called after all map data has been processed (IO connections have been made, loot and resources are setup to respawn, NPC and APC spawners ready etc)

            void RustEdit_NPCSpawned(BasePlayer npc) - Called when a NPC is spawned via a NPCSpawner placed on the map

            void RustEdit_APCSpawned(BradleyAPC apc) - Called when a APC is spawned on a custom APC path

        */

        private void RustEdit_OnMapDataProcessed()
        {
            GetAllMapCameras();
            GetAllActiveResources();
            GetAllPrefabsThatDeriveFromBaseEntity();
            GetCustomSpawnpoints();
        }

        #region API Methods
        private void GetAllMapCameras()
        {
            List<CCTV_RC> list = Facepunch.Pool.GetList<CCTV_RC>();

            RustEditAPI.GetMapEntitiesOfType<CCTV_RC>(ref list);

            Puts(string.Format("Found {0} map placed cameras", list.Count));

            for (int i = 0; i < list.Count; i++)
            {
                // Do Something
            }

            Facepunch.Pool.FreeList(ref list);
        }

        private void GetAllActiveResources()
        {
            List<ResourceEntity> list = Facepunch.Pool.GetList<ResourceEntity>();

            RustEditAPI.GetMapEntitiesOfType<ResourceEntity>(ref list);

            Puts(string.Format("Found {0} active resources", list.Count));

            for (int i = 0; i < list.Count; i++)
            {
                // Do Something
            }

            Facepunch.Pool.FreeList(ref list);
        }

        private void GetAllPrefabsThatDeriveFromBaseEntity()
        {
            List<BaseEntity> list = Facepunch.Pool.GetList<BaseEntity>();

            RustEditAPI.GetAllMapEntities(ref list);

            Puts(string.Format("Found {0} prefabs that derive from BaseEntity", list.Count));

            for (int i = 0; i < list.Count; i++)
            {
                // Do Something
            }

            Facepunch.Pool.FreeList(ref list);
        }

        private void GetCustomSpawnpoints()
        {
            List<Transform> list = Facepunch.Pool.GetList<Transform>();

            RustEditAPI.GetSpawnpoints(ref list);

            Puts(string.Format("Found {0} map placed spawn points", list.Count));

            for (int i = 0; i < list.Count; i++)
            {
                // Do Something
            }

            Facepunch.Pool.FreeList(ref list);
        }
        #endregion

        #region Hooks
        [HookMethod("RustEdit_NPCSpawned")]
        private void RustEdit_NPCSpawned(BasePlayer npc)
        {
            Puts("An NPC was just spawned via a NPCSpawner placed on the map");
        }

        [HookMethod("RustEdit_APCSpawned")]
        private void RustEdit_APCSpawned(BradleyAPC apc)
        {
            Puts("An APC was just spawned on a custom APC path");
        }
        #endregion
    }
}
