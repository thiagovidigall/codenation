using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        CodenationContext _context;
        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            var query = (from ac in _context.Accelerations
                         join ca in _context.Candidates on ac.Id equals ca.AccelerationId
                         join co in _context.Companies on ca.CompanyId equals co.Id
                         where co.Id == companyId
                         select ac);

            return query.Distinct().ToList();
        }

        public Acceleration FindById(int id)
        {
            Acceleration ac = _context.Accelerations.FirstOrDefault(b => b.Id == id);
            return ac;
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id == 0)
                _context.Add(acceleration);
            else
                _context.Update(acceleration);

            _context.SaveChanges();
            return acceleration;
        }
    }
}
