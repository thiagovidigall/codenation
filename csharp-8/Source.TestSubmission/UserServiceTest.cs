using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System.Linq;

namespace Codenation.Challenge
{
    public class UserServiceTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_User_When_Find_By_Id(int id)
        {
            var fakeContext = new FakeContext("UserById");            
            fakeContext.FillWith<User>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<User>().Find(x => x.Id == id);

                var service = new UserService(context);                
                var actual = service.FindById(id);

                Assert.Equal(expected, actual, new UserIdComparer());
            }
        }

        [Theory]
        [InlineData("Progesterone")]
        [InlineData("Velvet Grass")]
        public void Should_Be_Right_Users_When_Find_By_Accelaration_Name(string accelerationName)
        {
            var fakeContext = new FakeContext("UserById");
            fakeContext.FillWithAll();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<User>().FindAll(x => x.FullName == accelerationName);

                var service = new UserService(context);
                var actual = service.FindByAccelerationName(accelerationName);

                Assert.Equal(expected, actual, new UserIdComparer());
            }
        }

        [Fact]
        public void Should_Add_New_User_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewUser");
            
            var fakeUser = new User();
            fakeUser.FullName = "full name";
            fakeUser.Email = "email";
            fakeUser.Nickname = "nickname";
            fakeUser.Password = "pass";
            fakeUser.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new UserService(context);
                var actual = service.Save(fakeUser);

                Assert.NotEqual(0, actual.Id);
            }
        }       

    }
}
