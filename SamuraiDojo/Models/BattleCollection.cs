using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Models
{
    /// <summary>
    /// Collection of all BattleAttributes. They are sorted by most recent, where index 0 is most recent.
    /// </summary>
    public class BattleCollection
    {
        static BattleCollection()
        {
            All = new List<BattleAttribute>();
            Load();
        }

        public static int Count
        {
            get => All.Count;
        }

        public static List<BattleAttribute> All { get; private set; }

        public static BattleAttribute Get(int i)
        {
            if (i < Count && i >= 0)
                return All[i];
            else
                return null;
        }

        private static void Load()
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
