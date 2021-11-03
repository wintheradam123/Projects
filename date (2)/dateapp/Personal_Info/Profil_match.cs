using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp.Personal_Info;

namespace dateapp.Personal_Info
{
    public class Profil_match
    {
        public static void match()
        {
            Console.Clear();
            SeeMatchesProc.SeeMatches(usID.Userid);

            Profil_menu.ReturnMenu();
        }
    }
}
