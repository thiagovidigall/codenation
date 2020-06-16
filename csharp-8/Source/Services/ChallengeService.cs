using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            var query = (from ch in _context.Challenges
                         join ac in _context.Accelerations on ch.Id equals ac.ChallengeId
                         join ca in _context.Candidates on ac.Id equals ca.AccelerationId
                         where ca.AccelerationId == accelerationId && ca.UserId == userId
                         select ch);

            return query.Distinct().ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
                _context.Add(challenge);
            else
                _context.Update(challenge);

            _context.SaveChanges();
            return challenge;
        }
    }
}