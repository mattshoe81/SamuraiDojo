using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week#
{
    [Sensei(Samurai.YOU)]
    [Battle(DEADLINE, YOUR_CLEVER_BATTLE_NAME, typeof(THIS_CLASS))]
    public class CleverBattleName
    {
        /// <summary>
        /// Describe the challenge in detail here.
        /// 
        /// Constraints:
        ///     - List your constraints here
        ///     
        /// Hints:
        ///     - Optionally give hints here if you like
        ///     
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract ReturnType RenameThis(Parameters parameters);
    }
}
