namespace Licenta.Models
{
  

    public class AppSession
    {
        private static AppSession instance;
        public bool IsUserLogged {get; private set; }
        public User LoggedUser {get; private set; }

        protected AppSession()
        {
        }

        public static AppSession Instance()
        {
            if (instance==null)
            {
                instance = new AppSession();
            }
            return instance;
        }

        public static void Login(User newUser)
        {
            var a = new AppSession();
            a.LoggedUser = newUser;
            a.IsUserLogged = true;
            instance = a;
        }

        public static void LogOut()
        {
            var a = new AppSession();
            a.LoggedUser = null;
            a.IsUserLogged = false;
            instance = a;
        }


    }
}