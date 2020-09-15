using HealthcareMember360.AddMember.API.Controllers;
using HealthcareMember360.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace HealthcareMember360.AddMember.Test
{
    public class AddMemberControllerTest
    {
        private readonly IMemberService _memberService;
        private AddMemberController _memberController;
        private List<Member> _members;
        public AddMemberControllerTest()
        {
            _memberService = new AddMemberService();
            _memberController = new AddMemberController(_memberService);

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
        [Test]
        public void SaveMembers()
        {
            MemberRequest memberRequest = new MemberRequest()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                EmailAddress = "TestFirstName@cts.com",
                Address = "Chennai",
                State = "TN",
                SSN = "785214563",
            };
            var result = _memberController.AddMember(memberRequest);
        }

    }
}
