﻿using UnityEngine;

namespace DesignPatterns
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null) _instance = new GameObject($"Instance of {typeof(T)}").AddComponent<T>();

                return _instance;
            }
        }

        public void Awake()
        {
            if (_instance != null)
                Destroy(this.gameObject);
        }
    }
}