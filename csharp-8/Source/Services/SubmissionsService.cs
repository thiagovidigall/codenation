using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            var query = (from su in _context.Submissions
                         join us in _context.Users on su.UserId equals us.Id
                         join ca in _context.Candidates on us.Id equals ca.UserId
                          where su.ChallengeId == challengeId && ca.AccelerationId == accelerationId
                          select su);

            return query.Distinct().ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            var query1 = (from su in _context.Submissions
                         join ch in _context.Challenges on su.ChallengeId equals ch.Id
                         where su.ChallengeId == challengeId
                         select su.Score).OrderByDescending(x => x).ToList();

            return query1.First();
        }

        public Submission Save(Submission submission)
        {
            Submission su = _context.Submissions.FirstOrDefault(x => x.UserId == submission.UserId &&
                x.ChallengeId == submission.ChallengeId);

            if (su == null)
                _context.Add(submission);
            else
                _context.Entry(_context.Submissions
                    .FirstOrDefault(x => x.UserId == submission.UserId && x.ChallengeId == submission.ChallengeId))
                    .CurrentValues.SetValues(submission);

            _context.SaveChanges();
            return submission;
        }
    }
}
