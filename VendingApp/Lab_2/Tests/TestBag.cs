using Xunit;
using Lab_2.Models.Hero;

namespace Lab_2.Tests
{
    public class BagTests
    {
        [Fact]
        public void AddSubjectSingleItemIncreasesCount()
        {
            var bag = new Bag();
            var weapon = new Weapon();
            
            bag.AddSubject(weapon);
            
            Assert.Single(bag.SeeSubjects());
        }
        
        [Fact]
        public void AddSubjectMultipleItemsCorrectCount()
        {
            var bag = new Bag();
            var weapon = new Weapon();
            var armor = new Armor();
            var potion = new Potion();
            
            bag.AddSubject(weapon);
            bag.AddSubject(armor);
            bag.AddSubject(potion);
            
            Assert.Equal(3, bag.SeeSubjects().Count);
        }
        
        [Fact]
        public void AddSubjectItemIsActuallyInBag()
        {
            var bag = new Bag();
            var weapon = new Weapon { Name = "Sword" };
            
            bag.AddSubject(weapon);
            
            Assert.Contains(weapon, bag.SeeSubjects());
        }
        
        [Fact]
        public void RemoveSubjectRemovesItemDecreasesCount()
        {
            var bag = new Bag();
            var weapon = new Weapon();
            var armor = new Armor();
            bag.AddSubject(weapon);
            bag.AddSubject(armor);
            
            bag.RemoveSubject(weapon);
            
            Assert.Single(bag.SeeSubjects());
        }
        
        [Fact]
        public void RemoveSubjectRemovesCorrectItem()
        {
            var bag = new Bag();
            var weapon = new Weapon { Name = "Sword" };
            var armor = new Armor { Name = "Shield" };
            bag.AddSubject(weapon);
            bag.AddSubject(armor);
            
            bag.RemoveSubject(weapon);
            
            Assert.DoesNotContain(weapon, bag.SeeSubjects());
            Assert.Contains(armor, bag.SeeSubjects());
        }
        
        [Fact]
        public void SeeSubjectsReturnsNotNull()
        {
            var bag = new Bag();
            
            var subjects = bag.SeeSubjects();
            
            Assert.NotNull(subjects);
        }
        
        [Fact]
        public void SeeSubjectsEmptyBagReturnsEmptyList()
        {
            var bag = new Bag();
            
            var subjects = bag.SeeSubjects();
            
            Assert.Empty(subjects);
        }
        
    }
}