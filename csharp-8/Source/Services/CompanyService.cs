using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            var query = (from ca in _context.Candidates
                         join us in _context.Users on ca.UserId equals us.Id
                         join ac in _context.Accelerations on ca.AccelerationId equals ac.Id
                         join co in _context.Companies on ca.CompanyId equals co.Id
                         where ac.Id == accelerationId
                         select co);

            return query.ToList();
        }

        public Company FindById(int id)
        {
            Company company = _context.Companies.FirstOrDefault(b => b.Id == id);
            return company;
        }

        public IList<Company> FindByUserId(int userId)
        {
            var query = (from ca in _context.Candidates                         
                         join us in _context.Users on ca.UserId equals us.Id
                         join ac in _context.Accelerations on ca.AccelerationId equals ac.Id
                         join co in _context.Companies on ca.CompanyId equals co.Id
                         where us.Id == userId
                         select co);

            return query.ToList();
        }

        public Company Save(Company company)
        {
            if (company.Id == 0)
                _context.Add(company);
            else
                _context.Update(company);

            _context.SaveChanges();
            return company;
        }
    }
}