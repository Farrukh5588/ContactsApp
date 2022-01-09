using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace ContactsApp.UnitTest
{
    [TestFixture]
    public class ContactTest
    {
        public Contact PrepareContact()
        {
            var sourceNumber = 79996196969;
            var phoneNumber = new PhoneNumber
            {
                Number = sourceNumber
            };
            var contact = new Contact
            {
                Name = "John",
                Surname = "Smith",
                DateOfBirth = new DateTime(2000,1,1),
                PhoneNumber = phoneNumber,
                Email = "white@bk.com",
                IdVk = "463723"
            };
            return contact;
        }
        [Test]
        public void Name_CorrectName_ReturnsSameName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "123456789";
            var expectedName = sourceName;

            //Act
            contact.Name = sourceName;
            var actualName = contact.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_WrongName_ReturnsUpperCaseName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop ";
  
            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Name = sourceName;
                }
            );
        }

        [Test]
        public void Name_EmptyName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Name = sourceName;
                }
            );
        }

        [Test]
        public void Surname_CorrectSurname_ReturnsSameSurname()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "Rakhimov";
            var expectedSurname = sourceSurname;

            //Act
            contact.Surname = sourceSurname;
            var actualSurname = contact.Surname;

            //Assert
            Assert.AreEqual(expectedSurname, actualSurname);
        }

        [Test]
        public void Surname_WrongName_ReturnsUpperCaseName()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop ";
           
            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Surname = sourceSurname;
                }
            );
        }

        [Test]
        public void Surname_EmprtyName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Surname = sourceSurname;
                }
            );
        }

        [Test]
        public void Email_CorrectEmail_ReturnSameEmail()
        {
            //Setup
            var contact = new Contact();
            var sourceEmail = "Rakhimov@gmail.com";
            var expectedEmail = sourceEmail;

            //Act
            contact.Email = sourceEmail;
            var actualEmail = contact.Email;

            //Assert
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public void Email_TooLongEmail_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceEmail = "123456789 123456789 123456789 123456789 123456789 123456";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Email = sourceEmail;
                }
            );
        }

        [Test]
        public void IdVk_CorrectIdVk_ReturnSameIdVk()
        {
            //Setup
            var contact = new Contact();
            var sourceIdVk = "2266677";
            var expectedIdVk = sourceIdVk;

            //Act
            contact.IdVk = sourceIdVk;
            var actualIdVk = contact.IdVk;

            //Assert
            Assert.AreEqual(expectedIdVk, actualIdVk);
        }

        [Test]
        public void IdVk_TooLongIdVk_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceIdVk = "qwertyuiop qwertyuiop qwertyuiop";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.IdVk = sourceIdVk;
                }
            );
        }

        [Test]
        public void BirthDate_GoodBirthDate_ReturnsSameBirthDate()
        {
            //Setup
            var contact = new Contact();
            var sourceBirthDate = DateTime.Today;
            var expectedBirthDate = sourceBirthDate;

            //Act
            contact.DateOfBirth = sourceBirthDate;
            var actualBirthDate = contact.DateOfBirth;

            //Assert
            Assert.AreEqual(expectedBirthDate, actualBirthDate);
        }

        [Test]
        public void BirthDate_OutOfRangeBirthDate_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceBirthDate = new DateTime(2222, 1, 1);

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.DateOfBirth = sourceBirthDate;
                }
            );
        }

        [Test]
        public void Birthday_TooSmallBirthday_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceBirthday = new DateTime(1800, 1, 1);

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.DateOfBirth = sourceBirthday;
                }
            );
        }

        [Test]
        public void Clone_GoodClone_ReturnsSameObject()
        {
            //Setup
            var expectedContact = PrepareContact();

            //Act
            var actualContact = expectedContact.Clone() as Contact;
           
            //Assert
            Assert.AreEqual(expectedContact, actualContact);
        }
    }
}
