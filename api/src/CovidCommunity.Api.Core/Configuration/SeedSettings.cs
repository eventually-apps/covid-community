using System;
using System.Collections.Generic;
using System.Text;

namespace CovidCommunity.Api.Configuration
{
    /// <summary>
    /// This class represents the settings read from the applications configuration for seed setttings
    /// </summary>
    public class SeedSettings
    {
        /// <summary>
        /// The default password for the users to be seeded into the database
        /// </summary>
        public string DefaultPassword { get; set; }

        /// <summary>
        /// The email address for the default admin account seeded into the database
        /// </summary>
        public string AdminEmail { get; set; }

        /// <summary>
        /// The username for the default admin account seeded into the database
        /// </summary>
        public string AdminUsername { get; set; }

        /// <summary>
        /// The first name for the default admin account seeded into the database
        /// </summary>
        public string AdminFirstName { get; set; }

        /// <summary>
        /// The surname/lastname for the defaujlt admin account seeded into the database
        /// </summary>
        public string AdminSurname { get; set; }
    }
}
