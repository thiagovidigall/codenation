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
                         join co in _context.Companies on ca.CompanyId equals co.Id
                         where ca.AccelerationId == accelerationId
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
                         join co in _context.Companies on ca.CompanyId equals co.Id
                         where ca.UserId == userId
                         select co).Distinct();

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