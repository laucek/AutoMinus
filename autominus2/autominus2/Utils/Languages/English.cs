using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Utils.Languages
{
    public class English : Language
    {
        public override string LoginString { get; } = "Login";
        public override string ProfileString { get; } = "Profile";
        public override string ForumString { get; } = "Forum";
        public override string HelpRequestString { get; } = "Request help";
        public override string UserListString { get; } = "User list";
        public override string LogoutString { get; } = "Logout";

        /// <summary>
        /// Car search
        /// </summary>
        public override string MakeString { get; } = "Make";
        public override string ModelString { get; } = "Model";
        public override string YearFromString { get; } = "Year from";
        public override string YearToString { get; } = "Year to";
    }
}