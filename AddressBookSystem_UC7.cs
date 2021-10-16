using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdressBookSystem
{
    public class AdressBookBuilder : IContacts
    {
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = AddressBook; Integrated Security = True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        /// <summary>
        /// Checks the connection.
        /// </summary>
        public void checkConnection()
        {
            try
            {
                this.sqlConnection.Open();
                Console.WriteLine("connection established");
                this.sqlConnection.Close();
            }
            catch
            {
                Console.WriteLine("not established");
            }
        }

        public List<Contact> contactList;

        /// <summary>
        /// Initializes a new instance of the list <see cref="AdressBookBuilder"/> class.
        /// </summary>
        public AdressBookBuilder()
        {
            this.contactList = new List<Contact>();
        }

        /// <summary>
        /// Adds the contact but contact is not be duplicated
        /// </summary>
        /// <param name="firstName">The first name of person</param>
        /// <param name="lastName">The last name of person</param>
        /// <param name="address">The address of person</param>
        /// <param name="city">The city of person</param>
        /// <param name="state">The state of person</param>
        /// <param name="zip">The zip code of person</param>
        /// <param name="phoneNumber">The phone number of person</param>
        /// <param name="email">The email of person</param>
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            bool duplicate = equals(firstName);
            if (!duplicate)
            {
                Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                contactList.Add(contact);
            }
            else
            {
                Console.WriteLine("Cannot add duplicate contacts when you give first name same");
            }
        }
}
}
