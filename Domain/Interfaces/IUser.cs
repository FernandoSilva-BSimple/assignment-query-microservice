namespace Domain.Interfaces;

public interface IUser
{
    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }
}