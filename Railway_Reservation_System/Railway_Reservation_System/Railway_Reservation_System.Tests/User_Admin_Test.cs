using NUnit.Framework;
using NUnit.Framework.Legacy;
using Railway_Reservation_System;

namespace Railway_Reservation_System.Tests
{

    [TestFixture]
    public class UserAdminTests
    {
        [Test]
        public void IsValidAdmin()
        {
            string username="Admin1";
            string password = "rrs@123";
            string role = "Admin";
            string role1 = AuthUser.Authenticate(username, password, role);
            ClassicAssert.AreEqual("Admin", role1);
        }

        [Test]
        public void IsValidUser()
        {
            string username = "shams@123";
            string password = "mypwd";
            string role = "User";
            string result = AuthUser.Authenticate(username, password, role);
            ClassicAssert.AreEqual("User", result);
        }

        [Test]
        public void InvalidPassword_ShouldFail()
        {
            string username = "shams@123";
            string password = "wrongpwd";
            string role = "User";
            string result = AuthUser.Authenticate(username, password, role);
            ClassicAssert.AreNotEqual("User", result);
        }

        [Test]
        public void InvalidRole_ShouldFail()
        {
            string username = "Admin1";
            string password = "rrs@123";
            string role = "Guest"; 
            string result = AuthUser.Authenticate(username, password, role);
            ClassicAssert.AreNotEqual("Admin", result);
        }


    }

}
