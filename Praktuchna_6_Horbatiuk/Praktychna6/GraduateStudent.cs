using System;

namespace Praktychna6;

// sealed: від цього класу не можна успадковуватись далі.
public sealed class GraduateStudent : Student
{
    public string ResearchTopic { get; set; }

    public GraduateStudent(string fullName, DateTime dateOfBirth, string recordBookNumber, string researchTopic)
        : base(fullName, dateOfBirth, recordBookNumber)
    {
        ResearchTopic = researchTopic;
    }

    public override decimal CalculateScholarship()
    {
        // Аспіранти отримують фіксовану підвищену стипендію.
        return 3000m;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $" [аспірант, тема: {ResearchTopic}]";
    }
}
