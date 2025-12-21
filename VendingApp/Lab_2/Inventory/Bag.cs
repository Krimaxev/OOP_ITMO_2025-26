using Lab_2.Models.Hero;
namespace Lab_2.Models.Inventory;


public class Bag: IInventory
{
    private List<Subject> Subjects = new List<Subject>();

    public void AddSubject()
    {
        var newWeapon = new Weapon();
        var newArmor = new Armor();
        var newPotion = new Potion();
        var newQuestSubject = new QuestSubject();
        
        Subjects.Add(newWeapon);
        Subjects.Add(newArmor);
        Subjects.Add(newPotion);
        Subjects.Add(newQuestSubject);
        
    }

    public void RemoveSubject(Subject subject)
    {
        Subjects.Remove(subject);
    }
    

    public List<Subject> SeeSubjects()
    {
        return Subjects;
    }
}
