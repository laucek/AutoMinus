using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Utils.Languages
{
    public class Lithuanian : Language
    {
        public override string LoginString { get; } = "Prisijungti";
        public override string ProfileString { get; } = "Profilis";
        public override string ForumString { get; } = "Forumas";
        public override string HelpRequestString { get; } = "Prašyti pagalbos";
        public override string UserListString { get; } = "Vartotojų sąrašas";
        public override string LogoutString { get; } = "Atsijungti";

        /// <summary>
        /// Car search
        /// </summary>
        public override string MakeString { get; } = "Marke";
        public override string ModelString { get; } = "Modelis";
        public override string YearFromString { get; } = "Metai nuo";
        public override string YearToString { get; } = "Metai iki";
    }
}