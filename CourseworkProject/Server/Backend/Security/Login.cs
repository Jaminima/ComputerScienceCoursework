using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server.Backend.Security
{
    public static class Login
    {
        static Dictionary<string, int> LoginTokens = new Dictionary<string, int> { };
        public static string PerformLogin(Data.Database.Emulation.User User)
        {
            Data.Database.Emulation.User LocalUser = Data.Database.Interaction.User.GetUser.FromID(User.UserID,true);
            if (User.HashedPassword == LocalUser.HashedPassword)
            {
                string Token = Tokens.CreateToken();
                if (LoginTokens.Values.Contains(User.UserID)) { foreach (KeyValuePair<string, int> Pair in LoginTokens) { if (Pair.Value == User.UserID) { LoginTokens.Remove(Pair.Key); break; } } }
                LoginTokens.Add(Token, User.UserID);
                return Token;
            }
            return null;
        }
        public static LoginToken IsValidToken(string Token)
        {
            if (!LoginTokens.ContainsKey(Token)) { return new LoginToken(); }
            return new LoginToken(Data.Database.Interaction.User.GetUser.FromID(LoginTokens[Token]));
        }
        public static LoginToken IsValidToken(HttpListenerContext Context)
        {
            if (!Context.Request.Headers.AllKeys.Contains("AuthToken")) { return new LoginToken(); }
            return IsValidToken(Context.Request.Headers["AuthToken"]);
        }
    }

    public class LoginToken
    {
        public bool IsValid;
        public Data.Database.Emulation.User User;
        public LoginToken() { IsValid = false; User = null; }
        public LoginToken(Data.Database.Emulation.User U)
        {
            IsValid = U != null;
            User = U;
        }
    }
}
