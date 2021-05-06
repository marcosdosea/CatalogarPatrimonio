using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Aspnetusertokens
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Aspnetusers User { get; set; }
    }
}
