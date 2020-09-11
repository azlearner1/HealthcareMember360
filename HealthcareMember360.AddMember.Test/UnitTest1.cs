using HealthcareMember360.Core;
using NUnit.Framework;

namespace HealthcareMember360.AddMember.Test
{
    public class Tests
    {
        public Tests()
        {
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        //public async void Addmember()
        //{
        //    Member member = new Member()
        //    {
        //        MemberID = 0,
        //        FirstName = "TestFName",
        //        LastName = "TestLName",
        //        EmailAddress = "Test@cts.com",
        //        Address = "Chennai",
        //        State = "TN",
        //        SSN = "785214563",
        //        PhysicianId = 0
        //    };
        //    await _memberService.SaveMember(member);
        //    Assert.That(await _memberService.SaveMember(member), Is.Not.Null);
        //}
    }
}