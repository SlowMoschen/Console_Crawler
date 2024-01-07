using NUnit.Framework;

namespace Console_Crawler.GameUtilities.__tests__
{
    [TestFixture]
    internal class DamageCalculator_test
    {
        [Test]
        public void CalculateDamageReduction()
        {
            int targetArmor = 10;
            
            Assert.That(DamageCalculator.CalculateDamageReduction(targetArmor), Is.EqualTo(0.09));
        }

        [Test]
        public void CalculateAttackDamage_WithOut_SpecialAttack()
        {
            int attackDamage = 10;
            int targetArmor = 10;
            double strength = 1.0;
            int specialAttackDamage = 0;

            Assert.That(DamageCalculator.CalculateAttackDamage(attackDamage, targetArmor, strength, specialAttackDamage), Is.EqualTo(9));
        }

        [Test]
        public void CalculateAttackDamage_With_SpecialAttack()
        {
            int attackDamage = 10;
            int targetArmor = 10;
            double strength = 1.0;
            int specialAttackDamage = 10;

            Assert.That(DamageCalculator.CalculateAttackDamage(attackDamage, targetArmor, strength, specialAttackDamage), Is.EqualTo(18));
        }
    }
}
