using HealthcareMember360.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.AddMember.Test
{
    public class AddMemberService : IMemberService
    {
        private List<Member> _members;
        public AddMemberService()
        {
            _members = new List<Member>();
            _members.Add(new Member()
            {
                MemberID = 0,
                FirstName = "Senthilkumar",
                LastName = "Arjunan",
                EmailAddress = "senthilkumara@cts.com",
                Address = "Chennai",
                State = "TN",
                SSN = "987654321",
                PhysicianId = 0
            });
            _members.Add(new Member()
            {
                MemberID = 0,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                EmailAddress = "TestFirstName@cts.com",
                Address = "Chennai",
                State = "TN",
                SSN = "785214563",
                PhysicianId = 0
            });
        }
        public Task<Member> GetMemberByID(int memberID)
        {
            //return Task.FromResult<List<Member>>(_members[0].MemberID);
            throw new NotImplementedException();
        }

        public Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Member>> GetMembers()
        {
            return Task.FromResult<List<Member>>(_members);
        }

        public Task<int> SaveMember(MemberRequest memberRequest)
        {
            return Task.FromResult<int>(1);
        }

        public Task<int> UpdateMember(Member member)
        {
            throw new NotImplementedException();
        }
        public Task DeleteMemberByID(int memberID)
        {
            throw new NotImplementedException();
        }
    }
}
