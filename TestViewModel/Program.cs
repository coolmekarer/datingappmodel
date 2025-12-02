
using ModelDates;
using System;
using ViewModel;
namespace TestViewModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CityDB cdb = new();
            CityList cityList = cdb.SelectAll();
            foreach(City c in cityList)
            Console.WriteLine(c.Name);
            
            GenderDB gdb = new();
            GenderList genderList = gdb.SelectAll();
            foreach (Gender g in genderList)
                Console.WriteLine(g.Name);

            UserDB udb = new();
            UserList userList = udb.SelectAll();
            foreach (User u in userList)
            {
                Console.WriteLine(u.Username+" : "+u.Gender);
                Console.WriteLine(u.Password+
               " : "+ u.Email+" : "+ u.Age+" : "+ u.Bio+" : "+ u.City+
               " : " + u.CreatedAt +" : "+ u.DateOfBirth);
            }
           Console.BackgroundColor = ConsoleColor.Red;

            DistanceBetweenCitiesDB ddb = new();
            DistanceBetweenCitiesList distancebetweencitiesList = ddb.SelectAll();
            foreach (DistanceBetweenCities d in distancebetweencitiesList)
                Console.WriteLine(d.City1+" : "+ d.City2+" : "+d.DistanceKm); 

            Console.BackgroundColor = ConsoleColor.Yellow;
            PreferencesDB pdb = new();
            PreferencesList preferencesList = pdb.SelectAll();
            foreach (Preferences p in preferencesList)
                Console.WriteLine(p.User+" : "+ p.MinAge+" : "+ p.MaxAge+" : "+ p.PreferredGender
                    +" : "+p.MaxDistanceKm);

            LikesDB ldb = new();
            LikesList likesList = ldb.SelectAll();
            foreach (Likes l in likesList)
                Console.WriteLine(l.Liker+"  :  "+l.LikedUser);

            PhotosDB phdb = new();
            PhotosList photosList = phdb.SelectAll();
            foreach (Photos ph in photosList)
                Console.WriteLine(ph.User+" : "+ ph.Url); 

            MatchesDB mdb = new();
            MatchesList matchesList = mdb.SelectAll();
            foreach (Matches m in matchesList)
                Console.WriteLine(m.User1 + "  :  " + m.User2); 

            ManagerDB mandb = new();
            ManagerList managerList = mandb.SelectAll();
            foreach (Manager man in managerList)
                Console.WriteLine(man.Password +
               " : "+man.MangPassword+" : " + man.Email + " : " + man.Age + 
               " : " + man.Bio + " : " + man.City +
               " : " + man.CreatedAt + " : " + man.DateOfBirth); 

            MessagesDB medb = new();
            MessagesList messagesList = medb.SelectAll();
            foreach (Messages me in messagesList)
                Console.WriteLine($"{me.Match.User1} & {me.Match.User2} : {me.Sender} : {me.MessageText} : {me.SentAt}");
        }
    }
}
