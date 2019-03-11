using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models;

namespace ServerlessRepository
{
    public class MemberRepository
    {
        public Models.MemberData GetMember(int id)
        {            
            MemberData memberRecord;
            return getTestData().TryGetValue(id, out memberRecord) ? memberRecord : null;            
        }

        public List<MemberData> GetAllMembers()
        {            
            List<MemberData> ret = new List<MemberData>();
            var values = getTestData().Values;
            foreach (var member in values)
            {
                ret.Add(member);
            }
            return ret;           
        }

        private Dictionary<int, MemberData> getTestData() 
        {
            // mock data
            Dictionary<int, MemberData> data = new Dictionary<int, MemberData>();
            data[1] = new MemberData() {
                Id = 1,
                FirstName = "MemberFirst1",
                LastName = "MemberLast1",
                Title = "Title1",
                Age = 40
            };
            data[2] = new MemberData() {
                Id = 2,
                FirstName = "MemberFirst2",
                LastName = "MemberLast2",
                Title = "Title2",
                Age = 50
            };
            data[3] = new MemberData() {
                Id = 3,
                FirstName = "MemberFirst3",
                LastName = "MemberLast3",
                Title = "Title3",
                Age = 60
            };
            return data;
        }
    }
}