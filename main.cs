using MelonLoader;
using Il2CppRUMBLE.MoveSystem;

namespace ShakyCollisions
{
    public class main : MelonMod
    {

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "Loader")
            {
                CombatManager.instance.structureImpactShakeStrength *= 5;
            }
        }
    }
}
