using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Railway_Reservation_System.Tests
{
    public class User
    {
        public string Username;
        public string Password;

        public bool Login(string username, string password)
        {
            return Username == username && Password == password;
        }

        public virtual string GetRole()
        {
            return "User";
        }
    }

    public class Admin : User
    {
        public override string GetRole()
        {
            return "Admin";
        }
    }

[TestFixture]
    public class UserAdminTests
    {
        private User user;
        private Admin admin;

        [SetUp]
        public void Setup()
        {
            user = new User { Username = "shams@123", Password = "mypwd" };
            admin = new Admin { Username = "Admin1", Password = "rrs@123" };
        }

        [Test]
        public void UserLogin_ShouldSucceed()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(user.Login("shams@123", "mypwd"));
        }

        [Test]
        public void AdminLogin_ShouldSucceed()
        {
            Assert.IsTrue(admin.Login("Admin1", "rrs@123"));
        }

        [Test]
        public void UserRole_ShouldBeUser()
        {
            Assert.AreEqual("User", user.GetRole());
        }

        [Test]
        public void AdminRole_ShouldBeAdmin()
        {
            Assert.AreEqual("Admin", admin.GetRole());
        }
    }

}
