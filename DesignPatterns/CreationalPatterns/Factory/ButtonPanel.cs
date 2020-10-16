using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DesignPatterns.Factory
{
    public class ButtonPanel : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab;

        private void OnEnable()
        {
            foreach (var descriptor in AbilityFactory.Instance.Descriptors)
            {
                var button = Instantiate(buttonPrefab, transform, true);
                button.gameObject.name = $"{descriptor}Button";
                button.GetComponent<Button>().clicked += () => AbilityFactory.Instance.Get(descriptor).Perform();
            }
        }
    }
}