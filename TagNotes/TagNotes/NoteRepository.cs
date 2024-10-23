using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TagNotes
{
    public class NoteRepository
    {
        private readonly string connectionString;

        public NoteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Note> GetAllNotes()
        {
            List<Note> notes = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Content, Tags FROM Notes";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    notes.Add(new Note
                    {
                        Id = reader.GetInt32(0),
                        Content = reader.GetString(1),
                        Tags = reader.GetString(2)
                    });
                }
            }
            return notes;
        }

        public void AddNote(Note note)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Notes (Content, Tags) VALUES (@content, @tags)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@content", note.Content);
                command.Parameters.AddWithValue("@tags", note.Tags);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateNote(Note note)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Notes SET Content = @content, Tags = @tags WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@content", note.Content);
                command.Parameters.AddWithValue("@tags", note.Tags);
                command.Parameters.AddWithValue("@id", note.Id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteNote(int noteId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Notes WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", noteId);
                command.ExecuteNonQuery();
            }
        }

        public List<Note> SearchNotes(string searchQuery)
        {
            List<Note> notes = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Content, Tags FROM Notes WHERE Content LIKE @searchQuery OR Tags LIKE @searchQuery";
                SqlCommand command = new SqlCommand(query, connection);

                // Debugging output
                Console.WriteLine($"Executing query: {query} with searchQuery: {searchQuery}");

                command.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    notes.Add(new Note
                    {
                        Id = reader.GetInt32(0),
                        Content = reader.GetString(1),
                        Tags = reader.GetString(2)
                    });
                }

                // Debugging output for results
                Console.WriteLine($"Found {notes.Count} notes matching the search.");
            }
            return notes;
        }
    }

    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
    }
}
