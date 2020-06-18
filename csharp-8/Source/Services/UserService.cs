using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {

        CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            var query = (from ca in _context.Candidates
                                  join us in _context.Users on ca.UserId equals us.Id
                                  join ac in _context.Accelerations on ca.AccelerationId equals ac.Id
                                  where ac.Name == name
                                  select us);


            return query.ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            var query = (from us in _context.Users
                         join ca in _context.Candidates on us.Id equals ca.UserId
                         join co in _context.Companies on ca.CompanyId equals co.Id
                         where co.Id == companyId
                         select us);

            return query.Distinct().ToList();
        }

        public User FindById(int id)
        {
            User user = _context.Users.FirstOrDefault(b => b.Id == id);
            return user;
        }

        public User Save(User user)
        {
            if (user.Id == 0)
                _context.Add(user);
            else
                _context.Update(user);

            _context.SaveChanges();
            return user;
        }
    }
}
