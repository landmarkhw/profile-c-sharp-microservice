using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Profile.CSharp.Microservice
{
    public class PersonRepository
    {
        /// <summary>
        /// Get a person from the database.
        /// </summary>
        /// <param name="id">The ID of the person to get.</param>
        /// <returns>The person, if found, or null otherwise.</returns>
        public Person Get(long id)
        {
            var person = Db.Command(cmd => {
                cmd.CommandText = @"
                    SELECT Id, FirstName, LastName
                    FROM Person
                    WHERE Id = @id";
                cmd.Parameters.AddWithValue("id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Person
                        {
                            Id = reader.GetInt64(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                        };
                    }
                }
                return null;
            });

            return person;
        }

        /// <summary>
        /// Save a person into the database.
        /// </summary>
        /// <param name="person">The person to save.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public bool Save(Person person)
        {
            var wasSuccessful = Db.Command(cmd => {
                cmd.CommandText = @"
                    INSERT INTO Person (FirstName, LastName)
                    VALUES (@firstName, @lastName)
                    RETURNING Id";
                cmd.Parameters.AddWithValue("firstName", person.FirstName);
                cmd.Parameters.AddWithValue("lastName", person.LastName);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
                return false;
            });

            return wasSuccessful;
        }
    }
}
