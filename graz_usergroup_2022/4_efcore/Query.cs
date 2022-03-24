using System.Diagnostics.Contracts;
using HotChocolate.Subscriptions;
using Newtonsoft.Json;

namespace Demo;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Student> GetStudents(SchoolContext context)
        => context.Students;
}

public class Mutation
{
    public async Task<Student> RegisterStudentAsync(
        string lastName,
        string firstMidName,
        SchoolContext context,
        [Service] ITopicEventSender sender,
        CancellationToken cancellationToken)
    {
        var student = new Student
        {
            LastName = lastName,
            FirstMidName = firstMidName,
            EnrollmentDate = DateTime.UtcNow
        };
        context.Students.Add(student);
        await context.SaveChangesAsync(cancellationToken);

        await sender.SendAsync("OnRegisterStudent", student.Id, cancellationToken);

        return student;
    }
}

public class Subscription
{
    [Subscribe]
    [Topic("OnRegisterStudent")]
    public async Task<Student> OnRegisterStudentAsync(
        [EventMessage] int studentId,
        SchoolContext context)
    {
        return await context.Students.Where(s => s.Id == studentId).FirstAsync();
    }
}