﻿using MelonLoader;
using Il2CppRUMBLE.MoveSystem;
using UnityEngine;

namespace ShakyCollisions
{
    public class main : MelonMod
    {
        private CombatManager combatManager;
        private string currentScene = "";
        private bool sceneChanged = false;

        public override void OnFixedUpdate()
        {
            if ((currentScene == "Loader") && (sceneChanged))
            {
                try
                {
                    combatManager = CombatManager.instance;
                    combatManager.structureImpactShakeStrength *= 5;
                    sceneChanged = false;
                }
                catch { }
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            currentScene = sceneName;
            sceneChanged = true;
        }
    }
}
