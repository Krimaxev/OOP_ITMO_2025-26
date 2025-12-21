namespace Lab_2.Models.Hero;

public class Hero
{ 
    private int Health { get; set; }
    private int Strong { get; set; }
    private int Protection { get; set; }
    

    private List<Weapon> Weapons = new List<Weapon>();
    private List<Armor> Armors = new List<Armor>();
    private List<Potion> Potions = new List<Potion>();
    private List<QuestSubject>  QuestSubjects = new List<QuestSubject>();
    
    public int GetStrong() => Strong;
    public int GetProtection() => Protection;
    public int GetWeaponsCount() => Weapons.Count;
    public int GetArmorsCount() => Armors.Count;
    public int GetQuestSubjectsCount() => QuestSubjects.Count;
    
    
    
    
    public void Wear(Subject subject)
    {
        if (subject is Weapon weapon && Weapons.Count == 0)
        {
            Weapons.Add(weapon);
            Strong += weapon.DestroyNum;
        }

        if (subject is Armor armor && Armors.Count == 0)
        {   
            Armors.Add(armor);
            Protection += armor.ProtectionLevel;
        }
        
        if (subject is Potion potion && Potions.Count == 0)
        {   
            Potions.Add((Potion)subject);
            Health += potion.GiveHealth;
        }

        if (subject is QuestSubject questSubject)
        {   
            QuestSubjects.Add(questSubject);
        }
        
    }

    public void Unwear(Subject subject)
    {
        
        if (subject is Weapon weapon && Weapons.Count == 1)
        {   
            Weapons.Remove(weapon);
            Strong -= weapon.DestroyNum;
        }

        if (subject is Armor armor && Armors.Count == 1)
        {   
            Armors.Remove(armor);
            Protection -= armor.ProtectionLevel;
        }

        if (subject is Potion potion && Potions.Count == 1)
        {   
            Potions.Remove(potion);
            Health -= potion.GiveHealth;
        }

        if (subject is QuestSubject questSubject)
        {
            QuestSubjects.Remove(questSubject);
        }
    }
 
    public void Upgrade()
    {   
        if (Weapons.Count == 1)
        {   
            var upgradedWeapon  = Weapons[0];
            upgradedWeapon.UpgradeLevel += 1;
            upgradedWeapon.DestroyNum *= 2;
        }

        if (Armors.Count == 1)
        {
            var upgradedArmor = Armors[0];
            upgradedArmor.UpgradeLevel += 1;
            upgradedArmor.ProtectionLevel *= 2;
        }
        
    }
    
}