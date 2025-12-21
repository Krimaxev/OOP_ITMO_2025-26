using Lab_2.Models.Hero;

public class Bag
{
    private List<Subject> Subjects = new List<Subject>();

    public void AddSubject(Subject subject)
    {
        Subjects.Add(subject);
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
