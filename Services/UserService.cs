using DotnetWebAPI.Models;

namespace DotnetWebAPI.Services;

public static class UserService
{
  static List<User> Users { get; }
  static int nextId = 3;
  static UserService()
  {
    Users = new List<User>
    {
      new User { Id = 1, Name = "Gabriel Dias", Email = "gabriel.menezes.1704@gmail.com", Document = "123.456.789-0"},
      new User { Id = 2, Name = "Gabriela Araujo", Email = "gabi.amello801@gmail.com", Document = "098.765.432-1" }
    };
  }

  public static List<User> GetAll() => Users;

  public static User? Get(int id) => Users.FirstOrDefault(p => p.Id == id);

  public static User Add(User user)
  {
    user.Id = nextId++;
    Users.Add(user);
    return user;
  }

  public static void Delete(int id)
  {
    var user = Get(id);
    if (user is null)
      return;

    Users.Remove(user);
  }

  public static void Update(User user)
  {
    var index = Users.FindIndex(p => p.Id == user.Id);
    if (index == -1)
      return;

    Users[index] = user;
  }
}