namespace SamuraiDojo.Attributes.Bonus
{
    public class GoldfishAwardAttribute : BonusPointsAttribute
    {
        public override int Points { get; } = 3;

        public override string Name { get; } = "Goldfish Award";

        public override string Description { get; } = "This award goes to the player whose algorithm allocated the least amount of memory during execution. (Goldfish have very little memory...)";
    }
}
