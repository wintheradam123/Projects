using System;
using System.Collections.Generic;
using System.Linq;
using dateapp.Personal_Info;

namespace dateapp.Personal_Info
{
    public class Se_profil
    {
        public static void Get_ProfilData()
        {
            Console.Clear();
            SeeInfoProcedure.SeeInfo(usID.Userid);

            Profil_menu.ReturnMenu();
        }
    }
}

