using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        CodenationContext _context;

        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            var query = (from ca in _context.Candidates 
                         join ac in _context.Accelerations on ca.AccelerationId equals ac.Id
                         where ac.Id == accelerationId
                         select ca);

            return query.Distinct().ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            var query = (from ca in _context.Candidates
                         join co in _context.Companies on ca.CompanyId equals co.Id
                         where co.Id == companyId
                         select ca);

            return query.Distinct().ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            Candidate candidate = _context.Candidates.FirstOrDefault(x => x.UserId == userId &&
                x.AccelerationId == accelerationId &&
                x.CompanyId == companyId);

            return candidate;
        }

        public Candidate Save(Candidate candidate)
        {
            Candidate ca = _context.Candidates.FirstOrDefault(x => x.UserId == candidate.UserId && 
                x.AccelerationId == candidate.AccelerationId && 
                x.CompanyId == candidate.CompanyId);
            
            if (ca == null)
                _context.Add(candidate);
            else
                _context.Update(candidate);

            _context.SaveChanges();
            return candidate;
        }
    }
}
