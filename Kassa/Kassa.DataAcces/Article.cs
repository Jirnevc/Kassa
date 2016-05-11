using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassa.DataAcces {
    class Article {



        var ArticleList = new List<Article>();

        var connection = new SqlConnection(connectionString);
        var command = new SqlCommand {
            Connection = connection,
            CommandText = "select Id, FirstName, Name, Email, BirthDate from Person where Id = @Id",
            CommandType = CommandType.Text
        };

        var idParameter = new SqlParameter("Id", id);
        command.Parameters.Add(idParameter);

			connection.Open();

		    var reader = command.ExecuteReader();
		    while (reader.Read())
		    {
			    personList.Add(CreatePerson(reader));
		    }

    connection.Close();

		    return personList.FirstOrDefault();
	    }

/// <summary>
/// Haalt alle persons op
/// </summary>
/// <returns>Lijst met Persons</returns>
public ICollection<Person> GetAll() {
    var personList = new List<Person>();

    var connection = new SqlConnection(connectionString);
    var command = new SqlCommand {
        Connection = connection,
        CommandText = "select Id, FirstName, Name, Email, BirthDate from Person",
        CommandType = CommandType.Text
    };

    connection.Open();

    var reader = command.ExecuteReader();
    while (reader.Read()) {
        personList.Add(CreatePerson(reader));
    }

    connection.Close();

    return personList;
}

/// <summary>
/// Maakt van een Sql record een Person object. Mapper methode.
/// </summary>
/// <param name="reader">SqlDataReader object</param>
/// <returns>Person object</returns>
private Person CreatePerson(SqlDataReader reader) {
    return new Person {
        Id = Convert.ToInt32(reader["Id"]),
        FirstName = reader["FirstName"].ToString(),
        Name = reader["Name"].ToString(),
        Email = reader["Email"].ToString(),
        BirthDate = Convert.ToDateTime(reader["BirthDate"])
    };
}
    }
    }
}
