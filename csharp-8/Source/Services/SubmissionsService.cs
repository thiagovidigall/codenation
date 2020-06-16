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
                          join ch in _context.Challenges on su.ChallengeId equals ch.Id
                          join us in _context.Users on su.UserId equals us.Id
                          join ac in _context.Accelerations on ch.Id equals ac.ChallengeId
                          where ch.Id == challengeId && ac.Id == accelerationId
                          select su);

            return query.ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            var query1 = (from su in _context.Submissions
                         join ch in _context.Challenges on su.ChallengeId equals ch.Id
                         join us in _context.Users on su.UserId equals us.Id
                         where ch.Id == challengeId
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
