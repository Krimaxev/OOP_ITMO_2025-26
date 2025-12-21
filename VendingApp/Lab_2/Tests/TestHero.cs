using Xunit;
using Lab_2.Models.Hero;

namespace Lab_2.Tests
{
    public class HeroTests
    {
        [Fact]
        public void WearAddsWeaponIncreasesStrong()
        {
            var hero = new Hero();
            var weapon = new Weapon { DestroyNum = 20, Category = "Weapon" };
            int initialStrong = hero.GetStrong();
            
            hero.Wear(weapon);
            
            Assert.Equal(initialStrong + 20, hero.GetStrong());
            Assert.Equal(1, hero.GetWeaponsCount());
        }
        
        [Fact]
        public void WearAddsArmorIncreasesProtection()
        {
            var hero = new Hero();
            var armor = new Armor { ProtectionLevel = 15, Category = "Armor" };
            int initialProtection = hero.GetProtection();
            
            hero.Wear(armor);
            
            Assert.Equal(initialProtection + 15, hero.GetProtection());
            Assert.Equal(1, hero.GetArmorsCount());
        }
        
        [Fact]
        public void WearSecondWeaponDoesNotAdd()
        {
            var hero = new Hero();
            var weapon1 = new Weapon { DestroyNum = 10, Category = "Weapon" };
            var weapon2 = new Weapon { DestroyNum = 20, Category = "Weapon" };
            
            hero.Wear(weapon1);
            hero.Wear(weapon2);
            
            Assert.Equal(1, hero.GetWeaponsCount());
        }
        
        [Fact]
        public void UnwearRemovesWeaponDecreasesStrong()
        {
            var hero = new Hero();
            var weapon = new Weapon { DestroyNum = 20, Category = "Weapon" };
            hero.Wear(weapon);
            int strongWithWeapon = hero.GetStrong();
            
            hero.Unwear(weapon);
            
            Assert.Equal(strongWithWeapon - 20, hero.GetStrong());
            Assert.Equal(0, hero.GetWeaponsCount());
        }
        
        [Fact]
        public void UnwearRemovesArmorDecreasesProtection()
        {
            var hero = new Hero();
            var armor = new Armor { ProtectionLevel = 15, Category = "Armor" };
            hero.Wear(armor);
            int protectionWithArmor = hero.GetProtection();
            
            hero.Unwear(armor);
            
            Assert.Equal(protectionWithArmor - 15, hero.GetProtection());
            Assert.Equal(0, hero.GetArmorsCount());
        }
        
        [Fact]
        public void UpgradeWithoutEquipment()
        {
            var hero = new Hero();
            
            var exception = Record.Exception(() => hero.Upgrade());
            
            Assert.Null(exception);
        }
        
        [Fact]
        public void WearMultipleQuestSubjects()
        {
            var hero = new Hero();
            var quest1 = new QuestSubject { Category = "QuestSubject" };
            var quest2 = new QuestSubject { Category = "QuestSubject" };
            
            hero.Wear(quest1);
            hero.Wear(quest2);
            
            Assert.Equal(2, hero.GetQuestSubjectsCount());
        }
    }
}