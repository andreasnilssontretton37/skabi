using System.Collections.Generic;
using skabi.web.mvc.Models;

public class AccountRepository
{
    private List<LogOnModel> users = new List<LogOnModel>();

    public AccountRepository()
    {
        users.Add(new LogOnModel() { UserName = "Andreas", Password = "Andreas" });
    }

    public bool IsValidLogin(string username, string password)
    {

        foreach (LogOnModel model in users)
        {
            return (model.UserName.Equals(username) && model.Password.Equals(password));
        }

        return false;
    }

    public string[] GetRoles(string id)
    {
        return new string[] { "Admin" };
    }

}