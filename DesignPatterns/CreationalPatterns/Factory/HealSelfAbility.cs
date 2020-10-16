using UnityEngine;

namespace DesignPatterns.Factory
{
    public class HealSelfAbility : IAbility
    {
        public string Name => "heal";

        public void Perform()
        {
            Debug.Log("Healing self...");
        }
    }
}