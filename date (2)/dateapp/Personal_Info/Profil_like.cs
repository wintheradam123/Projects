using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp.Personal_Info;
using dateapp;


namespace dateapp.Personal_Info
{
    public class Profil_like
    {
        public static void Like()
        {
            Console.Clear();
            LikeBack.SeeLikes(usID.Userid);

            Profil_menu.ReturnMenu();
        }
    }
    
}