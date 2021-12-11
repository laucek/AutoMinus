using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Utils.Languages
{
    public abstract class Language
    {
        public abstract string LoginString { get; }
        public abstract string ProfileString { get; }
        public abstract string ForumString { get; }
        public abstract string HelpRequestString { get; }
        public abstract string UserListString { get; }
        public abstract string LogoutString { get; }

        /// <summary>
        /// Car search
        /// </summary>
        public abstract string MakeString { get; }
        public abstract string ModelString { get; }
        public abstract string YearFromString { get; }
        public abstract string YearToString { get; }


    }
}