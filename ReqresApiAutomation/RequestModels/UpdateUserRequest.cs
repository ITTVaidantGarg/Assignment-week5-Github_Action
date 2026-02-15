using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace ReqresApiAutomation.RequestModels
{
        public class UpdateUserRequest
        {
            public required string name { get; set; }
            public required string job { get; set; }
        }
    }
