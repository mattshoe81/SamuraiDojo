using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.Attributes;
using SamuraiDojo.IOC.Interfaces;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Models
{
    /// <summary>
    /// Collection of all BattleAttributes. They are sorted by most recent, where index 0 is most recent.
    /// </summary>
    public class BattleCollection : IBattleCollection
    {
        public BattleCollection()
        {
            All = new List<IBattleAttribute>();
            Load();
        }

        public int Count => All.Count;

        public List<IBattleAttribute> All { get; private set; }

        public IBattleAttribute Get(int i)
        {
            if (i < Count && i >= 0)
                return All[i];
            else
                return null;
        }

        private void Load()
        {
            Type[] battleTypes =
                   ReflectionUtility.LoadTypesWithAttribute<BattleAttribute>("SamuraiDojo")
                   .Where(type => !AttributeUtility.HasAttribute<WrittenByAttribute>(type))
                   .OrderByDescending(type => AttributeUtility.GetAttribute<BattleAttribute>(type).Deadline).ToArray();

            for (int i = 0; i < battleTypes.Length; i++)
            {
                BattleAttribute battleAttribute = AttributeUtility.GetAttribute<BattleAttribute>(battleTypes[i]);
                battleAttribute.Type = battleTypes[i];
                All.Add(battleAttribute);
            }
        }

    }
}
