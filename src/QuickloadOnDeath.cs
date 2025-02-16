using UnityEngine;
using DaggerfallWorkshop.Game.Utility.ModSupport; // Required for mod support
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game; // Required for GameManager
using DaggerfallWorkshop.Game.Serialization;

public class QuickloadOnDeathMod : MonoBehaviour
{
    public static Mod Mod;

    [Invoke(StateManager.StateTypes.Start, 0)]
    public static void Init(InitParams initParams)
    {
        // Store the mod reference
        Mod = initParams.Mod;

        // Create a new GameObject to hold the mod component
        GameObject go = new GameObject(Mod.Title);
        go.AddComponent<QuickloadOnDeathMod>();

        Mod.IsReady = true;
    }

    void Start()
    {
        GameManager.Instance.PlayerEntity.OnDeath += OnPlayerDeath;
    }
    void OnPlayerDeath(DaggerfallEntity entity)
    {
        SaveLoadManager.Instance.QuickLoad();
    }
}
