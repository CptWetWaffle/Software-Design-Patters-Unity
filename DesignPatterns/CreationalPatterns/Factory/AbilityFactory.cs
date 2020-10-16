using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignPatterns.Factory
{
    public class AbilityFactory : MonoSingleton<AbilityFactory>, ISimpleFactory<IAbility>
    {
        private readonly Dictionary<string, Type> _abilitiesByName;
        public IEnumerable<string> Descriptors => _abilitiesByName.Keys;

        public AbilityFactory()
        {
            _abilitiesByName = new Dictionary<string, Type>();

            var abilityTypes = Assembly.GetAssembly(typeof(IAbility)).GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(IAbility)));

            foreach (var abilityType in abilityTypes)
            {
                var temp = Activator.CreateInstance(abilityType) as IAbility;
                if (temp == null) continue;
                _abilitiesByName.Add(temp.Name, abilityType);
            }
        }

        public IAbility Get(string descriptor)
        {
            return _abilitiesByName.ContainsKey(descriptor)
                ? Activator.CreateInstance(_abilitiesByName[descriptor]) as IAbility
                : null;
        }
    }
}