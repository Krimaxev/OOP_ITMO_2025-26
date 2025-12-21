using Xunit;
using Lab_2.Models.Hero;
using Lab_2.Models.Inventory;


namespace Lab_2.Tests
{
    public class BagTests
    {
        [Fact]
        public void AddSubject()
        {
            var bag = new Bag();
            
            bag.AddSubject();
            
            Assert.Equal(4, bag.SeeSubjects().Count);
        }
        
        [Fact]
        public void RemoveSubject_RemovesItem_DecreasesCount()
        {
            var bag = new Bag();
            bag.AddSubject();
            var item = bag.SeeSubjects()[0];
            
            bag.RemoveSubject(item);
            
            Assert.Equal(3, bag.SeeSubjects().Count);
        }
        
        [Fact]
        public void RemoveSubject_RemovesCorrectItem()
        {
            var bag = new Bag();
            bag.AddSubject();
            var itemToRemove = bag.SeeSubjects()[1];
            
            bag.RemoveSubject(itemToRemove);
            
            Assert.DoesNotContain(itemToRemove, bag.SeeSubjects());
        }
        
        [Fact]
        public void SeeSubjects_ReturnsNotNull()
        {
            var bag = new Bag();
            
            var subjects = bag.SeeSubjects();
            
            Assert.NotNull(subjects);
        }
        
        [Fact]
        public void SeeSubjects_EmptyBag_ReturnsEmptyList()
        {
            var bag = new Bag();
            
            var subjects = bag.SeeSubjects();
            
            Assert.Empty(subjects);
        }
        
        [Fact]
        public void RemoveSubject_NonExistentItem_DoesNotThrow()
        {
            var bag = new Bag();
            bag.AddSubject();
            var externalWeapon = new Weapon();
            
            var exception = Record.Exception(() => bag.RemoveSubject(externalWeapon));
            
            Assert.Null(exception);
        }
    }
}