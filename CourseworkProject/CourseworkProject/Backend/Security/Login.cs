using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Security
{
    public static class Login
    {
        static Dictionary<int, Objects.Login> LoginTokens = new Dictionary<int, Objects.Login> { };
        public static Objects.Token PerformLogin(Data.Database.Emulation.User User)
        {
            Data.Database.Emulation.User LocalUser = Data.Database.Interaction.User.GetUser.FromID(User.UserID,true);
            if (User.HashedPassword == LocalUser.HashedPassword)
            {
                Objects.Token Token = Tokens.CreateTokenLogin(LocalUser);
                if (LoginTokens.Keys.Contains(User.UserID)) { LoginTokens.Remove(User.UserID); }
                LoginTokens.Add(User.UserID, new Objects.Login(LocalUser, Token));
                return Token;
            }
            return null;
        }
    }
}
