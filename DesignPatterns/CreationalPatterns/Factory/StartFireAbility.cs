using System;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class StartFireAbility : IAbility
    {
        public string Name => "fire";

        public void Perform()
        {
            Debug.Log("Starting a fire...");
        }
    }
}