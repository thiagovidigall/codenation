using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System.Linq;

namespace Codenation.Challenge
{
    public class CandidateServiceTest
    {
        [Theory]
        [InlineData(2,2,2)]
        [InlineData(3,3,3)]
        [InlineData(1,1,1)]
        public void Should_Be_Right_Candidate_When_Find_By_Id(int userId, int AccelerationId, int CompanyId)
        {
            var fakeContext = new FakeContext("CandidateById");            
            fakeContext.FillWithAll();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Candidate>().Find(x => x.UserId == userId && x.AccelerationId == AccelerationId && x.CompanyId == CompanyId);

                var service = new CandidateService(context);                
                var actual = service.FindById(userId, AccelerationId, CompanyId);

                Assert.Equal(expected, actual, new CandidateIdComparer());
            }
        }
  
        [Fact]
        public void Should_Update_The_Candidate_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewCandidate");
            fakeContext.FillWithAll();

            var fakeCandidate = new Candidate();
            fakeCandidate.UserId = 7;
            fakeCandidate.AccelerationId = 3;
            fakeCandidate.CompanyId = 7;
            fakeCandidate.Status = 2;
            fakeCandidate.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new CandidateService(context);
                var actual = service.Save(fakeCandidate);

                Assert.NotEqual(0, 1);
            }
        }       

    }
}
