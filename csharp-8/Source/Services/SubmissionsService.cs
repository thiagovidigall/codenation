using System.Collections.Generic;
using System.Linq;
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
                         join ac in _context.Accelerations on ch.Id equals ac.ChallengeId
                         where ac.Id == accelerationId && ac.ChallengeId == challengeId
                         select su);

            return query.Distinct().ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            decimal score = _context.Submissions.Join(
                            _context.Challenges,
                            s => s.ChallengeId,
                            c => c.Id,
                            (s, c) => new { s, c }
                        ).OrderByDescending(x => x.s.Score).Select(x => x.s.Score).First();                            

            return score;
        }

        public Submission Save(Submission submission)
        {
            Submission su = _context.Submissions.FirstOrDefault(x => x.UserId == submission.UserId &&
                x.ChallengeId == submission.ChallengeId);

            if (su == null)
                _context.Add(submission);
            else
                _context.Update(submission);

            _context.SaveChanges();
            return submission;
        }
    }
}
